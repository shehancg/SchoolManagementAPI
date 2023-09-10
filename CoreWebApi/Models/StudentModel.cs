using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CoreWebApi.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ContactPerson { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ContactNo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        public int ClassroomID { get; set; }

        [ForeignKey("ClassroomID")]
        public ClassroomModel Classroom { get; set; }
    }
}
