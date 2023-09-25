
namespace build.Domain.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public ICollection<Subtopic> Subtopics { get; set; }
    }
}
