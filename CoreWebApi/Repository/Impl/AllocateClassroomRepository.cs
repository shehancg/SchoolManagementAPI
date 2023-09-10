using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;

namespace CoreWebApi.Repositories
{
    public class AllocateClassroomRepository : IAllocateClassroomRepository
    {
        private readonly SchoolManagementContext _context;

        public AllocateClassroomRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllocateClassroomModel>> GetAllAllocateClassroomsAsync()
        {
            return await _context.AllocateClassrooms.ToListAsync();
        }

        public async Task<AllocateClassroomModel> GetAllocateClassroomByIdAsync(int allocateClassroomId)
        {
            return await _context.AllocateClassrooms.FindAsync(allocateClassroomId);
        }

        /*public async Task<AllocateClassroomModel> AddAllocateClassroomAsync(AllocateClassroomModel allocateClassroom)
        {
            _context.AllocateClassrooms.Add(allocateClassroom);
            await _context.SaveChangesAsync();
            return allocateClassroom;
        }*/

        public async Task<AllocateClassroomModel> AddAllocateClassroomAsync(AllocateClassroomModel allocateClassroom)
        {
            // Check if the same classroom is already allocated to the same teacher
            bool classroomAlreadyAllocated = await _context.AllocateClassrooms
                .AnyAsync(allocated =>
                    allocated.TeacherID == allocateClassroom.TeacherID &&
                    allocated.ClassroomID == allocateClassroom.ClassroomID);

            if (classroomAlreadyAllocated)
            {
                // Classroom is already allocated to the same teacher, return an appropriate response or throw an exception
                throw new InvalidOperationException("The same classroom is already allocated to the same teacher.");
            }

            _context.AllocateClassrooms.Add(allocateClassroom);
            await _context.SaveChangesAsync();
            return allocateClassroom;
        }


        public async Task<AllocateClassroomModel> UpdateAllocateClassroomAsync(AllocateClassroomModel allocateClassroom)
        {
            _context.Entry(allocateClassroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return allocateClassroom;
        }

        public async Task<bool> DeleteAllocateClassroomAsync(int allocateClassroomId)
        {
            var allocateClassroom = await _context.AllocateClassrooms.FindAsync(allocateClassroomId);
            
            if (allocateClassroom == null)
                return false;

            _context.AllocateClassrooms.Remove(allocateClassroom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AllocateClassroomModel>> GetClassesByTeacherIdAsync(int teacherId)
        {
            return await _context.AllocateClassrooms
                .Where(AllocateClassrooms => AllocateClassrooms.TeacherID == teacherId)
                .Include(AllocateClassrooms => AllocateClassrooms.Classroom)
                .ToListAsync();
        }
    }
}
