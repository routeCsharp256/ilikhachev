using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
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