using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models;
using CoreWebApi.Repositories;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: api/teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherModel>>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return Ok(teachers);
        }

        // GET: api/teacher/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherModel>> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        // POST: api/teacher
        [HttpPost]
        public async Task<ActionResult<TeacherModel>> AddTeacher(TeacherModel teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var addedTeacher = await _teacherRepository.AddTeacher(teacher);
                return CreatedAtAction(nameof(GetTeacherById), new { id = addedTeacher.TeacherID }, addedTeacher);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding teacher: {ex.Message}");
            }
        }

        // PUT: api/teacher/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherModel>> UpdateTeacher(int id, TeacherModel teacher)
        {
            if (id != teacher.TeacherID)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var updatedTeacher = await _teacherRepository.UpdateTeacher(teacher);
                return Ok(updatedTeacher);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating teacher: {ex.Message}");
            }
        }

        // DELETE: api/teacher/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                var result = await _teacherRepository.DeleteTeacher(id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting teacher: {ex.Message}");
            }
        }
    }
}
