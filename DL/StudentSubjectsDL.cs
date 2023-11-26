using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentSubjectsDL : IStudentSubjectsDL
    {
        StudentDbContext _stContext;

        public StudentSubjectsDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentSubjectsResponseDto? AddStudentSubject(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var StudentId = studentSubjectsRequestDto.StudentId;
            var SubjectId = studentSubjectsRequestDto.SubjectId;
            if(StudentId == null || SubjectId == null)
            {
                return null;
            }

            var student = _stContext.Students.FirstOrDefault(s => s.Id == StudentId);
            if (student == null)
            {
                return null;
            }

            var subject = _stContext.Subjects.FirstOrDefault(sb => sb.Id == SubjectId);
            if (subject == null)
            {
                return null;
            }

            var newStudentSubject = new StudentSubjectDbDto
            {
                StudentId = (int)StudentId,
                SubjectId = (int)SubjectId
            };

            _stContext.StudentSubjects.Add(newStudentSubject);
            _stContext.Entry(newStudentSubject).Reload();
            return new StudentSubjectsResponseDto
            {
                Id = newStudentSubject.Id,
                SubjectId = newStudentSubject.SubjectId,
                StudentId = newStudentSubject.StudentId,
            };
        }

        public bool? DeleteStudentSubject(int assignment_id)
        {
            var existing = _stContext.StudentSubjects.FirstOrDefault(ss => ss.Id == assignment_id);
            if (existing == null)
            {
                return false;
            }

            _stContext.StudentSubjects.Remove(existing);
            _stContext.SaveChanges();
            return true;
        }

        public StudentSubjectsResponseDto? UpdateStudentSubject(int assignment_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var existing = _stContext.StudentSubjects.FirstOrDefault(ss => ss.Id == assignment_id);
            if (existing == null || studentSubjectsRequestDto == null)
            {
                return null;
            }
            existing.StudentId = (int)studentSubjectsRequestDto.StudentId;
            existing.SubjectId = (int)studentSubjectsRequestDto.SubjectId;

            _stContext.SaveChanges();
            return new StudentSubjectsResponseDto
            {
                Id = existing.Id,
                SubjectId = existing.SubjectId,
                StudentId = existing.StudentId,
            };
        }
    }
}
