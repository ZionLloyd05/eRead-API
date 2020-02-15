using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Dtos.Book
{
    public class BookForReturnDto
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverPicture { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
