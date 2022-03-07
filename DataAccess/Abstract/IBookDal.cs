using Core.DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepositoryBase<Book>
    {
        List<BookDto> GetBookDetails(Expression<Func<Book, bool>> filter = null);
    }
}
