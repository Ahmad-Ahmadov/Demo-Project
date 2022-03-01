using Core.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGenreService
    {
        IResult Add(Genre genre);
        IResult Update(Genre genre);
        IResult Delete(Genre genre);
        IResult DeleteAll();
        IDataResult<Genre> Get(int id);
        IDataResult<List<Genre>> GetAll();
    }
}
