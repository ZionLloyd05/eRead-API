using Books.ApplicationCore.Entities.LibraryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Specifications
{
    public sealed class LibraryWithLibraryItemSpecification : BaseSpecification<Library>
    {
        public LibraryWithLibraryItemSpecification(int?  userId)
            : base(l => l.UserId == userId)
        {
            AddInclude(l => l.LibraryItems);
        }
    }
}
