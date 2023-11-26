using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentBL _studentBL;

        public StudentsController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> SaveStudent(StudentRequestDto student)
        {
            var response = _studentBL.SaveStudent(student);
            if (response == null)
            {
                return StatusCode(500);
            }
            return Ok(response);
        }

        [HttpGet("{student_id}")]
        public async Task<ActionResult<IEnumerable<StudentDbDto>>> GetStudent(int student_id)
        {
            var response = _studentBL.GetStudent(student_id);
            if (response == null)
            {
                return NotFound("Student not found");
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetAllStudents()
        {
            var response = _studentBL.GetAllStudents();
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpPut("{student_id}")]
        public async Task<ActionResult<StudentResponseDto>> UpdateStudent(int student_id, StudentRequestDto studentRequestDto)
        {
            var response = _studentBL.UpdateStudent(student_id, studentRequestDto);
            if (response == null)
            {
                return NotFound("Student not found");
            }
            return Ok(response);
        }

        [HttpDelete("{student_id}")]
        public async Task<IActionResult> DeleteStudent(int student_id)
        {
            var response = _studentBL.DeleteStudent(student_id);
            if (response == false)
            {
                return NotFound("Student not found");
            }
            return Ok();
        }

        [HttpGet("{student_id}/subjects")]
        public async Task<ActionResult<IEnumerable<SubjectResponseDto>>> GetStudentSubjects(int student_id)
        {
            var response = _studentBL.GetStudentSubjects(student_id);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{student_id}/subjects/{subject_id}/marks")]
        public async Task<ActionResult<double?>> GetStudentSingleSubjectMarks(int student_id, int subject_id)
        {
            var response = _studentBL.GetStudentSingleSubjectMarks(student_id, subject_id);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("{student_id}/marks")]
        public async Task<ActionResult<IEnumerable<double>>> GetStudentAllSubjectsMarks(int student_id)
        {
            var response = _studentBL.GetStudentAllSubjectsMarks(student_id);
            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{student_id}/gpa")]
        public async Task<ActionResult<double?>> GetStudentGPA(int student_id)
        {
            var response = _studentBL.GetStudentGPA(student_id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
