﻿using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Books.ApplicationCore.Entities.LibraryAggregate
{
    public class Library : BaseEntity, IAggregateRoot
    {
        public int UserId { get; set; }

        private readonly List<LibraryItem> _libraryItems = new List<LibraryItem>();

        public IReadOnlyCollection<LibraryItem> LibraryItems => _libraryItems.AsReadOnly();
        
        public bool AddLibraryItem(int bookId)
        {
            if (!LibraryItems.Any(i => i.BookId == bookId))
            {
                _libraryItems.Add(new LibraryItem()
                {
                    DateAdded = DateTimeOffset.Now,
                    BookId = bookId
                });
                return true;
            }

            return false;
        }

        public void RemoveLibraryItem(int bookId)
        {
            _libraryItems.RemoveAll(i => i.BookId == bookId);
        }
    }
}
