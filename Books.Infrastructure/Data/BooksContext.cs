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
            //builder.Entity<Library>(ConfigureLibrary);
            //builder.Entity<Article>(ConfigureArticle);
            //builder.Entity<Comment>(ConfigureComment);
            //builder.Entity<Category>(ConfigureCategory);
            //builder.Entity<BookTag>(ConfigureBookTag);
            //builder.Entity<User>(ConfigureUser);

            //base.OnModelCreating(builder);
        }

        //private void ConfigureBook(EntityTypeBuilder<Book> builder)
        //{
        //    builder.Property(b => b.Title)
        //        .IsRequired()
        //        .HasMaxLength(50);


        //    builder.Property(b => b.Description)
        //        .IsRequired()
        //        .HasMaxLength(200);

        //    builder.Property(b => b.IsVisible)
        //        .HasDefaultValue(true);

        //    builder.HasOne(b => b.Category)
        //        .WithMany(c => c.Books);
        //}

        //private void ConfigureLibrary(EntityTypeBuilder<Library> builder)
        //{
        //    var navigation = builder.Metadata.FindNavigation(nameof(Library.LibraryItems));

        //    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        //}

        //private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        //{
        //    builder.HasMany(c => c.Books)
        //        .WithOne(b => b.Category);
        //}

        //private void ConfigureBookTag(EntityTypeBuilder<BookTag> builder)
        //{
        //    builder.HasKey(bt => new { bt.BookId, bt.TagId });

        //    builder.HasOne(bt => bt.Book)
        //        .WithMany(b => b.BookTags)
        //        .HasForeignKey(bt => bt.BookId);

        //    builder.HasOne(bc => bc.Tag)
        //        .WithMany(t => t.BookTags)
        //        .HasForeignKey(bc => bc.TagId);
        //}

        //private void ConfigureArticle(EntityTypeBuilder<Article> builder)
        //{
        //    builder.HasOne(ar => ar.User)
        //        .WithOne()
        //        .HasForeignKey<User>(u => u.Id);

        //    builder.HasMany(ar => ar.Comments)
        //        .WithOne();
        //}

        //private void ConfigureComment(EntityTypeBuilder<Comment> builder)
        //{
        //    builder.Property(c => c.Message)
        //        .IsRequired()
        //        .HasMaxLength(255);

        //    //builder.HasOne(c => c.User)
        //    //    .WithOne()
        //    //    .HasForeignKey<User>(u => u.Id);
        //}

        //private void ConfigureUser(EntityTypeBuilder<User> builder)
        //{
        //    builder.HasOne(u => u.Photo)
        //        .WithOne(p => p.User)
        //        .HasForeignKey<Photo>(p => p.Id);
        //}
    }
}
