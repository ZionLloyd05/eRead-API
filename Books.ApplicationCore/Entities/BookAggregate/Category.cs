﻿using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Category : BaseEntity, IAggregateRoot
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public string Slug { get; set; }
        public List<Book> Books { get; set; }
    }
}
