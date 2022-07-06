using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost("Employee")]
        public IEnumerable<Employee> Post([FromBody] Employee emp)// employeedto
        {
            var test = emp;
            return new List<Employee>();
        }
    }
}
