using Books.ApplicationCore.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Specifications
{
    public sealed class BookWithCategoryAndAuthorSpecification : BaseSpecification<Book>
    {
        public BookWithCategoryAndAuthorSpecification(int? bookId)
            :base(b => b.Id == bookId)
        {
            AddInclude(b => b.Category);
            AddInclude(b => b.Author);
        }
    }
}
