using Business.Abstract;
using Core.Aspects.Autofac.Caching;
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

        [CacheRemoveAspect("Business.Abstract.IGenreService.Get")]
        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Abstract.IGenreService.Get")]
        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Abstract.IGenreService.Get")]
        public IResult Delete(Genre genre)
        {
            _genreDal.Delete(genre);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Abstract.IGenreService.Get")]
        public IResult DeleteAll()
        {
            _genreDal.DeleteAll();
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Genre> Get(int id)
        {
            return new SuccessDataResult<Genre>(_genreDal.Get(p => p.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<Genre>> GetAll()
        {
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());
        }
    }
}
