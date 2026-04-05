using BarberBoss.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss.Domain.Entities
{
    public class Billing
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        [Required]
        public string BarberName { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
