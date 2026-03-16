using BarberBoss.Application.UseCases.Create;
using BarberBoss.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateBilling(
            [FromServices] ICreateBillingUseCase useCase,
            [FromBody] RequestBillingJson request)
        {
            return Ok();
        }
    }
}
