using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.Context
{
    public class BarberBossDbContext : DbContext
    {
        public BarberBossDbContext(DbContextOptions<BarberBossDbContext> options) : base(options)
        {
        }
        public DbSet<Billing> Billings { get; set; }
    }
}
