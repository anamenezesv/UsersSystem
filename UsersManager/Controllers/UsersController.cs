using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using UsersManager.Application;
using UsersManager.Domain.Entities;
using UsersManager.Domain.Interfaces;

namespace UsersManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUsersService service) : ControllerBase
    {
        UserValidator userValidator = new UserValidator();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            User? user = service.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            ValidationResult results = userValidator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            service.AddUser(user);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, User user)
        {
            ValidationResult results = userValidator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }
            
            try
            {
                service.UpdateUser(id, user);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                service.DeleteUser(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}
