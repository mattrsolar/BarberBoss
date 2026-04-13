using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Security.Cryptography;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace BarberBoss.Application.UseCases.User.Create
{
    internal class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            //Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                
                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
