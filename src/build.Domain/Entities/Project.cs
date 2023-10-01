
namespace build.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; }
    }
}
