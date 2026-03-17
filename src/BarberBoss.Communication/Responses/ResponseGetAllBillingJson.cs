using System;
using System.Collections.Generic;
using System.Text;

namespace BarberBoss.Communication.Responses
{
    public class ResponseGetAllBillingJson
    {
        public List<ResponseShortGetAllBillingJson> Billings { get; set; } = [];
    }
}
