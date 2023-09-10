using CoreWebApi.Models;
using CoreWebApi.Repositories;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllocateSubjectController : ControllerBase
    {
        private readonly IAllocateSubjectRepository _allocateSubjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public AllocateSubjectController(IAllocateSubjectRepository allocateSubjectRepository, ITeacherRepository teacherRepository)
        {
            _allocateSubjectRepository = allocateSubjectRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllocatedSubjects()
        {
            try
            {
                var allocatedSubjects = await _allocateSubjectRepository.GetAllAllocatedSubjectsAsync();
                return Ok(allocatedSubjects);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocated subjects: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllocatedSubjectById(int id)
        {
            try
            {
                var allocateSubject = await _allocateSubjectRepository.GetAllocatedSubjectByIdAsync(id);
                if (allocateSubject == null)
                    return NotFound();

                return Ok(allocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving allocated subject: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAllocatedSubject(AllocateSubjectModel allocateSubject)
        {
            try
            {
                var newAllocateSubject = await _allocateSubjectRepository.AddAllocatedSubjectAsync(allocateSubject);
                return CreatedAtAction(nameof(GetAllocatedSubjectById), new { id = newAllocateSubject.AllocateSubjectID }, newAllocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding allocated subject: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllocatedSubject(int id, AllocateSubjectModel allocateSubject)
        {
            try
            {
                if (id != allocateSubject.AllocateSubjectID)
                    return BadRequest("Mismatched AllocateSubjectID in the request.");

                var existingAllocateSubject = await _allocateSubjectRepository.GetAllocatedSubjectByIdAsync(id);
                if (existingAllocateSubject == null)
                    return NotFound();

                var updatedAllocateSubject = await _allocateSubjectRepository.UpdateAllocatedSubjectAsync(allocateSubject);
                return Ok(updatedAllocateSubject);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating allocated subject: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocatedSubject(int id)
        {
            try
            {
                var deleted = await _allocateSubjectRepository.DeleteAllocatedSubjectAsync(id);
                if (!deleted)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting allocated subject: {ex.Message}");
            }
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult> GetSubjectsByTeacherId(int teacherId)
        {
            try
            {
                var teacher = await _teacherRepository.GetTeacherById(teacherId);
                if (teacher == null)
                    return NotFound("Teacher not found.");

                var allocatedSubjects = await _allocateSubjectRepository.GetSubjectsByTeacherIdAsync(teacherId);

                var result = allocatedSubjects.Select(subject => new
                {
                    subject.AllocateSubjectID,
                    subject.SubjectID,
                    subject.TeacherID,
                    subject.Subject.SubjectName 
                    
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving subjects by teacher ID: {ex.Message}");
            }
        }

    }
}
