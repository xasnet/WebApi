namespace WebClient
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest(
            string firstName,
            string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public string Firstname { get; init; } = null!;

        public string Lastname { get; init; } = null!;
    }
}
