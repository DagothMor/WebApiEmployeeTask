using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Contexts
{
    public class WebApiTaskContext : DbContext
	{
			/// <summary>
			/// Orders.
			/// </summary>
			public DbSet<Employee> Employees { get; set; }

			/// <summary>
			/// Customers.
			/// </summary>
			public DbSet<Passport> Passports { get; set; }

			/// <summary>
			/// Products.
			/// </summary>
			public DbSet<Department> Departments { get; set; }

			public WebApiTaskContext(DbContextOptions options) : base(options)
			{
			}
		}
	}

