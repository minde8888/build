
// Ignore Spelling: Dtos Dto

using build.Domain.Entities;

namespace build.Services.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string NsCode { get; set; }
        public string Specification { get; set; }
        public string Units { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Sum { get; set; }
        public ICollection<Doc> Doc { get; set; }
        public ICollection<Checklist> Checklist { get; set; }
        public ICollection<Drawing> Drawing { get; set; }
        public ICollection<Quantity> Quantities { get; set; }
    }
}
