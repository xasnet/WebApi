namespace WebClient.SyncDataServices.Http
{
    public interface ICustomerWebClient
    {
        Task<Customer> SendCustomer(CustomerCreateRequest requestCustomer);
        Task<Customer> GetCustomer(long id);
    }
}
