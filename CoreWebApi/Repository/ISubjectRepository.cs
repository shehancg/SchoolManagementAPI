using CoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<SubjectModel>> GetAllSubjectsAsync();
        Task<SubjectModel> GetSubjectByIdAsync(int subjectId);
        Task<SubjectModel> AddSubjectAsync(SubjectModel subject);
        Task<SubjectModel> UpdateSubjectAsync(SubjectModel subject);
        Task<bool> DeleteSubjectAsync(int subjectId);
    }
}
