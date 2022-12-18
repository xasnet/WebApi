namespace WebApi.Dtos
{
    public class CustomerCreateDto
    {
        public long Id { get; init; }

        public string Firstname { get; init; } = null!;

        public string Lastname { get; init; } = null!;
    }
}
