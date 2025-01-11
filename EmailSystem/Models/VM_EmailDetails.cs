using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmailSystem.Models
{
    public class VM_EmailDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        public string Cc { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsAttachment { get; set; }

        public DateTime? SentDateTime { get; set; }
    }
}
