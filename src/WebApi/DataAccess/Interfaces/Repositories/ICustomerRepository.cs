using WebApi.Models;

namespace WebApi.DataAccess.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task SaveChangesAsync();

        Task<Customer?> GetCustomerByIdAsync(long id);
        Task CreateCustomerAsync(Customer customer);
    }
}
