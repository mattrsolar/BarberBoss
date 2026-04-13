using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Domain.Security.Cryptography;
using BarberBoss.Domain.Security.Tokens;
using BarberBoss.Exception.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberBoss.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repo;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(IUserReadOnlyRepository repo, 
            IPasswordEncripter passwordEncripter, 
            IAccessTokenGenerator accessTokenGenerator)
        {
            _repo = repo;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;

        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repo.GetUserByEmail(request.Email);

            if (user is null) {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if (!passwordMatch) {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };  

        }

    }
}
