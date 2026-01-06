using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using UsersManager.Domain.Entities;
using UsersManager.Domain.Interfaces;
using UsersManager.Domain.Services;

namespace UsersManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUsersService service) : ControllerBase
    {
        UserValidator userValidator = new UserValidator();

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
        public string? Add(User user)
        {
            if (user != null)
            {
                ValidationResult results = userValidator.Validate(user);

                if (!results.IsValid)
                {
                    return results.ToString(" / ");
                }

                service.AddUser(user);
                return "Created!";
            };
            return "Null user";
        }

        [HttpPut("{id}")]
        public string? Update(Guid id, User user)
        {
            ValidationResult results = userValidator.Validate(user);

            if (!results.IsValid)
            {
                return results.ToString(" / ");
            }

            service.UpdateUser(id, user);
            return "Updated!";
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            service.DeleteUser(id);
        }
    }
}
