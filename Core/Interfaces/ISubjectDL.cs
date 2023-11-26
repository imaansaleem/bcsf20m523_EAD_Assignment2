using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubjectDL
    {
        public SubjectResponseDto? SaveSubject(SubjectRequestDto subject);
        public SubjectResponseDto? GetSubject(int subject_id);
        public IEnumerable<SubjectResponseDto>? GetAllSubjects();
        public SubjectResponseDto? UpdateSubject(int subject_id, SubjectRequestDto subjectRequestDto);
        public bool? DeleteSubject(int subject_id);
    }
}
