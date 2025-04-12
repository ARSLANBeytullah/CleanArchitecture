using CleanArchitecture.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
