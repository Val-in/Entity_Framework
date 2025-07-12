using Entity_Framework.Models;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Framework.Repositories
{
    public class AuthorRepository
    {
        private readonly AppContext _appContext;

        public AuthorRepository(AppContext context)
        {
            _appContext = context;
        }

        public void AddAuthor(Author author)
        {
            _appContext.Authors.Add(author);
            _appContext.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _appContext.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _appContext.Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}
