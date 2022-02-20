using Core.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
        IDataResult<Book> Get(int id);
        IDataResult<List<Book>> GetAll();
    }
}
