using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;

namespace BarberBoss.Application.UseCases.Create
{
    public class CreateBillingUseCase : ICreateBillingUseCase
    {
        private readonly IBillingsWriteOnlyRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBillingUseCase(
            IBillingsWriteOnlyRepository repo,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }   

        public async Task<ResponseCreateBillingJson> Execute(RequestBillingJson request)
        {

            var entity = _mapper.Map<Billing>(request);
            await _repo.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCreateBillingJson>(entity);
        }
        
    }
}
