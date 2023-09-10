using CoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<ClassroomModel>> GetAllClassroomsAsync();
        Task<ClassroomModel> GetClassroomByIdAsync(int classroomId);
        Task<ClassroomModel> AddClassroomAsync(ClassroomModel classroom);
        Task<ClassroomModel> UpdateClassroomAsync(ClassroomModel classroom);
        Task<bool> DeleteClassroomAsync(int classroomId);
    }
}
