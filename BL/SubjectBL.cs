using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubjectBL : ISubjectBL
    {
        private readonly ISubjectDL _subjectDL;

        public SubjectBL(ISubjectDL subjectDL)
        {
            _subjectDL = subjectDL;
        }

        public bool? DeleteSubject(int subject_id)
        {
            return _subjectDL.DeleteSubject(subject_id);
        }

        public IEnumerable<SubjectResponseDto>? GetAllSubjects()
        {
            return _subjectDL.GetAllSubjects();
        }

        public SubjectResponseDto? GetSubject(int subject_id)
        {
            return _subjectDL.GetSubject(subject_id);
        }

        public SubjectResponseDto? SaveSubject(SubjectRequestDto subject)
        {
            return _subjectDL.SaveSubject(subject);
        }

        public SubjectResponseDto? UpdateSubject(int subject_id, SubjectRequestDto subjectRequestDto)
        {
            return _subjectDL.UpdateSubject(subject_id, subjectRequestDto);
        }
    }
}
