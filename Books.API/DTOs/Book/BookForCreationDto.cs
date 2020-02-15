using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.DTOs.Book
{
    public class BookForCreationDto
    {

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public string CoverPicture { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
