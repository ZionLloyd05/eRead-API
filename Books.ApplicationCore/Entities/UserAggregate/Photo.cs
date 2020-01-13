using Books.ApplicationCore.Interfaces;
using System;

namespace Books.ApplicationCore.Entities.UserAggregate
{
    public class Photo : BaseEntity, IAggregateRoot
    {
        public string url { get; set; }
       // public int UserId { get; set; }
        //public User User { get; set; }
    }
}