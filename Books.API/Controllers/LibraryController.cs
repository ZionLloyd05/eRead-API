using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.ApplicationCore.Entities.LibraryAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IAsyncRepository<Library> _libraryRepository;

        public LibraryController(IAsyncRepository<Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet()]
        // Get api/library
        public async Task<IActionResult> MyLibrary()
        {
            return Ok();
        }

        [HttpPost]


    }
}
