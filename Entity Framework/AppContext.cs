using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        // Объекты таблицы Authors
        public DbSet<Author> Authors { get; set; }

        // Объекты таблицы Genres
        public DbSet<Genre> Genres { get; set; }

        //public AppContext()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().ToTable("genres");
            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Genre>().Property(g => g.Id).HasColumnName("id");
            modelBuilder.Entity<Genre>().Property(g => g.Name).HasColumnName("name");
            modelBuilder.Entity<Author>().Property(g => g.Id).HasColumnName("id");
            modelBuilder.Entity<Author>().Property(g => g.Name).HasColumnName("name");
            modelBuilder.Entity<Book>().Property(g => g.Id).HasColumnName("id");
            modelBuilder.Entity<Book>().Property(g => g.Title).HasColumnName("title");
            modelBuilder.Entity<Book>().Property(g => g.Year).HasColumnName("year");
            modelBuilder.Entity<Book>().Property(g => g.AuthorId).HasColumnName("authorid");
            modelBuilder.Entity<Book>().Property(g => g.GenreId).HasColumnName("genreid");
            modelBuilder.Entity<Book>().Property(g => g.UserId).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(g => g.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(g => g.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(g => g.Email).HasColumnName("email");

            // Дополнительные настройки связей (при необходимости)
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=postgres2");
        }
    }
}

