using Books.API.Interfaces;
using Books.API.ViewModels;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Entities.LibraryAggregate;
using Books.ApplicationCore.Interfaces;
using Books.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public class LibraryViewModelService : ILibraryViewModelService
    {
        private readonly IAsyncRepository<Library> _libraryRepository;
        private readonly IAsyncRepository<Book> _bookRepository;

        public LibraryViewModelService(IAsyncRepository<Library> libraryRepository, IAsyncRepository<Book> bookRepository)
        {
            _libraryRepository = libraryRepository;
            _bookRepository = bookRepository;
        }
        public async Task<LibraryViewModel> GetOrCreateLibraryForUser(int userId)
        {
            var librarySpec = new LibraryWithLibraryItemSpecification(userId);

            var library = (await _libraryRepository.ListAsync(librarySpec)).FirstOrDefault();

            if (library == null)
            {
                return await CreateLibraryForUser(userId);
            }

            return await CreateViewModelFromLibrary(library);
        }

        private async Task<LibraryViewModel> CreateLibraryForUser(int userId)
        {
            var library = new Library() { UserId = userId };
            await _libraryRepository.AddAsync(library);

            return new LibraryViewModel()
            {
                ReaderId = library.UserId,
                Id = library.Id,
                Items = new List<LibraryItemViewModel>()
            };
        }

        private async Task<LibraryViewModel> CreateViewModelFromLibrary(Library library)
        {
            var vm = new LibraryViewModel();

            vm.Id = library.Id;
            vm.ReaderId = library.UserId;
            vm.Items = await GetLibraryItems(library.LibraryItems);

            return vm;
        }

        private async Task<List<LibraryItemViewModel>> GetLibraryItems(IReadOnlyCollection<LibraryItem> libraryItems)
        {
            var items = new List<LibraryItemViewModel>();
            foreach (var item in libraryItems)
            {
                var itemModel = new LibraryItemViewModel
                {
                    Id = item.Id,
                    BookId = item.BookId
                };

                var bookWithAuthorAndCategorySpec = new BookWithCategoryAndAuthorSpecification(item.BookId);
                var bookItem = await _bookRepository.GetByIdAsync(bookWithAuthorAndCategorySpec);

                itemModel.BookName = bookItem.Title;
                itemModel.Category = bookItem.Category.Name;
                itemModel.Author = bookItem.Author.Fullname;

                items.Add(itemModel);
            }

            return items;
        }
    }
}
