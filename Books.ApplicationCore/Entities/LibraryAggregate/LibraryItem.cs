using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Entities.LibraryAggregate
{
    public class LibraryItem : BaseEntity
    {
        public int BookId { get; set; }
        public int LibraryId { get; private set; }
        public DateTimeOffset DateAdded { get; set; }
    }
}
