using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebClient.Models
{
    public class User
    {
        public Employee Employee { get; set; }

        [Key]
        [ForeignKey("Employee")]
        public int id { get; set; }

        public UserRoleType UserRoleType { get; set; }

        [ForeignKey("UserRoleType")]
        public int userRoleTypeId { get; set; }

        [Required]
        public int availableLeaves { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string password { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime registeredAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updatedAt { get; set; }
    }
}
