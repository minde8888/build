namespace build.Domain.Entities
{
    public class Quantity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}
