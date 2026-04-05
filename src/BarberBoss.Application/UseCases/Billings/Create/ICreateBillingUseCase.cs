using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billings.Create
{
    public interface ICreateBillingUseCase
    {
        Task<ResponseCreateBillingJson> Execute(RequestBillingJson request);
    }
}
