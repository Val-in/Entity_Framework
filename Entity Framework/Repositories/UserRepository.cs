using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Repositories
{
    public class UserRepository
    {
        private readonly AppContext _appContext;

        public UserRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public User GetUserById(int id)
        {
            return _appContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _appContext.Add(user);
            _appContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);

            if (user != null)
            {
                _appContext.Users.Remove(user);
                _appContext.SaveChanges();
            }
        }

        public void UpdateUserName(int id, string newName)
        {
            var user = GetUserById(id);
            if (user != null)
            { 
                user.Name = newName;
                _appContext.SaveChanges();
            }
        }

        // Новое: Получить пользователя вместе с книгами
        public User GetUserWithBooks(int id)
        {
            return _appContext.Users
                .Include(u => u.Books)
                .FirstOrDefault(u => u.Id == id);
        }

        // Новое: Получить количество книг, находящихся на руках у пользователя
        public int GetBookCountOnUser(int userId)
        {
            return _appContext.Books.Count(b => b.UserId == userId);
        }
    }
}
