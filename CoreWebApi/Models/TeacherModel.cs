using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CoreWebApi.Models
{
    public class TeacherModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string ContactNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string EmailAddress { get; set; }

        // One-to-Many Relationship r defined One Teacher can be allocated to many Subjects & classrooms
        public ICollection<AllocateClassroomModel> AllocateClassrooms { get; set; } = new List<AllocateClassroomModel>();

        public ICollection<AllocateSubjectModel> AllocateSubjects { get; set; } = new List<AllocateSubjectModel>();

    }
}
