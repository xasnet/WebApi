namespace WebApi.Dtos
{
    public class CustomerReadDto
    {
        public long Id { get; init; }

        public string Firstname { get; init; } = null!;

        public string Lastname { get; init; } = null!;
    }
}
