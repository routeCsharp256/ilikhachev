using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Services.Interfaces;

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
        
        [HttpGet("getAll")]
        public async Task<ActionResult<GetAllResponse>> GetAll(CancellationToken token)
        {
            return Ok(await _merchandiseService.GetAllMerch(token));
        }

        [HttpGet("getInfo")]
        public async Task<ActionResult<MerchInfoResponse>> GetInfo([FromQuery]Guid id, CancellationToken token)
        {
            return Ok(await _merchandiseService.GetMerchInfo(id, token));
        }
    }
}