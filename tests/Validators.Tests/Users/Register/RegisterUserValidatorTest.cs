using FluentAssertions;
using BarberBoss.Application.UseCases.Users.Create;
using CommonTestUtilities.Requests;
using BarberBoss.Exception;

namespace Validators.Tests.Users.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Builder();

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();


        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Error_Name_Empty(string name)
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Builder();
            request.Name = name;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));

        }


        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Error_Email_Empty(string email)
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Builder();
            request.Email = email;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));

        }

        [Fact]
        public void Error_Email_Invalid()
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Builder();
            request.Email = "matt.com";

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));

        }

        [Fact]
        public void Error_Password_Empty()
        {
            //Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Builder();
            request.Password = string.Empty;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD));

        }
    }
}
