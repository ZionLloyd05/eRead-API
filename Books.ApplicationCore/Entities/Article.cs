using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Entities
{
    public class Article : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int Claps { get; set; }
      //  public Guid UserId { get; set; }

     //   public User User { get; set; }

        private readonly List<Comment> _comments = new List<Comment>();

        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    }
}
