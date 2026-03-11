using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Entities
{
    public class Billing
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string BarberName { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public string Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
