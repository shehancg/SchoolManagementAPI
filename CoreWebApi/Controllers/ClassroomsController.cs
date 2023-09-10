using CoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CoreWebApi.Models;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomsController(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        // GET: api/classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomModel>>> GetClassrooms()
        {
            var classrooms = await _classroomRepository.GetAllClassroomsAsync();
            return Ok(classrooms);
        }

        // GET: api/classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomModel>> GetClassroomById(int id)
        {
            var classroom = await _classroomRepository.GetClassroomByIdAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        // POST: api/classrooms
        [HttpPost]
        public async Task<ActionResult<ClassroomModel>> CreateClassroom([FromBody] ClassroomModel classroom)
        {
            if (classroom == null)
            {
                return BadRequest();
            }

            var newClassroom = await _classroomRepository.AddClassroomAsync(classroom);
            return CreatedAtAction(nameof(GetClassroomById), new { id = newClassroom.ClassroomId }, newClassroom);
        }

        // PUT: api/classrooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassroom(int id, [FromBody] ClassroomModel classroom)
        {
            if (classroom == null || id != classroom.ClassroomId)
            {
                return BadRequest();
            }

            var existingClassroom = await _classroomRepository.GetClassroomByIdAsync(id);
            if (existingClassroom == null)
            {
                return NotFound();
            }

            await _classroomRepository.UpdateClassroomAsync(classroom);
            return NoContent();
        }

        // DELETE: api/classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _classroomRepository.GetClassroomByIdAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            var deleted = await _classroomRepository.DeleteClassroomAsync(id);
            if (!deleted)
            {
                throw new Exception("Failed to delete the classroom.");
            }

            return NoContent();
        }
    }
}
