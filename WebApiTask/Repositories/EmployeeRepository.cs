using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask.Context;
using WebApiTask.Models;
using WebApiTask.Repositories.Interfaces;

namespace WebApiTask.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
		private readonly DapperContext _context;

		public EmployeeRepository(DapperContext context)
		{
			_context = context;
		}
		/// <summary>
		/// 5 Изменять сотрудника по его Id. Изменения должно быть только тех полей,которые указаны в запросе.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public async Task ChangeEmployee([FromBody] Employee emp) {

			var getEmployee = "SELECT FROM Employees WHERE Id = @Id";
			var updateEmployee = "UPDATE Companies SET Name = @Name, SurName = @SurName, Phone = @Phone, CompanyId = @CompanyId WHERE Id = @Id";
			using (var connection = _context.CreateConnection())
			{
				var employee = await connection.QuerySingleAsync<Employee>(getEmployee, new { emp.Id });
				if (employee != null)
				{
					var parameters = new DynamicParameters();
					parameters.Add("Id", emp.Id, DbType.Int32);
					parameters.Add("Name", String.IsNullOrEmpty(emp.Name)? employee.Name: emp.Name, DbType.String);
					parameters.Add("SurName", String.IsNullOrEmpty(emp.Surname) ? employee.Surname : emp.Surname, DbType.String);
					parameters.Add("Phone", String.IsNullOrEmpty(emp.Phone) ? employee.Phone : emp.Phone, DbType.String);
					parameters.Add("CompanyId", String.IsNullOrEmpty(emp.CompanyId.ToString()) ? employee.CompanyId : emp.CompanyId, DbType.Int32);
					await connection.ExecuteAsync(updateEmployee, parameters);
				}
			}
		}
		/// <summary>
		/// 4 Выводить список сотрудников для указанного отдела компании. Все доступные поля.
		/// </summary>
		/// <param name="departmentName"></param>
		/// <returns></returns>
		public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartment([FromBody] string departmentName)
		{
			var query = "SELECT FROM Departments WHERE Name = @departmentName;" +
				"SELECT * FROM Employees WHERE DepartmentId = @Id";
			using (var connection = _context.CreateConnection())
			using (var multi = await connection.QueryMultipleAsync(query, new { departmentName }))
			{
				var department = await multi.ReadSingleOrDefaultAsync<Department>();
				if (department != null)
					return await multi.ReadAsync<Employee>();
			}
			return null;
		}

		/// <summary>
		/// 3. Выводить список сотрудников для указанной компании. Все доступные поля.
		/// </summary>
		/// <param name="companyId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<Employee>> GetAllEmployeesByCompany([FromBody] string companyId)
		{
			var query = "SELECT * FROM Employees WHERE CompanyId = @companyId";
			using (var connection = _context.CreateConnection())
			{
				var employees = await connection.QueryAsync<Employee>(query, new { companyId });
				if (employees != null)
					return employees;
				return null;
			}
		}
		/// <summary>
		/// 1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public async Task<string> AddEmployee([FromBody] Employee emp)
		{
			var query = "INSERT INTO Employees (Name, Surname, Phone, CompanyId) VALUES (@Name, @Surname, @Phone, @CompanyId)" +
			"SELECT CAST(SCOPE_IDENTITY() as int)";
			var parameters = new DynamicParameters();
			parameters.Add("Name", emp.Name, DbType.String);
			parameters.Add("Surname", emp.Surname, DbType.String);
			parameters.Add("Phone", emp.Phone, DbType.String);
			parameters.Add("CompanyId", emp.CompanyId, DbType.Int32);

			using (var connection = _context.CreateConnection())
			{
				var id = await connection.QuerySingleAsync<int>(query, parameters);

				var createdEmployee = new Employee
				{
					Id = id,
					Name = emp.Name,
					Surname = emp.Surname,
					Phone = emp.Phone,
					CompanyId = emp.CompanyId
				};

				return id.ToString();
			}
		}
		/// <summary>
		/// 2 Удалять сотрудников по Id.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public async Task DeleteEmployeeById(int id)
		{
			var query = "DELETE FROM Employees WHERE Id = @Id";

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, new { id });
			}
		}
	}
}
