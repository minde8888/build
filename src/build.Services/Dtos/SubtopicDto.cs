// Ignore Spelling: Dtos Dto

namespace build.Services.Dtos
{
    public class SubtopicDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public ICollection<PostDto> Posts { get; set; }
    }
}
