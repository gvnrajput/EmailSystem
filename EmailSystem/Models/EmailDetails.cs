using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmailSystem.Models
{
    public class EmailDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; } 

        [Required]
        public int From { get; set; } 

        [Required]
        public int To { get; set; }

        public int Cc { get; set; } 

        [StringLength(200)]
        public string Subject { get; set; } 

        public string Body { get; set; } 

        public bool IsAttachment { get; set; } 

        public DateTime? SentDateTime { get; set; }
    }
}
