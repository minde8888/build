// Ignore Spelling: Dto Dtos


using build.Domain.Entities;

namespace build.Services.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public Topic Topic { get; set; }
    }
}
