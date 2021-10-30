using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Services.Interfaces;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Domain.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<GetAllResponse> GetAllMerch(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<MerchResponse> GetMerchById(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<MerchInfoResponse> GetMerchInfo(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}