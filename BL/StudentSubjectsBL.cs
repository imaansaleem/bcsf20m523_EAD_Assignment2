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
    public class StudentSubjectsBL : IStudentSubjectsBL
    {
        private readonly IStudentSubjectsDL _studentSubjectsDL;

        public StudentSubjectsBL(IStudentSubjectsDL studentSubjectsDL)
        {
            _studentSubjectsDL = studentSubjectsDL;
        }

        public StudentSubjectsResponseDto? AddStudentSubject(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            return _studentSubjectsDL.AddStudentSubject(studentSubjectsRequestDto);
        }

        public bool? DeleteStudentSubject(int assignment_id)
        {
            return _studentSubjectsDL.DeleteStudentSubject(assignment_id); 
        }

        public StudentSubjectsResponseDto? UpdateStudentSubject(int assignment_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            return _studentSubjectsDL.UpdateStudentSubject(assignment_id, studentSubjectsRequestDto);
        }
    }
}
