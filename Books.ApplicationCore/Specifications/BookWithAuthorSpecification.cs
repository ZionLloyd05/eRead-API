using Books.ApplicationCore.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Specifications
{
    public sealed class BookWithAuthorSpecification : BaseSpecification<Book>
    {
        public BookWithAuthorSpecification(int? bookId)
            :base(b => b.Id == bookId)
        {
            AddInclude(b => b.Author);
        }
    }
}
