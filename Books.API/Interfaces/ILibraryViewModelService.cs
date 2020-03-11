using Books.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Interfaces
{
    public interface ILibraryViewModelService
    {
        Task<LibraryViewModel> GetOrCreateLibraryForUser(int userId);
    }
}
