using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Book : BaseEntity, IAggregateRoot
    {

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public string CoverPicture { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
    }
}
