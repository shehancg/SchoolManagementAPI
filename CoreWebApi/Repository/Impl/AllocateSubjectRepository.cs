using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementSystem.API.Data;
using System.Linq;
using System;

namespace CoreWebApi.Repository.Impl
{
    public class AllocateSubjectRepository : IAllocateSubjectRepository
    {
        private readonly SchoolManagementContext _context;

        public AllocateSubjectRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllocateSubjectModel>> GetAllAllocatedSubjectsAsync()
        {
            return await _context.AllocateSubjects.ToListAsync();
        }

        public async Task<AllocateSubjectModel> GetAllocatedSubjectByIdAsync(int allocateSubjectId)
        {
            return await _context.AllocateSubjects.FindAsync(allocateSubjectId);
        }

        /*public async Task<AllocateSubjectModel> AddAllocatedSubjectAsync(AllocateSubjectModel allocateSubject)
        {
            _context.AllocateSubjects.Add(allocateSubject);
            await _context.SaveChangesAsync();
            return allocateSubject;
        }*/

        /* With validation prevent in same subject to same teacher */
        public async Task<AllocateSubjectModel> AddAllocatedSubjectAsync(AllocateSubjectModel allocateSubject)
        {
            // Check if the same subject is already allocated to the same teacher
            bool subjectAlreadyAllocated = await _context.AllocateSubjects
                .AnyAsync(allocated =>
                    allocated.TeacherID == allocateSubject.TeacherID &&
                    allocated.SubjectID == allocateSubject.SubjectID);

            if (subjectAlreadyAllocated)
            {
                // Subject is already allocated to the same teacher, return an appropriate response or throw an exception
                throw new InvalidOperationException("The same subject is already allocated to the same teacher.");
            }

            _context.AllocateSubjects.Add(allocateSubject);
            await _context.SaveChangesAsync();
            return allocateSubject;
        }


        public async Task<AllocateSubjectModel> UpdateAllocatedSubjectAsync(AllocateSubjectModel allocateSubject)
        {
            _context.AllocateSubjects.Update(allocateSubject);
            await _context.SaveChangesAsync();
            return allocateSubject;
        }

        public async Task<bool> DeleteAllocatedSubjectAsync(int allocateSubjectId)
        {
            var allocateSubject = await _context.AllocateSubjects.FindAsync(allocateSubjectId);
            if (allocateSubject == null)
                return false;

            _context.AllocateSubjects.Remove(allocateSubject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AllocateSubjectModel>> GetSubjectsByTeacherIdAsync(int teacherId)
        {
            return await _context.AllocateSubjects
                .Where(subject => subject.TeacherID == teacherId)
                .Include(subject => subject.Subject) // Include the related Subject
                .ToListAsync();
        }
    }
}
