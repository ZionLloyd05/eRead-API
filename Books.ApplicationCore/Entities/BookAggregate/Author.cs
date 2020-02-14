using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class Author : BaseEntity, IAggregateRoot
    {
        [Required]
        [MaxLength(150)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(150)]
        public string Lastname { get; set; }
    }
}
