namespace BarberBoss.Communication.Responses
{
    public class ResponseCreateBillingJson
    {
        public DateOnly Date { get; set; }
        public string BarberName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;

    }
}
