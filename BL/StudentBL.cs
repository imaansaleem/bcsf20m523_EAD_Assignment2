using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDL _studentDL;

        public StudentBL(IStudentDL studentDL)
        {
            _studentDL = studentDL;
        }

        public bool DeleteStudent(int student_id)
        {
            return _studentDL.DeleteStudent(student_id);
        }

        public IEnumerable<StudentResponseDto>? GetAllStudents()
        {
            return _studentDL.GetAllStudents();
        }

        public StudentDetailSubjectResponseDto? GetStudent(int student_id)
        {
            return _studentDL.GetStudent(student_id);
        }

        public IEnumerable<double>? GetStudentAllSubjectsMarks(int student_id)
        {
            return _studentDL.GetStudentAllSubjectsMarks(student_id);
        }

        public double? GetStudentGPA(int student_id)
        {
            return _studentDL.GetStudentGPA(student_id);
        }

        public double? GetStudentSingleSubjectMarks(int student_id, int subject_id)
        {
            return _studentDL.GetStudentSingleSubjectMarks(student_id, subject_id);
        }

        public IEnumerable<SubjectResponseDto>? GetStudentSubjects(int student_id)
        {
            return _studentDL.GetStudentSubjects(student_id);
        }

        public StudentResponseDto? SaveStudent(StudentRequestDto studentRequestDto)
        {
            return _studentDL.SaveStudent(studentRequestDto);
        }

        public StudentResponseDto? UpdateStudent(int student_id, StudentRequestDto studentRequestDto)
        {
            return _studentDL.UpdateStudent(student_id, studentRequestDto);
        }
    }
}
