using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.LibraryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Entities.BookAggregate;

namespace Books.Infrastructure.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {

        }
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Book>(ConfigureBook);
            builder.Entity<Library>(ConfigureLibrary);
            //builder.Entity<Article>(ConfigureArticle);
            //builder.Entity<Comment>(ConfigureComment);
            //builder.Entity<Category>(ConfigureCategory);
            //builder.Entity<BookTag>(ConfigureBookTag);
            //builder.Entity<User>(ConfigureUser);

            base.OnModelCreating(builder);
        }

        private void ConfigureLibrary(EntityTypeBuilder<Library> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Library.LibraryItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
