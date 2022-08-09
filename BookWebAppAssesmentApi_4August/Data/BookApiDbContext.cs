using BookWebAppAssesmentApi_4August.Model;
using Microsoft.EntityFrameworkCore;

namespace BookWebAppAssesmentApi_4August.Data
{
    public class BookApiDbContext : DbContext
    {
        public DbSet<Books> Books { set; get; }


        public BookApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Books>().HasIndex(book => book.BookName).IsUnique();


        }
    }
}
