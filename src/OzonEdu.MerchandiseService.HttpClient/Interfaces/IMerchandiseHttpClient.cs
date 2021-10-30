using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient.Interfaces
{
    public interface IMerchandiseHttpClient
    {
        Task<List<GetAllResponse>> V1GetMerch(CancellationToken token);

        Task<MerchResponse> V1GetMerchById(Guid id, CancellationToken token);

        Task<MerchInfoResponse> V1GetInfo(Guid id, CancellationToken token);
    }
}