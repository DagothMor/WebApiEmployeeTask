using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public int PassportId { get; set; }
        public int DepartmentId { get; set; }
    }
}
