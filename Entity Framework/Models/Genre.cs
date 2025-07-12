namespace Entity_Framework.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Жанр может быть связан с множеством книг
        public ICollection<Book> Books { get; set; }
    }
}
