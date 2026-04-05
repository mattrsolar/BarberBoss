using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.User.Create
{
    public interface IRegisterUserUseCase
    {
        async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);

    }
}
