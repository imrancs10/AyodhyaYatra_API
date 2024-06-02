using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileLogicService _mobileLogicService;
        public MobileController(IMobileLogicService mobileLogicService)
        {
                _mobileLogicService = mobileLogicService;
        }

        [HttpGet(StaticValues.MobileAttractionPath)]
        public async Task<List<AttractionMobileResponse>> GetAttractionList()
        {
            return await _mobileLogicService.GetAttractionList();
        }
    }
}
