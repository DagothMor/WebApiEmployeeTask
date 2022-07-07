using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTask.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask.Bootstrap;
using WebApiTask.Context;
using WebApiTask.Contexts;
using WebApiTask.Repositories;
using WebApiTask.Repositories.Interfaces;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository) {
            employeeRepository = EmployeeRepository;
        }
        /// <summary>
        /// 3. Выводить список сотрудников для указанной компании. Все доступные поля.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpGet("Employee")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesByCompany([FromBody] string company)
        {
            return await employeeRepository.GetAllEmployeesByCompany(company);
        }

        /// <summary>
        /// 4 Выводить список сотрудников для указанного отдела компании. Все доступные поля.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpGet("Employee")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartment([FromBody] string departmentName)
        {
            return await employeeRepository.GetAllEmployeesByDepartment(departmentName);
        }

        /// <summary>
        /// 1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost("Employee")]
        public async Task<string> PostEmployee([FromBody] Employee emp)// employeedto
        {
            return employeeRepository.AddEmployee(emp).ToString();
        }

        /// <summary>
        /// 5 Изменять сотрудника по его Id. Изменения должно быть только тех полей,которые указаны в запросе.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut("Employee")]
        public async Task<IActionResult> Put([FromBody] Employee emp)
        {
            await employeeRepository.ChangeEmployee(emp);
            return NoContent();
        }

        /// <summary>
        /// 2 Удалять сотрудников по Id.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpDelete("Employee")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await employeeRepository.DeleteEmployeeById(id);
            return NoContent();
        }
    }
}
