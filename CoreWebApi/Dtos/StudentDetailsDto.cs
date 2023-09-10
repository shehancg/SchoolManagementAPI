using System;

namespace CoreWebApi.Dtos
{
    public class StudentDetailsDto
    {
        public string FullName { get; set; } // Concatenated full name of the student
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ClassroomName { get; set; }
    }
}
