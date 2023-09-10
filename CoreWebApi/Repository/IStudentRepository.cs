using System.Collections.Generic;
using CoreWebApi.Dtos;
using System.Threading.Tasks;
using CoreWebApi.Models;

namespace CoreWebApi.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel GetStudentById(int studentId);
        void AddStudent(StudentModel student);
        void UpdateStudent(StudentModel student);
        void DeleteStudent(int studentId);
        Task<StudentDetailsDto> GetStudentDetailsByIdAsync(int studentId);

        Task<List<(TeacherModel teacher, List<SubjectModel> allocatedSubjects)>> GetTeachersAndSubjectsByStudentIdAsync(int studentId);

        Task<List<TeacherAndSubject>> GetTeachersAndSubjectsByStudentIdFunc(int studentId);
    }
}

