using Microsoft.AspNetCore.Mvc;
using UsersManager.Domain.Entities;

namespace UsersManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersManager usersManager = new UsersManager();

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return usersManager.GetUsers();
        }

        [HttpGet("{id}")]
        public User? GetUser(Guid id)
        {
            return usersManager.GetUserById(id);
        }

        [HttpPost]
        public void Add(User user)
        {
            usersManager.AddUser(user);
        }

        [HttpPut("{id}")]
        public void Update(Guid id, User user)
        {
            usersManager.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            usersManager.DeleteUser(id);
        }
    }
}
