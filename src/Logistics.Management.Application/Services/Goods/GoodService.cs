using AutoMapper;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Repositories.Goods;

namespace Logistics.Management.Application.Services.Goods
{
    public class GoodService : IGoodService
    {
        private readonly IMapper _mapper;
        private readonly IGoodRespository _goodRespository;

        public GoodService(IMapper mapper, IGoodRespository goodRespository)
        {
            _mapper = mapper;
            _goodRespository = goodRespository;
        }

        public async Task<GoodResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _goodRespository.FindByIdAsync(id, cancellationToken);

            if (result == null)
            {
                //faz alguma coisa
            }

            return _mapper.Map<GoodResponse>(result);
        }

        public async Task<IEnumerable<GoodResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _goodRespository.FindAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GoodResponse>>(result);
        }

        //public async Task<bool> RegisterAsync(Good Good, CancellationToken cancellationToken)
        //{
        //    var goodExists = _goodRespository.Find(g => g.Id == Good.Id).FirstOrDefault();

        //    await (goodExists == null ? _goodRespository.InsertAsync(Good, cancellationToken) : _goodRespository.UpdateAsync(Good, cancellationToken));

        //    return await _goodRespository.UnitOfWork.CommitAsync(cancellationToken);
        //}

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _goodRespository.DeleteAsync(id, cancellationToken);

            return await _goodRespository.UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}