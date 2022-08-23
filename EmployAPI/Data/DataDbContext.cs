using EmployAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users{ get; set; }
    }
}
