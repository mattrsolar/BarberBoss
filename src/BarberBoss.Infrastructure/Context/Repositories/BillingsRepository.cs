using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.Context.Repositories
{
    internal class BillingsRepository : IBillingsWriteOnlyRepository, IBillingsReadOnlyRepository
    {

        private readonly BarberBossDbContext _dbContext;

        public BillingsRepository(BarberBossDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Billing billing)
        {
            await _dbContext.Billings.AddAsync(billing);
        }

        public async Task<List<Billing>> GetAll()
        {
            return await _dbContext.Billings
                .AsNoTracking()
                .OrderBy(x => x.Date)
                .ToListAsync();

        }
    }
}
