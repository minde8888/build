

namespace build.Domain.Entities
{
    public class Subtopic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
