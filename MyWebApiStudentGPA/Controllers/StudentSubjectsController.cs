using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StudentSubjectsController : Controller
    {
        private readonly IStudentSubjectsBL _studentSubjectsBL;

        public StudentSubjectsController(IStudentSubjectsBL studentSubjectsBL)
        {
            _studentSubjectsBL = studentSubjectsBL;
        }

        [HttpPost]
        public async Task<ActionResult<StudentSubjectsResponseDto>> AddStudentSubject(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var response = _studentSubjectsBL.AddStudentSubject(studentSubjectsRequestDto);
            if (response == null)
            {
                return StatusCode(500);
            }

            return Ok(response);
        }

        [HttpPut("{assignment_id}")]
        public async Task<ActionResult<StudentSubjectsResponseDto>> UpdateStudentSubject(int assignment_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var response = _studentSubjectsBL.UpdateStudentSubject(assignment_id, studentSubjectsRequestDto);
            if (response == null)
            {
                return NotFound("Student or Subject not found");
            }

            return Ok(response);
        }

        [HttpDelete("{assignment_id}")]
        public async Task<IActionResult> DeleteStudentSubject(int assignment_id)
        {
            var response = _studentSubjectsBL.DeleteStudentSubject(assignment_id);
            if (response == false)
            {
                return NotFound("Student or Subject not found");
            }

            return Ok();
        }
    }
}
