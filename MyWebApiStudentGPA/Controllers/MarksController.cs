using BL;
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
    public class MarksController : Controller
    {
        private readonly IMarksBL _marksBL;

        public MarksController(IMarksBL marksBL)
        {
            _marksBL = marksBL;
        }

        [HttpPost]
        public async Task<ActionResult<StudentSubjectsResponseDto>> AddStudentSubjectMarks(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var response = _marksBL.AddStudentSubjectMarks(studentSubjectsRequestDto);
            if (response == null)
            {
                return NotFound("Student or Subject not found");
            }
            return Ok(response);
        }

        [HttpPut("{marks_id}")]
        public async Task<ActionResult<StudentSubjectsResponseDto>> UpdateStudentSubjectMarks(int marks_id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            var response = _marksBL.UpdateStudentSubjectMarks(marks_id, studentSubjectsRequestDto);
            if (response == null)
            {
                return NotFound("Student or Subject not found");
            }
            return Ok(response);
        }
    }
}
