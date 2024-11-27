using Entity_Framework.Models;

namespace Entity_Framework.Repositories
{
    public class GenreRepository
    {
        private readonly AppContext _appContext;

        public GenreRepository(AppContext context)
        {
            _appContext = context;
        }

        public void AddGenre(Genre genre)
        {
            _appContext.Genres.Add(genre);
            _appContext.SaveChanges();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _appContext.Genres.ToList();
        }//Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while saving the entity changes. See the inner exception for details.'


        public Genre GetGenreById(int id)
        {
            return _appContext.Genres.FirstOrDefault(g => g.Id == id);
        }
    }
}

