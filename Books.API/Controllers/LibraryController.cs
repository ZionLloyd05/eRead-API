using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Interfaces;
using Books.API.ViewModels;
using Books.ApplicationCore.Entities.LibraryAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly ILibraryViewModelService _libraryViewModelService;

        public LibraryController(
            ILibraryService libraryService,
            ILibraryViewModelService libraryViewModelService
            )
        {
            _libraryService = libraryService;
            _libraryViewModelService = libraryViewModelService;
        }

        public LibraryViewModel LibraryModel { get; set; } = new LibraryViewModel();

        [HttpGet("{userId}")]
        // Get api/library/5
        public async Task<IActionResult> GetLibrary(int userId)
        {

            await SetLibraryModelAsync(userId);
            return Ok(LibraryModel);
        }

        [HttpPost("{userId}/{bookId}")]
        public async Task<IActionResult> PostBook(int userId, int bookId)
        {
            await SetLibraryModelAsync(userId);

             var isAdded = await _libraryService.AddBookToLibrary(LibraryModel.Id, bookId);

            await SetLibraryModelAsync(userId);

            if (!isAdded)
            {
                return BadRequest("Book already exist in the Library.");
            }

            return Ok();
        }

        [HttpDelete("{userId}/{bookId}")]
        public async Task<IActionResult> DeleteBookFromLibrary(int userId, int bookId)
        {
            await SetLibraryModelAsync(userId);

            var isRemoved= await _libraryService.RemoveBookFromLibrary(LibraryModel.Id, bookId);

            await SetLibraryModelAsync(userId);

            if (!isRemoved)
            {
                return BadRequest("Library not found.");
            }

            return Ok();
        }
        
        public async Task SetLibraryModelAsync(int userId)
        {
            LibraryModel = await _libraryViewModelService.GetOrCreateLibraryForUser(userId);
        }
    }
}
