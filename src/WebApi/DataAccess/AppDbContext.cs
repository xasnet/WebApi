using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}
