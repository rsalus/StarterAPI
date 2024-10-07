using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarterMicroservice.API
{
    [Index(nameof(UserName), IsUnique = true)]
    public class MyUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(128)]
        public required string UserName { get; set; }

        [StringLength(128)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }
    }
}
