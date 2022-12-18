namespace WebClient
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest(
            long id,
            string firstName,
            string lastName)
        {
            Id = id;
            Firstname = firstName;
            Lastname = lastName;
        }

        public long Id { get; init; }

        public string Firstname { get; init; } = null!;

        public string Lastname { get; init; } = null!;
    }
}
