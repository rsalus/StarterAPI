using System.ComponentModel.DataAnnotations;

namespace StarterAPI
{
    public class MyUser(int userId)
    {
        [Key]
        public int UserId { get; set; } = userId;
    }
}
