using LibraryShared.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Инициализация начальных данных
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Война и мир", Genre = "Роман", Author = "Лев Толстой", YearPublished = 1869 },
                new Book { Id = 2, Title = "Преступление и наказание", Genre = "Роман", Author = "Фёдор Достоевский", YearPublished = 1866 },
                new Book { Id = 3, Title = "Мастер и Маргарита", Genre = "Роман", Author = "Михаил Булгаков", YearPublished = 1940 },
                new Book { Id = 4, Title = "Евгений Онегин", Genre = "Поэма", Author = "Александр Пушкин", YearPublished = 1833 },
                new Book { Id = 5, Title = "Отцы и дети", Genre = "Роман", Author = "Иван Тургенев", YearPublished = 1862 },
                new Book { Id = 6, Title = "Анна Каренина", Genre = "Роман", Author = "Лев Толстой", YearPublished = 1877 },
                new Book { Id = 7, Title = "Тихий Дон", Genre = "Роман", Author = "Михаил Шолохов", YearPublished = 1940 },
                new Book { Id = 8, Title = "Доктор Живаго", Genre = "Роман", Author = "Борис Пастернак", YearPublished = 1957 },
                new Book { Id = 9, Title = "Герой нашего времени", Genre = "Роман", Author = "Михаил Лермонтов", YearPublished = 1840 },
                new Book { Id = 10, Title = "Чевенгур", Genre = "Роман", Author = "Андрей Платонов", YearPublished = 1929 }
            );
        }
    }
}
