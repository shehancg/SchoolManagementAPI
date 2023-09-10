using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models
{
    public class ClassroomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ClassroomName { get; set;}

        // Navigation property for the one-to-many relationship
        public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();

        public ICollection<AllocateClassroomModel> AllocateClassrooms { get; set; } = new List<AllocateClassroomModel>();
    }
}
