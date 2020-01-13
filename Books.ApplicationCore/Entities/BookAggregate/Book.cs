using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string CoverPicture { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
    }
}
