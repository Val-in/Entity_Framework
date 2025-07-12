namespace Entity_Framework.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // У автора может быть множество книг
        public ICollection<Book> Books { get; set; }
    }
}
