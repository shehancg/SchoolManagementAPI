using CoreWebApi.Dtos;
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository.Impl
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolManagementContext _context;

        public SubjectRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubjectModel>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<SubjectModel> GetSubjectByIdAsync(int subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId);
        }

        public async Task<SubjectModel> AddSubjectAsync(SubjectModel subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<SubjectModel> UpdateSubjectAsync(SubjectModel subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int subjectId)
        {
            var subject = await _context.Subjects.FindAsync(subjectId);
            if (subject == null)
                return false;

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
