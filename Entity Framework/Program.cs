using Entity_Framework.Models;
using Entity_Framework.Repositories;

namespace Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {
                // Пересоздание базы данных для работы с новыми таблицами и связями
                // Если мы пользуемся таким способом
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();


                // Инициализация репозиториев
                var userRepository = new UserRepository(context);
                var bookRepository = new BookRepository(context);
                var authorRepository = new AuthorRepository(context);
                var genreRepository = new GenreRepository(context);

                // Добавление данных
                var romance = new Genre { Name = "Romance" };
                var novel = new Genre { Name = "Novel" };
                var thriller = new Genre { Name = "Thriller" };
                var studentBook = new Genre { Name = "Student book" };
                var history = new Genre { Name = "History" };

                genreRepository.AddGenre(romance);
                genreRepository.AddGenre(novel);
                genreRepository.AddGenre(thriller);
                genreRepository.AddGenre(studentBook);
                genreRepository.AddGenre(history);

                var jamesBonn = new Author { Name = "James Bonn" };
                var kareGray = new Author { Name = "Kare Gray" };
                var voctorFaradei = new Author { Name = "Voctor Faradei" };
                var mikeItem = new Author { Name = "Mike Item" };
                var annaKarenina = new Author { Name = "Anna Karenina" };

                authorRepository.AddAuthor(jamesBonn);
                authorRepository.AddAuthor(kareGray);
                authorRepository.AddAuthor(voctorFaradei);
                authorRepository.AddAuthor(mikeItem);
                authorRepository.AddAuthor(annaKarenina);

                var user1 = new User { Name = "Иванов Иван Иванович", Email = "ivanov.ivan@mail.ru" };
                var user2 = new User { Name = "Бук Василий Петрович", Email = "vasya_buk@mail.ru" };
                var user3 = new User { Name = "Петрова Мария Петровна", Email = "masha_111@mail.ru" };
                var user4 = new User { Name = "Давыдова Екатерина Викторовна", Email = "davidova@mail.ru" };
                var user5 = new User { Name = "Юров Юрий Юрьевич", Email = "yura@mail.ru" };

                userRepository.AddUser(user1);
                userRepository.AddUser(user2);
                userRepository.AddUser(user3);
                userRepository.AddUser(user4);
                userRepository.AddUser(user5);

                var book1 = new Book
                {
                    Title = "Rose in the Worlds",
                    Year = 1992,
                    Author = jamesBonn,
                    Genre = romance,
                    User = user1
                };
                var book2 = new Book
                {
                    Title = "Never say never",
                    Year = 2005,
                    Author = kareGray,
                    Genre = novel,
                    User = user2
                };
                var book3 = new Book
                {
                    Title = "Chasing the beast",
                    Year = 2023,
                    Author = voctorFaradei,
                    Genre = thriller,
                    User = user3
                };
                var book4 = new Book
                {
                    Title = "C# for students",
                    Year = 1997,
                    Author = mikeItem,
                    Genre = studentBook,
                    User = user4
                };
                var book5 = new Book
                {
                    Title = "My dear friend",
                    Year = 2001,
                    Author = annaKarenina,
                    Genre = history,
                    User = user5
                };

                bookRepository.AddBook(book1);
                bookRepository.AddBook(book2);
                bookRepository.AddBook(book3);
                bookRepository.AddBook(book4);
                bookRepository.AddBook(book5);

                // Вывод всех книг с деталями
                Console.WriteLine("Список всех книг с их владельцами, авторами и жанрами:");
                var allBooks = bookRepository.GetAllWithDetails();
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"Книга: {book.Title}, Год: {book.Year}, Автор: {book.Author.Name}, Жанр: {book.Genre.Name}, На руках у: {book.User?.Name ?? "Не на руках"}");
                }

                // Пример: получение количества книг на руках у пользователя
                Console.WriteLine("\nКоличество книг на руках у 'Иванов Иван Иванович':");
                int booksOnUser = userRepository.GetBookCountOnUser(user1.Id);
                Console.WriteLine(booksOnUser);

                // Пример: получение последней вышедшей книги
                Console.WriteLine("\nПоследняя вышедшая книга:");
                var latestBook = bookRepository.GetLatestBook();
                Console.WriteLine($"Книга: {latestBook.Title}, Год: {latestBook.Year}, Автор: {latestBook.Author.Name}");
            }
        }
    }    
}


