using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            var result = _bookService.Update(book);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Book book)
        {
            var result = _bookService.Delete(book); 
            if( result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("deleteall")]
        public IActionResult DeleteAll()
        {
            var result = _bookService.DeleteAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _bookService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if(result.Success)
            {
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpGet("getbookdetails")]
        public IActionResult GetBookDetails()
        {
            var result = _bookService.GetBookDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
