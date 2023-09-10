using CoreWebApi.Models;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // GET: api/subject
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _subjectRepository.GetAllSubjectsAsync();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving subjects: {ex.Message}");
            }
        }

        // GET: api/subject/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                var subject = await _subjectRepository.GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    return NotFound();
                }

                return Ok(subject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the subject: {ex.Message}");
            }
        }

        // POST: api/subject
        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] SubjectModel subject)
        {
            try
            {
                if (subject == null)
                {
                    return BadRequest("Subject data is null");
                }

                var addedSubject = await _subjectRepository.AddSubjectAsync(subject);
                return CreatedAtAction(nameof(GetSubjectById), new { id = addedSubject.SubjectId }, addedSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the subject: {ex.Message}");
            }
        }

        // PUT: api/subject/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] SubjectModel subject)
        {
            try
            {
                if (subject == null || id != subject.SubjectId)
                {
                    return BadRequest("Invalid subject data");
                }

                var existingSubject = await _subjectRepository.GetSubjectByIdAsync(id);
                if (existingSubject == null)
                {
                    return NotFound();
                }

                var updatedSubject = await _subjectRepository.UpdateSubjectAsync(subject);
                return Ok(updatedSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the subject: {ex.Message}");
            }
        }

        // DELETE: api/subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                var subject = await _subjectRepository.GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    return NotFound();
                }

                var isDeleted = await _subjectRepository.DeleteSubjectAsync(id);
                if (!isDeleted)
                {
                    return StatusCode(500, "Failed to delete the subject");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the subject: {ex.Message}");
            }
        }
    }
}
