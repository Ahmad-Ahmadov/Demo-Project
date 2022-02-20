using Core.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IResult Add(Author author);
        IResult Update(Author author);
        IResult Delete(Author author);
        IDataResult<Author> Get(int id);
        IDataResult<List<Author>> GetAll();
    }
}
