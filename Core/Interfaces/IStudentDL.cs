using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentDL
    {
        public StudentResponseDto? SaveStudent(StudentRequestDto studentRequestDto);
        public StudentDetailSubjectResponseDto? GetStudent(int student_id);
        public IEnumerable<StudentResponseDto>? GetAllStudents();
        public StudentResponseDto? UpdateStudent(int student_id, StudentRequestDto studentRequestDto);
        public bool DeleteStudent(int student_id);
        public IEnumerable<SubjectResponseDto>? GetStudentSubjects(int student_id);
        public double? GetStudentSingleSubjectMarks(int student_id, int subject_id);
        IEnumerable<double>? GetStudentAllSubjectsMarks(int student_id);
        double? GetStudentGPA(int student_id);
    }
}
