using UsersManager.Domain.Entities;

namespace UsersManager.Domain.Interfaces
{
    public interface IUsersService
    {
        List<User> GetUsers();
        User? GetUserById(Guid userId);
        void AddUser(string userName);
        void UpdateUser(Guid id, string userName);
        void DeleteUser(Guid userId);
    }
}