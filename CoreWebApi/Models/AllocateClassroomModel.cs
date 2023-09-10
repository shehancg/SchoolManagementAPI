using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AllocateClassroomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllocateClassroomID { get; set; }

        // Foreign key to reference TeacherModel
        [Required]
        public int TeacherID { get; set; }

        [ForeignKey("TeacherID")]
        public TeacherModel Teacher { get; set; }

        // Foreign key to reference ClassroomModel
        [Required]
        public int ClassroomID { get; set; }

        [ForeignKey("ClassroomID")]
        public ClassroomModel Classroom { get; set; }
    }
}
