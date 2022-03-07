using Core.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
        IResult DeleteAll();
        IDataResult<Book> Get(int id);
        IDataResult<List<Book>> GetAll();
        IDataResult<List<BookDto>> GetBookDetails();
    }
}
