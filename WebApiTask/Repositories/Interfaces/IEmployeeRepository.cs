using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask.Context;
using WebApiTask.Models;
using WebApiTask.Repositories.Interfaces;

namespace WebApiTask.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// 1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        Task<string> AddEmployee([FromBody] Employee emp);

        /// <summary>
        /// 3. Выводить список сотрудников для указанной компании. Все доступные поля.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAllEmployeesByCompany([FromBody] string companyId);

        /// <summary>
        /// 4 Выводить список сотрудников для указанного отдела компании. Все доступные поля.
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAllEmployeesByDepartment([FromBody] string departmentName);

        /// <summary>
		/// 2 Удалять сотрудников по Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteEmployeeById(int id);

        /// <summary>
		/// 5 Изменять сотрудника по его Id. Изменения должно быть только тех полей,которые указаны в запросе.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		Task ChangeEmployee([FromBody] Employee emp);

    }
}
