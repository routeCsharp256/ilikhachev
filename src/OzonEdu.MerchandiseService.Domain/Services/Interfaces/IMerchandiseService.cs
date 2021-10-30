using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Domain.Services.Interfaces
{
    public interface IMerchandiseService
    {
        public Task<GetAllResponse> GetAllMerch(CancellationToken token);
        
        public Task<MerchResponse> GetMerchById(Guid id, CancellationToken token);

        public Task<MerchInfoResponse> GetMerchInfo(Guid id, CancellationToken token);
    }
}