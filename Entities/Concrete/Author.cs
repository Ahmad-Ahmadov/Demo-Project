using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] AuthorPhoto { get; set; }
    }
}
