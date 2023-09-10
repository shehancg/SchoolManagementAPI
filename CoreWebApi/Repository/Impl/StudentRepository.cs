using System.Collections.Generic;
using System.Linq;
using CoreWebApi.Dtos;
using System.Threading.Tasks;
using CoreWebApi.Models;
using CoreWebApi.Repository;
using SchoolManagementSystem.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace CoreWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementContext _context;
        private readonly string _connectionString;

        public StudentRepository(SchoolManagementContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public StudentModel GetStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(s => s.StudentID == studentId);
        }

        public void AddStudent(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentModel student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public async Task<StudentDetailsDto> GetStudentDetailsByIdAsync(int studentId)
        {
            return await _context.Students
                .Where(s => s.StudentID == studentId)
                .Select(s => new StudentDetailsDto
                {
                    FullName = s.FirstName + " " + s.LastName, // Concatenate first name and last name
                    ContactPerson = s.ContactPerson,
                    ContactNo = s.ContactNo,
                    EmailAddress = s.EmailAddress,
                    DateOfBirth = s.DateOfBirth.Date,
                    ClassroomName = s.Classroom.ClassroomName
                })
                .FirstOrDefaultAsync();
        }

        /*public List<TeacherModel> GetTeachersAndSubjectsForStudent(int studentId)
        {
            return _context.Students
                .Where(s => s.StudentID == studentId)
                .Join(_context.Classrooms,
                    student => student.ClassroomID,
                    classroom => classroom.ClassroomId,
                    (student, classroom) => new { Student = student, Classroom = classroom })
                .SelectMany(sc => sc.Classroom.Teachers, (sc, teacher) => new { StudentClassroom = sc, Teacher = teacher })
                .Select(st => new Teacher
                {
                    TeacherID = st.Teacher.TeacherID,
                    FirstName = st.Teacher.FirstName,
                    LastName = st.Teacher.LastName,
                    Subjects = st.Teacher.Subjects.ToList()
                })
                .ToList();
        }*/

        /*public async Task<List<TeacherModel>> GetTeachersAndSubjectsByStudentClassAsync(int studentId)
        {
            int classroomId = await _context.Students
                .Where(s => s.StudentID == studentId)
                .Select(s => s.ClassroomID)
                .FirstOrDefaultAsync();

            List<int> teacherIds = await _context.AllocateClassrooms
                .Where(ac => ac.ClassroomID == classroomId)
                .Select(ac => ac.TeacherID)
                .ToListAsync();

            List<TeacherModel> teachers = await _context.Teachers
                .Where(t => teacherIds.Contains(t.TeacherID))
                .Include(t => t.AllocateSubjects)
                .ThenInclude(as => as.Subject)
                .ToListAsync();

            return teachers;
        }*/

        public async Task<List<(TeacherModel teacher, List<SubjectModel> allocatedSubjects)>> GetTeachersAndSubjectsByStudentIdAsync(int studentId)
        {
            var student = await _context.Students
                .Where(s => s.StudentID == studentId)
                .FirstOrDefaultAsync();

            if (student != null)
            {
                // Get the ClassroomID of the student
                int classroomId = student.ClassroomID;

                // Get the teachers allocated to the student's class and the subjects allocated to those teachers
                var teachersAndSubjects = await _context.AllocateClassrooms
                    .Where(ac => ac.ClassroomID == classroomId)
                    .Join(
                        _context.Teachers,
                        ac => ac.TeacherID,
                        t => t.TeacherID,
                        (ac, t) => new
                        {
                            Teacher = t,
                            AllocatedSubjects = _context.AllocateSubjects
                                .Where(asub => asub.TeacherID == t.TeacherID)
                                .Select(asub => asub.Subject)
                                .ToList()
                        }
                    )
                    .ToListAsync();

                // Now you can access the teachers and their allocated subjects for the given student
                var result = teachersAndSubjects.Select(teacherAndSubjects =>
                {
                    return (
                        teacherAndSubjects.Teacher,
                        teacherAndSubjects.AllocatedSubjects
                    );
                }).ToList();

                return result;
            }

            return new List<(TeacherModel teacher, List<SubjectModel> allocatedSubjects)>();
        }

        /*This is For a stored procedure */
        /*public async Task<List<TeacherAndSubject>> GetTeachersAndSubjectsByStudentIdFunc(int studentId)
        {
            var result = new List<TeacherAndSubject>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GetTeachersAndSubjectsForStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            // Read the columns from the result set
                            var teacherId = reader.GetInt32(0);
                            var teacherFirstName = reader.GetString(1);
                            var teacherLastName = reader.GetString(2);
                            var subjectId = reader.GetInt32(3);
                            var subjectName = reader.GetString(4);

                            // Create TeacherAndSubject object and add it to the result list
                            result.Add(new TeacherAndSubject
                            {
                                TeacherId = teacherId,
                                TeacherFirstName = teacherFirstName,
                                TeacherLastName = teacherLastName,
                                SubjectId = subjectId,
                                SubjectName = subjectName
                            });
                        }
                    }
                }
            }

            return result;
        }*/

        public async Task<List<TeacherAndSubject>> GetTeachersAndSubjectsByStudentIdFunc(int studentId)
        {
            var result = new List<TeacherAndSubject>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT * FROM dbo.GetTeachersAndSubjectsForStudent(@StudentID)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            // Read the columns from the result set
                            var teacherId = reader.GetInt32(0);
                            var teacherFirstName = reader.GetString(1);
                            var teacherLastName = reader.GetString(2);
                            var subjectId = reader.GetInt32(3);
                            var subjectName = reader.GetString(4);

                            // Create TeacherAndSubject object and add it to the result list
                            result.Add(new TeacherAndSubject
                            {
                                TeacherId = teacherId,
                                TeacherFirstName = teacherFirstName,
                                TeacherLastName = teacherLastName,
                                SubjectId = subjectId,
                                SubjectName = subjectName
                            });
                        }
                    }
                }
            }

            return result;
        }

    }
}
