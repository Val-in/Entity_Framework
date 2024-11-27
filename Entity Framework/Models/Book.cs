namespace Entity_Framework.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        // Связь с автором
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        // Связь с жанром
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        // Связь: книга может быть взята на руки пользователем. 
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
