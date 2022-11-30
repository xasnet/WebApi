namespace WebApi.Dtos
{
    public class CustomerReadDto
    {
        public long Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; init; } = null!;
    }
}
