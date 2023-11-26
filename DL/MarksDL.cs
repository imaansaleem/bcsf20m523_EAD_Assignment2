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
    public class MarksDL : IMarksDL
    {
        StudentDbContext _stContext;

        public MarksDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentSubjectsResponseDto? AddStudentSubjectMarks(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var StudentId = studentSubjectsRequestDto.StudentId;
            var SubjectId = studentSubjectsRequestDto.SubjectId;
            if (StudentId == null || SubjectId == null)
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

            var existing = _stContext.StudentSubjects.FirstOrDefault(ss => ss.StudentId == StudentId && ss.SubjectId == SubjectId);
            if (existing == null)
            {
                existing = new StudentSubjectDbDto
                {
                    StudentId = (int)StudentId,
                    SubjectId = (int)SubjectId
                };
                _stContext.StudentSubjects.Add(existing);
                _stContext.SaveChanges();
            }
            existing.marks = (double)studentSubjectsRequestDto.Marks;

            _stContext.SaveChanges();
            _stContext.Entry(existing).Reload();
            return new StudentSubjectsResponseDto
            {
                Id = existing.Id,
                SubjectId = existing.SubjectId,
                StudentId = existing.StudentId,
                Marks = existing.marks
            };
        }

        public StudentSubjectsResponseDto? UpdateStudentSubjectMarks(int marks_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            if(studentSubjectsRequestDto == null)
            {
                return null;
            }
            var existing = _stContext.StudentSubjects.FirstOrDefault(ss => ss.Id == marks_id);
            if (existing == null)
            {
                return null;
            }
            existing.marks = (double)studentSubjectsRequestDto.Marks;

            _stContext.SaveChanges();
            _stContext.Entry(existing).Reload();
            return new StudentSubjectsResponseDto
            {
                Id = existing.Id,
                SubjectId = existing.SubjectId,
                StudentId = existing.StudentId,
                Marks = existing.marks
            };
        }
    }
}
