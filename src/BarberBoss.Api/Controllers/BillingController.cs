using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Application.UseCases.Billings.GetAll;
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

        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetAllBillingJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllBillingsAsync(
            [FromServices] IGetAllBillingUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Billings.Count == 0)
                return NoContent();

            return Ok(response);
        }
    }
}
