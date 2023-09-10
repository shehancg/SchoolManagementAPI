using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CoreWebApi.Models
{
    public class SubjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string SubjectName { get; set; }

        // One-to-Many Relationship: One Subject can be allocated to many Teachers
        public ICollection<AllocateSubjectModel> AllocateSubjects { get; set; } = new List<AllocateSubjectModel>();
    }
}
