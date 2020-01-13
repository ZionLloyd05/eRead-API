using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Entities
{
    public class Comment: BaseEntity, IAggregateRoot
    {
        public string Message { get; set; }
        public bool IsApproved { get; set; }
      //  public Guid UserId { get; set; }
        public User User { get; set; }
        public int Claps { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public Comment()
        {
            this.Claps = 0;
            this.IsApproved = false;
        }
    }
}
