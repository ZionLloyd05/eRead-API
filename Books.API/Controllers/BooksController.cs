using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Filters;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IAsyncRepository<Book> _bookRepository;

        public BooksController(IAsyncRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/books
        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.ListAllAsync();

            if (books == null || books.Count == 0)
                return NotFound();

            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        [BookResultFilter]
        public async Task<IActionResult> GetBook(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }


        // POST api/book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book bookObj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newBook = await _bookRepository.AddAsync(bookObj);
            return Ok(newBook);
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
