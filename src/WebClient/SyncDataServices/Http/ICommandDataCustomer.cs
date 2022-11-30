namespace WebClient.SyncDataServices.Http
{
    public interface ICommandDataCustomer
    {
        Task<Customer> SendCustomer(CustomerCreateRequest requestCustomer);
        Task<Customer> GetCustomer(long id);
    }
}
