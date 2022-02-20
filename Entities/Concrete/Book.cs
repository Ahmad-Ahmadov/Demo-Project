using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Book :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public byte[] BookPhoto { get; set; }
        public int GenreId { get; set; }   
    }
}
