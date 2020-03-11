using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.ViewModels
{
    public class LibraryItemViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
