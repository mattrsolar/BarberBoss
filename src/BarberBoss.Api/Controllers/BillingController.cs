using BarberBoss.Application.UseCases.Create;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateBillingJson), StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBillingAsync(
            [FromServices] ICreateBillingUseCase useCase,
            [FromBody] RequestBillingJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
