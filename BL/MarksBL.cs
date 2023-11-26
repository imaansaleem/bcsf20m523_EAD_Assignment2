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
    public class MarksBL : IMarksBL
    {
        private readonly IMarksDL _marksDL;

        public MarksBL(IMarksDL marksDL)
        {
            _marksDL = marksDL;
        }

        public StudentSubjectsResponseDto? AddStudentSubjectMarks(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            return _marksDL.AddStudentSubjectMarks(studentSubjectsRequestDto);
        }

        public StudentSubjectsResponseDto? UpdateStudentSubjectMarks(int marks_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            return _marksDL.UpdateStudentSubjectMarks(marks_id, studentSubjectsRequestDto);
        }
    }
}
