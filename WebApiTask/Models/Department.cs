using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{

    public class Department
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }

}
