using Books.ApplicationCore.Entities.LibraryAggregate;
using Books.ApplicationCore.Interfaces;
using Books.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.ApplicationCore.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAsyncRepository<Library> _libraryRepository;
        private readonly IAppLogger<LibraryService> _logger;

        public LibraryService(IAsyncRepository<Library> libraryRepository, IAppLogger<LibraryService> logger)
        {
            _libraryRepository = libraryRepository;
            _logger = logger;
        }

        public async Task<bool> AddBookToLibrary(int libraryId, int bookId)
        {
            // get library
            var library = await _libraryRepository.GetByIdAsync(libraryId);

            // add item to library
            if (library == null)
            {
                _logger.LogWarning($"Library was not found");
                return false;
            }

            var result = library.AddLibraryItem(bookId);

            if (!result)
            {
                return result;
            }

            //update library
            await _libraryRepository.UpdateAsync(library);

            return result;
           }


        public async Task<bool> RemoveBookFromLibrary(int libraryId, int bookId)
        {
            // get library
            var library = await _libraryRepository.GetByIdAsync(libraryId);

            // add item to library
            if (library == null)
            {
                _logger.LogWarning($"Library was not found");
                return false;
            }

            library.RemoveLibraryItem(bookId); 

            //update library
            await _libraryRepository.UpdateAsync(library);

            return true;
        }

        public async Task<bool> DeleteLibrary(int libraryId)
        {
            var library = await _libraryRepository.GetByIdAsync(libraryId);
            if (library == null)
            {
                _logger.LogWarning($"Library was not found");
                return false;
            }

            await _libraryRepository.DeleteAsync(library);
            return true;
        }

        public async Task<int> GetLibraryItemCountAsync(int? userId)
        {
            if(userId == null)
            {
                return 0;
            }

            var librarySpec = new LibraryWithLibraryItemSpecification(userId);

            var library = (await _libraryRepository.ListAsync(librarySpec)).FirstOrDefault();
            if(library == null)
            {
                _logger.LogWarning($"No library found for user {userId}");
                return 0;
            }

            int count = library.LibraryItems.Sum(b => b.Id);
            _logger.LogInformation($"Library for {userId}");

            return count;
        }
    }
}
