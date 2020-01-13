using Books.ApplicationCore.Interfaces;

namespace Books.ApplicationCore.Entities.BookAggregate
{
    public class BookTag : BaseEntity, IAggregateRoot
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}