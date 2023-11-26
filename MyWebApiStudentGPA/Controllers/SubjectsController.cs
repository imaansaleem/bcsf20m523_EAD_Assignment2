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
    public class SubjectsController : Controller
    {
        private readonly ISubjectBL _subjectBL;

        public SubjectsController(ISubjectBL subjectBL)
        {
            _subjectBL = subjectBL;
        }

        [HttpPost]
        public async Task<ActionResult<SubjectResponseDto>> SaveSubject(SubjectRequestDto subject)
        {
            var response = _subjectBL.SaveSubject(subject);
            if (response == null)
            {
                return StatusCode(500);
            }
            return Ok(response);
        }

        [HttpGet("{subject_id}")]
        public async Task<ActionResult<SubjectResponseDto>> GetSubject(int subject_id)
        {
            var response = _subjectBL.GetSubject(subject_id);
            if (response == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponseDto>>> GetAllSubjects()
        {
            var response = _subjectBL.GetAllSubjects();
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpPut("{subject_id}")]
        public async Task<ActionResult<SubjectResponseDto>> UpdateSubject(int subject_id, SubjectRequestDto subjectRequestDto)
        {
            var response = _subjectBL.UpdateSubject(subject_id, subjectRequestDto);
            if (response == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(response);
        }

        [HttpDelete("{subject_id}")]
        public async Task<IActionResult> DeleteSubject(int subject_id)
        {
            var response = _subjectBL.DeleteSubject(subject_id);
            if (response == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(response);
        }
    }
}
