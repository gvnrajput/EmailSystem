using System.ComponentModel.DataAnnotations;

namespace EmailSystem.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime createdOn { get; set; }
    }
}
