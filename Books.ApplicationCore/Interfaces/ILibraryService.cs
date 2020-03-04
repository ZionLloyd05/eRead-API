using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.ApplicationCore.Interfaces
{
    public interface ILibraryService
    {
        Task<int> GetLibraryItemCountAsync(int? userId);
        Task<bool> AddBookToLibrary(int libraryId, int bookId);
        Task<bool> RemoveBookFromLibrary(int libraryId, int bookId);
        Task<bool> DeleteLibrary(int libraryId);
    }
}
