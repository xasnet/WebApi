using Microsoft.Extensions.Configuration;
using WebClient;
using WebClient.SyncDataServices.Http;


#region Configuration

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
#endregion


#region Main menu
var menuList = new List<string>();
menuList.Add("1. Get customer by Id");
menuList.Add("2. Generate and save new customer");
menuList.Add("3. Exit");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Main Menu:");
    foreach (var item in menuList)
    {
        Console.WriteLine($"{item}");
    }

    Console.WriteLine();
    Console.WriteLine("Enter menu number (1,2,3): ");

    var menuItem = Console.ReadLine()!.Trim();

    if (!menuList.Select(m => m.Substring(0, 1)).Contains(menuItem.ToLower()))
    {
        Console.WriteLine($"Enter correct menu number!");
        continue;
    }

    if (menuItem == "1")
    {
        while (true)
        {
            Console.WriteLine("Enter customer Id: ");
            var customerId = Console.ReadLine()!.Trim();

            if (Int64.TryParse(customerId, out var id))
            {
                try
                {
                    var getCustomer = await new CustomerWebClient(config).GetCustomer(id);

                    Console.WriteLine();
                    Console.WriteLine("Customer:");

                    Table<Customer>.Create(getCustomer);

                    Console.WriteLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error finding customer by Id. Error message: {ex.Message}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Enter correct customer id!");
            }
        }
    }
    else if (menuItem == "2")
    {
        var firstName = StringGeneration.Create();
        var lastName = StringGeneration.Create();

        while (true)
        {
            Console.WriteLine("Enter customer Id: ");
            var customerId = Console.ReadLine()!.Trim();

            if (Int64.TryParse(customerId, out var id))
            {
                var newGenCustomer = new CustomerCreateRequest(id, firstName, lastName);
                Console.WriteLine($"Generated customer: Id = {newGenCustomer.Id}, FirstName = {newGenCustomer.Firstname}, LastName = {newGenCustomer.Lastname}");

                try
                {
                    var createdCustomer = await new CustomerWebClient(config).SendCustomer(newGenCustomer);

                    Console.WriteLine();
                    Console.WriteLine("Created customer:");

                    Table<Customer>.Create(createdCustomer);

                    Console.WriteLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error creating customer by Id. Error message: {ex.Message}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Enter correct customer id!");
            }
        }
    }
    else //Exit
    {
        break;
    }
}
#endregion