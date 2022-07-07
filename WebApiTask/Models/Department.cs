using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{

    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<Employee> Employees { get; set; }
    }

}
