using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Tag : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
    }
}
