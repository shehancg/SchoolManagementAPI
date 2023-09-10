// ITeacherRepository.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Models;

namespace CoreWebApi.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> GetAllTeachers();
        Task<TeacherModel> GetTeacherById(int id);
        Task<TeacherModel> AddTeacher(TeacherModel teacher);
        Task<TeacherModel> UpdateTeacher(TeacherModel teacher);
        Task<bool> DeleteTeacher(int id);
    }
}
