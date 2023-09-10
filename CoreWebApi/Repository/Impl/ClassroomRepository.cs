using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SchoolManagementSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CoreWebApi.Repository.Impl
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolManagementContext _context;

        public ClassroomRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassroomModel>> GetAllClassroomsAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<ClassroomModel> GetClassroomByIdAsync(int classroomId)
        {
            return await _context.Classrooms.FindAsync(classroomId);
        }

        /*public async Task<ClassroomModel> AddClassroomAsync(ClassroomModel classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }*/

        /*This checks for classes with same name before inserting*/
        public async Task<ClassroomModel> AddClassroomAsync(ClassroomModel classroom)
        {
            // Remove leading and trailing spaces from the classroom name
            string trimmedClassroomName = classroom.ClassroomName.Trim();

            // Retrieve all classrooms from the database
            var classrooms = await _context.Classrooms.ToListAsync();

            // Check if a classroom with the same name already exists (case-insensitive)
            bool classroomExists = classrooms.Any(c => c.ClassroomName.Trim().Equals(trimmedClassroomName, StringComparison.OrdinalIgnoreCase));

            if (classroomExists)
            {
                // Classroom with the same name already exists, return an appropriate response or throw an exception
                throw new InvalidOperationException("A classroom with the same name already exists.");
            }

            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }



        public async Task<ClassroomModel> UpdateClassroomAsync(ClassroomModel classroom)
        {
            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }

        /*public async Task<bool> DeleteClassroomAsync(int classroomId)
        {
            var classroom = await _context.Classrooms.FindAsync(classroomId);
            if (classroom == null)
                return false;

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return true;
        }*/

        public async Task<bool> DeleteClassroomAsync(int classroomId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students) 
                .FirstOrDefaultAsync(c => c.ClassroomId == classroomId);

            if (classroom == null)
                return false;

            if (classroom.Students.Any())
            {
                // There are enrolled students in the class, so prevent deletion
                return false;
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
