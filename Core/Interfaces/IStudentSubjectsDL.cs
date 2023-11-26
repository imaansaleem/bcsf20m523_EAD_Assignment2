using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentSubjectsDL
    {
        public StudentSubjectsResponseDto? AddStudentSubject(StudentSubjectsRequestDto studentSubjectsRequestDto);
        public StudentSubjectsResponseDto? UpdateStudentSubject(int assignment_id, StudentSubjectsRequestDto studentSubjectsRequestDto);
        public bool? DeleteStudentSubject(int assignment_id);
    }
}
