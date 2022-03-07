using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class BookDto :IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string GenreName { get; set; }
        public byte[] BookPhoto { get; set; }
    }
}
