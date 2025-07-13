using UsersManager.Domain.Entities;

namespace UsersManager.Domain.Interfaces
{
    public interface IUsersService
    {
        List<User> GetUsers();
        User? GetUserById(Guid userId);
        void AddUser(User newUser);
        void UpdateUser(Guid id, User user);
        void DeleteUser(Guid userId);
    }
}