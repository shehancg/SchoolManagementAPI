using CoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IAllocateSubjectRepository
    {
        Task<IEnumerable<AllocateSubjectModel>> GetAllAllocatedSubjectsAsync();
        Task<AllocateSubjectModel> GetAllocatedSubjectByIdAsync(int allocateSubjectId);
        Task<AllocateSubjectModel> AddAllocatedSubjectAsync(AllocateSubjectModel allocateSubject);
        Task<AllocateSubjectModel> UpdateAllocatedSubjectAsync(AllocateSubjectModel allocateSubject);
        Task<bool> DeleteAllocatedSubjectAsync(int allocateSubjectId);
        Task<IEnumerable<AllocateSubjectModel>> GetSubjectsByTeacherIdAsync(int teacherId);
    }
}
