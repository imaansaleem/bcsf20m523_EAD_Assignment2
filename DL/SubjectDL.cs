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
    public class SubjectDL : ISubjectDL
    {
        StudentDbContext _stContext;

        public SubjectDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public bool? DeleteSubject(int subject_id)
        {
            var subject = _stContext.Subjects.FirstOrDefault(s => s.Id == subject_id);

            if (subject == null)
            {
                return false;
            }
            _stContext.Subjects.Remove(subject);
            _stContext.SaveChanges();
            return true;
        }

        public IEnumerable<SubjectResponseDto>? GetAllSubjects()
        {
            var subjects = _stContext.Subjects
                           .Select(s => new SubjectResponseDto
                           {
                               Name = s.Name,
                               Id = s.Id,
                           }
                       ).ToList();

            return subjects;
        }

        public SubjectResponseDto? GetSubject(int subject_id)
        {
            var subject = _stContext.Subjects
                            .Where(s => s.Id == subject_id)
                            .Select(s => new SubjectResponseDto
                            {
                                Name = s.Name,
                                Id = s.Id,
                            }
                        ).FirstOrDefault();

            return subject;
        }

        public SubjectResponseDto? SaveSubject(SubjectRequestDto subject)
        {
            if(subject == null)
            {
                return null;
            }
            var newSubject = new SubjectDbDto
            {
                Name = subject.Name
            };
            _stContext.Subjects.Add(newSubject);
            _stContext.SaveChanges();
            _stContext.Entry(newSubject).Reload();

            SubjectResponseDto subjectResponse = new SubjectResponseDto
            {
                Name = newSubject.Name,
                Id = newSubject.Id,
            };
            return subjectResponse;
        }

        public SubjectResponseDto? UpdateSubject(int subject_id, SubjectRequestDto subjectRequestDto)
        {
            var existingSubject = _stContext.Subjects.FirstOrDefault(s => s.Id == subject_id);
            if(existingSubject == null)
            {
                return null;
            }
            existingSubject.Name = subjectRequestDto.Name;
            _stContext.SaveChanges();

            return new SubjectResponseDto
            {
                Id = existingSubject.Id,
                Name = existingSubject.Name
            };
        }
    }
}
