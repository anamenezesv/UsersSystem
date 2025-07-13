using Microsoft.AspNetCore.Mvc;
using UsersManager.Domain.Entities;
using UsersManager.Domain.Interfaces;

namespace UsersManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUsersService service) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return service.GetUsers();
        }

        [HttpGet("{id}")]
        public User? GetUser(Guid id)
        {
            return service.GetUserById(id);
        }

        [HttpPost]
        public void Add(User user)
        {
            service.AddUser(user);
        }

        [HttpPut("{id}")]
        public void Update(Guid id, User user)
        {
            service.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            service.DeleteUser(id);
        }
    }
}
