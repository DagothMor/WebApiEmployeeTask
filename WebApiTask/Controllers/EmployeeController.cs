using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// 3. Выводить список сотрудников для указанной компании. Все доступные поля.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpGet("Employee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        public async Task<IActionResult> GetAllEmployeesByCompany([FromBody] string company)// employeedto
        {
            var test = company;
            return Ok();
        }

        /// <summary>
        /// 4 Выводить список сотрудников для указанного отдела компании. Все доступные поля.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpGet("Employee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        public async Task<IActionResult> GetAllEmployeesByDepartment([FromBody] Department department)// employeedto
        {
            var test = department;
            return Ok();
        }

        /// <summary>
        /// 1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost("Employee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public async Task<IActionResult> PostEmployee([FromBody] Employee emp)// employeedto
        {
            var test = emp;
            return Ok();
        }

        /// <summary>
        /// 5 Изменять сотрудника по его Id. Изменения должно быть только тех полей,которые указаны в запросе.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut("Employee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public async Task<IActionResult> Put([FromBody] Employee emp)// employeedto
        {
            var name = emp.Name;
            var department = emp.Department;
            var test = emp;
            // var test =dbcontext.firstdef(n=>n.id == emp.id)
            // test = emp
            // dbcontext.save
            return Ok();
        }

        /// <summary>
        /// 2 Удалять сотрудников по Id.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpDelete("Employee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] int id)// employeedto
        {
            var test = id;
            return NoContent();
        }
    }
}
