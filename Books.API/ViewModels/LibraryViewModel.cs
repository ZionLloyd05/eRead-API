using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.ViewModels
{
    public class LibraryViewModel
    {
        public int Id { get; set; }
        public List<LibraryItemViewModel> Items { get; set; }
        public int ReaderId { get; set; }
    }
}
