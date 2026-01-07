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
            newUser.Id = Guid.NewGuid();
            users.Add(newUser);
        }

        public void UpdateUser(Guid id, User user)
        {
            var userToUpdate = users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.PhoneNumber = user.PhoneNumber;
                userToUpdate.Aka = user.Aka;
            }
            else
                throw new NullReferenceException();
        }

        public void DeleteUser(Guid userId)
        {
            var userToDelete = users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete is null)
            {
                throw new NullReferenceException();
            }

            users.Remove(userToDelete);
        }
    }
}
