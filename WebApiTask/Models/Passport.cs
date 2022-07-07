using System.ComponentModel.DataAnnotations;
namespace WebApiTask.Models
{
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Number { get; set; }
    }
}

