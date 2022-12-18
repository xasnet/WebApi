using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace WebClient.SyncDataServices.Http
{
    public class CustomerWebClient : ICustomerWebClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CustomerWebClient(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public Task GetCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> SendCustomer(CustomerCreateRequest requestCustomer)
        {
            if (requestCustomer is null)
            {
                throw new ArgumentNullException(nameof(requestCustomer));
            }

            var httpContent = new StringContent(
                JsonSerializer.Serialize(requestCustomer),
                Encoding.UTF8,
                "application/json");

            var requestUri = _configuration["CreateCustomerUrl"];

            using (HttpResponseMessage response = await _httpClient.PostAsync(requestUri, httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"--> Sync POST to {requestUri} was OK!");

                    var customer = await response.Content.ReadAsAsync<Customer>();

                    return customer;
                }
                else
                {
                    Console.WriteLine($"--> Sync POST to {requestUri} was FAILED!");
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Customer> GetCustomer(long id)
        {
            var requestUri = _configuration["GetCustomerUrl"] + id.ToString();

            using (HttpResponseMessage response = await _httpClient.GetAsync($"{requestUri}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"--> Sync GET to {requestUri} was OK!");

                    var customer = await response.Content.ReadAsAsync<Customer>();

                    return customer;
                }
                else
                {
                    Console.WriteLine($"--> Sync GET to {requestUri} was FAILED!");
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
