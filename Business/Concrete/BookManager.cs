using Business.Abstract;
using Business.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [CacheRemoveAspect("Business.Abstract.IBookService.Get")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Abstract.IBookService.Get")]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Business.Abstract.IBookService.Get")]
        public IResult DeleteAll()
        {
            _bookDal.DeleteAll();
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Book> Get(int id)
        {
           return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<BookDto>> GetBookDetails()
        {
            return new SuccessDataResult<List<BookDto>>(_bookDal.GetBookDetails());
        }

        [CacheRemoveAspect("Business.Abstract.IBookService.Get")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult();
        }
    }
}
