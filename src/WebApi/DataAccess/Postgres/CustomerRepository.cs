using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Interfaces.Repositories;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            await _context.Customers!.AddAsync(customer);
        }

        public async Task<Customer?> GetCustomerByIdAsync(long id)
        {
            return await _context.Customers!.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
