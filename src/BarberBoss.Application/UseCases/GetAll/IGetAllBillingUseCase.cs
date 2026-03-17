using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.GetAll
{
    public interface IGetAllBillingUseCase
    {
        Task<ResponseGetAllBillingJson> Execute();

    }
}
