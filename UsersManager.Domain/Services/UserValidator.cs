using FluentValidation;
using UsersManager.Domain.Entities;

namespace UsersManager.Domain.Services
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty();
            RuleFor(user => user.LastName).NotNull().NotEmpty();
            RuleFor(user => user.Email).NotNull().NotEmpty();
        }
    }
}
