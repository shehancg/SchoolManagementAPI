using CoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Repositories
{
    public interface IAllocateClassroomRepository
    {
        Task<IEnumerable<AllocateClassroomModel>> GetAllAllocateClassroomsAsync();
        Task<AllocateClassroomModel> GetAllocateClassroomByIdAsync(int allocateClassroomId);
        Task<AllocateClassroomModel> AddAllocateClassroomAsync(AllocateClassroomModel allocateClassroom);
        Task<AllocateClassroomModel> UpdateAllocateClassroomAsync(AllocateClassroomModel AllocateClassroomModel);
        Task<bool> DeleteAllocateClassroomAsync(int allocateClassroomId);
        Task<IEnumerable<AllocateClassroomModel>> GetClassesByTeacherIdAsync(int teacherId);
    }
}
