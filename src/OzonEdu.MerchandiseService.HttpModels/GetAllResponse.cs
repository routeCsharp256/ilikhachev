using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class GetAllResponse
    {
        public IEnumerable<MerchResponse> Data { get; set; }
    }
}
