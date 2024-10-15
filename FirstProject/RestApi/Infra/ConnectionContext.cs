using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Models;

namespace RestApi.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "port=5432;Database=employee_sample;" +
                "User Id=postgres;" +
                "Password=root;");
    }
}
