﻿using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Tag : BaseEntity, IAggregateRoot
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public ICollection<BookTag> BookTags { get; set; }
    }
}
