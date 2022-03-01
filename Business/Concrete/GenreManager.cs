using Business.Abstract;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult();
        }

        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult();
        }

        public IResult Delete(Genre genre)
        {
            _genreDal.Delete(genre);
            return new SuccessResult();
        }

        public IResult DeleteAll()
        {
            _genreDal.DeleteAll();
            return new SuccessResult();
        }

        public IDataResult<Genre> Get(int id)
        {
            return new SuccessDataResult<Genre>(_genreDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Genre>> GetAll()
        {
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());
        }
    }
}
