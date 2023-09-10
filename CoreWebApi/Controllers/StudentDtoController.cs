using CoreWebApi.Dtos;
using CoreWebApi.Models;
using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDtoController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentDtoController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetailsDto>> GetStudentDetails(int id)
        {
            var studentDetails = await _studentRepository.GetStudentDetailsByIdAsync(id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return Ok(studentDetails);
        }

        [HttpGet("new/{studentId}")]
        public async Task<IActionResult> GetTeachersAndSubjectsByStudentIdFunc(int studentId)
        {
            try
            {
                var teachersAndSubjects = await _studentRepository.GetTeachersAndSubjectsByStudentIdFunc(studentId);
                return Ok(teachersAndSubjects);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return StatusCode(500, "An error occurred while fetching teachers and subjects.");
            }
        }
    }
}
