using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Repositories
{
    public class BookRepository
    {
        private readonly AppContext _appContext;

        public BookRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Book GetBookById(int id)
        {
            return _appContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _appContext.Books.ToList();
        }

        public void AddBook(Book book)
        {
            _appContext.Add(book);
            _appContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);

            if (book != null)
            {
                _appContext.Remove(book);
                _appContext.SaveChanges();
            }
        }

        public void UpdateBookYear(int id, int newYear)
        {
            var book = GetBookById(id);

            if (book != null)
            {
                book.Year = newYear;
                _appContext.SaveChanges();
            }
        }

        //получаем список книг по жанру и диапазону лет
        public IEnumerable<Book> GetBooksByGenreAndYearRange(string genre, int startYear, int endYear)
        {
            return _appContext.Books.Where(b => b.Genre.ToString() == genre && b.Year >= startYear && b.Year <= endYear).ToList();
        }

        //получаем кол-во книг определенного автора
        public int GetBooksCountByAuthor(string author)
        {
            return _appContext.Books.Count(b => b.Author.ToString() == author);
        }

        //получаем кол-во книг определенного жанра
        public int GetBookCountByGenre(string genre)
        {
            return _appContext.Books.Count(b => b.Genre.ToString() == genre);
        }

        //Проверка, есть ли книга определенного автора с конкретным названием
        public bool BookExistsByAuthorAndTitle(string author, string title)
        {
            return _appContext.Books.Any(b => b.Author.ToString() == author && b.Title == title);
        }

        //Проверки: находится ли книга на руках у пользователя

        public bool IsBookCheckedOnUser(int bookId, int userId)
        { 
            return _appContext.Books.Any(b => b.Id == bookId && b.UserId == userId);
        }

        //Кол-во книг на руках у пользователя
        public int GetBooksCountCheckedOnUser(int userId)
        { 
            return _appContext.Books.Count(b => b.UserId == userId);    
        }

        //Получить последнюю вышедшую книгу
        public Book GetLatestBook()
        {
            return _appContext.Books.OrderByDescending(b => b.Year).FirstOrDefault();
        }

        //Получить все книги, отсортированныe в алфавитном порядке по названию
        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            return _appContext.Books.OrderBy(b => b.Title).ToList();
        }

        //Получить все книги в порядке убывания по году выпуска
        public IEnumerable<Book> GetAllBooksSortedByYearDescending()
        {
            return _appContext.Books.OrderByDescending(b => b.Year).ToList();
        }

        public IEnumerable<Book> GetAllWithDetails()
        {
            return _appContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.User)
                .ToList();
        }

        // Новое: Получить книгу с подробностями по ID
        public Book GetBookWithDetailsById(int id)
        {
            return _appContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.User)
                .FirstOrDefault(b => b.Id == id);
        }

        // Новое: Получить книги конкретного автора
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _appContext.Books.Where(b => b.Author.ToString() == author).ToList();
        }
    }
}
