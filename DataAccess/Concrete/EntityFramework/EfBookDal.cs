using System.Linq.Expressions;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, ProjectContext>, IBookDal
    {
        public List<BookDto> GetBookDetails(Expression<Func<Book, bool>> filter = null)
        {
            using var context = new ProjectContext();
            var result = from p in filter == null
                    ? context.Books
                    : context.Books.Where(filter)
                join m in context.Authors on p.AuthorId equals m.Id
                join n in context.Genres on p.GenreId equals n.Id
                select new BookDto
                {
                    Id = p.Id,
                    BookName = p.Name,
                    AuthorFirstName = m.FirstName,
                    AuthorLastName = m.LastName,
                    GenreName = n.Name,
                    BookPhoto = p.BookPhoto
                };
            return result.ToList();
        }
    }
}
