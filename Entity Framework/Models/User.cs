namespace Entity_Framework.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

        // Связь: у пользователя на руках может быть много книг
        public ICollection<Book> Books { get; set; }
    }
}
