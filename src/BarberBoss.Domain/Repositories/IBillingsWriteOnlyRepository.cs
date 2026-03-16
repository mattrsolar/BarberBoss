using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories
{
    public interface IBillingsWriteOnlyRepository
    {
        Task Add(Billing billing);
    }
}
