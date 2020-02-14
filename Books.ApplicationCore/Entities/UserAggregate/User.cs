using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Books.ApplicationCore.Entities.UserAggregate
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Photo Photo { get; set; }
        public string Role { get; set;}
    }
}