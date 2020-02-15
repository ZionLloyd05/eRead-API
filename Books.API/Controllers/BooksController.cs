using System;
using System.Threading.Tasks;
using AutoMapper;
using Books.API.DTOs.Book;
using Books.API.Filters;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Books.ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IAsyncRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/books
        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.ListAsync(new BooksWithAuthorSpecification());

            if (books == null || books.Count == 0)
                return NotFound();

            return Ok(books);
        }

        // GET api/books/5
        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        [BookResultFilter]
        public async Task<IActionResult> GetBook(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var book = await _bookRepository.GetByIdAsync(new BookWithAuthorSpecification(id));

            if (book == null)
                return NotFound();

            return Ok(book);
        }


        // POST api/book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookForCreationDto book)
        {
            var bookEntity = _mapper.Map<Book>(book);

            if (!ModelState.IsValid)
                return BadRequest();

            await _bookRepository.AddAsync(bookEntity);

            return CreatedAtRoute("GetBook",
                new { id = bookEntity.Id }, bookEntity);
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
