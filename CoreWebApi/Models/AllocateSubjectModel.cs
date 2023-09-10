using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models
{
    public class AllocateSubjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllocateSubjectID { get; set; }

        [Required]
        [Column(TypeName = "int")] // Specify the column type for TeacherID
        public int TeacherID { get; set; }

        [ForeignKey("TeacherID")]
        public TeacherModel Teacher { get; set; }

        [Required]
        [Column(TypeName = "int")] // Specify the column type for SubjectID
        public int SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        public SubjectModel Subject { get; set; }
    }
}
