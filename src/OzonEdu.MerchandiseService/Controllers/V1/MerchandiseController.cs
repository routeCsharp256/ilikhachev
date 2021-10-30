using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Domain.Services.Interfaces;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;
        
        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        [HttpGet("merch")]
        public async Task<ActionResult<GetAllResponse>> GetMerch(CancellationToken token)
        {
            return Ok(await _merchandiseService.GetAllMerch(token));
        }
        
        [HttpGet("merch/{id}")]
        public async Task<ActionResult<MerchResponse>> GetMerchById(Guid id, CancellationToken token)
        {
            return Ok(await _merchandiseService.GetMerchById(id, token));
        }

        [HttpGet("merch/getInfo")]
        public async Task<ActionResult<MerchInfoResponse>> GetInfo([FromQuery]Guid id, CancellationToken token)
        {
            return Ok(await _merchandiseService.GetMerchInfo(id, token));
        }
    }
}