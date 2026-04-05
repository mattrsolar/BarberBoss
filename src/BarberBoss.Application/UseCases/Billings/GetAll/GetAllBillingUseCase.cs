using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories;

namespace BarberBoss.Application.UseCases.Billings.GetAll
{
    public class GetAllBillingUseCase : IGetAllBillingUseCase
    {
        private readonly IBillingsReadOnlyRepository _repo;
        private readonly IMapper _mapper;

        public GetAllBillingUseCase(
            IBillingsReadOnlyRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseGetAllBillingJson> Execute()
        {
            var result = await _repo.GetAll();

            return new ResponseGetAllBillingJson
            {
                Billings = _mapper.Map<List<ResponseShortGetAllBillingJson>>(result)
            };
        }
    }
}
