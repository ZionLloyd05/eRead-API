using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public List<Book> Books { get; set; }
    }
}
