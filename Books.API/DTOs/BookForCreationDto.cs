using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.DTOs
{
    public class BookForCreationDto
    {
        public string Title { get; set; }
        public string CoverPicture { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
