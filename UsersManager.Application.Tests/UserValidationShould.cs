using UsersManager.Domain.Entities;
using FluentAssertions;

namespace UsersManager.Application.Tests
{
    public class UserValidationShould
    {
        private readonly UserValidator _userValidator = new UserValidator();
        User _userToTest;

        [SetUp]
        public void Setup()
        {
            _userToTest = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                PhoneNumber = "559998930244",
                Aka = "Jhonny"
            };
        }

        [Test]
        public void ReturnErrorWhenFirstNameIsNullOrEmpty()
        {
            //Arrange
            _userToTest.FirstName = "";

            //Act
            var results = _userValidator.Validate(_userToTest);

            //Assert
            results.IsValid.Should().BeFalse();
            results.Errors.Should().Contain(e => e.PropertyName == "FirstName");
        }

        [Test]
        public void ReturnErrorWhenLastNameIsNullOrEmpty()
        {
            //Arrange
            _userToTest.LastName = "";

            //Act
            var results = _userValidator.Validate(_userToTest);

            //Assert
            results.IsValid.Should().BeFalse();
            results.Errors.Should().Contain(e => e.PropertyName == "LastName");
        }

        [Test]
        public void ReturnErrorWhenEmailIsNullOrEmpty()
        {
            //Arrange
            _userToTest.Email = "";

            //Act
            var results = _userValidator.Validate(_userToTest);

            //Assert
            results.IsValid.Should().BeFalse();
            results.Errors.Should().Contain(e => e.PropertyName == "Email");
        }

        [Test]
        public void NotReturnErrorWhenTheRequiredPropertiesAreNotEmpty()
        {
            //Act
            var results = _userValidator.Validate(_userToTest);

            //Assert
            results.IsValid.Should().BeTrue();
            results.Errors.Should().BeNullOrEmpty();
        }
    }
}
