using BarberBoss.Exception.ExecptionsBase;
using System.Net;

namespace BarberBoss.Exception.ExecptionsBase
{
    public class NotFoundException : BarberBossException
    {

        public NotFoundException(string message) : base(message)
        {

        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return new List<string>()
            {
                Message
            };
        }
    }
}
