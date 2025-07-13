using UsersManager.Domain.Entities;
using UsersManager.Domain.Interfaces;

namespace UsersManager.Domain.Services
{
    public class UsersService : IUsersService
    {
        private static List<User> users = new List<User>();

        public List<User> GetUsers()
        {
            return users;
        }

        public User? GetUserById(Guid userId)
        {
            return users.FirstOrDefault(u => u.Id == userId);
        }

        public void AddUser(User newUser)
        {
            users.Add(newUser);
        }

        public void UpdateUser(Guid id, User user)
        {
            var userToUpdate = users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate != null)
                userToUpdate.Name = user.Name;
            else
                throw new Exception();
        }

        public void DeleteUser(Guid userId)
        {
            var userToDelete = users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
                users.Remove(userToDelete);
        }
    }
}
