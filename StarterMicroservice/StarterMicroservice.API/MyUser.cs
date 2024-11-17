using System.ComponentModel.DataAnnotations;

namespace StarterMicroservice.API
{
    public class MyUser(int userId)
    {
        [Key]
        public int UserId { get; set; } = userId;
    }
}
