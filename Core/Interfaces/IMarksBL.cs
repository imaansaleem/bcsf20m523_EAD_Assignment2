using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMarksBL
    {
        public StudentSubjectsResponseDto? AddStudentSubjectMarks(StudentSubjectsRequestDto studentSubjectsRequestDto);
        public StudentSubjectsResponseDto? UpdateStudentSubjectMarks(int marks_id, StudentSubjectsRequestDto studentSubjectsRequestDto);
    }
}
