using Books.ApplicationCore.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Specifications
{
    public sealed class BooksWithAuthorSpecification : BaseSpecification<Book>
    {
        public BooksWithAuthorSpecification()
           : base(null)
        {
            AddInclude(b => b.Author);
        }
    }
}
