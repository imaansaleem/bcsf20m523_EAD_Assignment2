using Core.Interfaces;
using Core.Models;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public bool DeleteStudent(int student_id)
        {
            var student = _stContext.Students.FirstOrDefault(s => s.Id == student_id);

            if (student == null)
            {
                return false;
            }
            _stContext.Students.Remove(student);
            _stContext.SaveChanges();
            return true;
        }

        public IEnumerable<StudentResponseDto>? GetAllStudents()
        {
            var students = _stContext.Students.Select(s => new StudentResponseDto
                                                            {
                                                                Id = s.Id,
                                                                Name = s.Name,
                                                                RollNo = s.RollNumber,
                                                                PhoneNumber = s.PhoneNumber,
                                                                Marks = s.StudentSubjects.Select(ss => ss.marks)
                                                                                         .FirstOrDefault()
                                                            }).AsEnumerable();
            return students;
        }

        public StudentDetailSubjectResponseDto? GetStudent(int student_id)
        {
            var student = _stContext.Students
                                   .Where(s => s.Id == student_id)
                                   .Select(s => new StudentDetailSubjectResponseDto
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       RollNo = s.RollNumber,
                                       PhoneNumber = s.PhoneNumber,
                                       Marks = s.StudentSubjects
                                               .Select(ss => ss.marks)
                                               .FirstOrDefault(),
                                       SubjectMarks = s.StudentSubjects
                                                       .Select(ss => new StudentSubjectMarksDto
                                                       {
                                                           SubjectId = ss.SubjectId,
                                                       })
                                                       .ToList()
                                   })
                                   .FirstOrDefault();

            return student;
        }

        public IEnumerable<double>? GetStudentAllSubjectsMarks(int student_id)
        {
            var marks = _stContext.Students
                   .Where(s => s.Id == student_id)
                   .Include(s => s.StudentSubjects)
                   .Select(s => s.StudentSubjects.Select(ss => ss.marks))
                   .FirstOrDefault();

            return marks;
        }

        public double? GetStudentGPA(int student_id)
        {
            var marks = _stContext.Students
                   .Where(s => s.Id == student_id)
                   .Include(s => s.StudentSubjects)
                   .Select(s => s.StudentSubjects.Select(ss => ss.marks))
                   .FirstOrDefault();
            if(marks == null)
            {
                return null;
            }

            return marks.Average();
        }

        public double? GetStudentSingleSubjectMarks(int student_id, int subject_id)
        {
            var marks = _stContext.Students
                .Where(s => s.Id == student_id)
                .SelectMany(s => s.StudentSubjects)
                .FirstOrDefault(ss => ss.SubjectId == subject_id)?.marks;

            return marks;
        }

        public IEnumerable<SubjectResponseDto> GetStudentSubjects(int student_id)
        {
            var subjects = _stContext.Students
                    .Where(s => s.Id == student_id)
                    .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Subject)
                    .SelectMany(s => s.StudentSubjects.Select(ss => new SubjectResponseDto
                    {
                        Id = ss.Subject.Id,
                        Name = ss.Subject.Name,
                    }))
                    .ToList();

            return subjects;
        }

        public StudentResponseDto? SaveStudent(StudentRequestDto studentRequestDto)
        {
            if (studentRequestDto == null)
            {
                return null;
            }

            var student = new StudentDbDto
            {
                Name = studentRequestDto.Name,
                RollNumber = studentRequestDto.RollNo,
                PhoneNumber = studentRequestDto.PhoneNumber,
            };
            _stContext.Students.Add(student);
            _stContext.SaveChanges();
            _stContext.Entry(student).Reload();

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                RollNo = student.RollNumber,
            };
        }

        public StudentResponseDto? UpdateStudent(int student_id, StudentRequestDto studentRequestDto)
        {
            var existingStudent = _stContext.Students.FirstOrDefault(s => s.Id == student_id);

            if (existingStudent == null || studentRequestDto == null)
            {
                return null;
            }
            existingStudent.Name = studentRequestDto.Name;
            existingStudent.RollNumber = studentRequestDto.RollNo;
            existingStudent.PhoneNumber = studentRequestDto.PhoneNumber;
            _stContext.SaveChanges();

            return new StudentResponseDto
            {
                Id = existingStudent.Id,
                Name = existingStudent.Name,
                RollNo = existingStudent.RollNumber,
                PhoneNumber = existingStudent.PhoneNumber
            };
        }
    }
}
