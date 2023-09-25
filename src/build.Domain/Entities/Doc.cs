
namespace build.Domain.Entities
{
    public class Doc
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
