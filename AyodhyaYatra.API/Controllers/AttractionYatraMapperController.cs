using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Request.Yatra;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Services;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class AttractionYatraMapperController : ControllerBase
    {
        private readonly IAttractionYatraMapperService _attractionYatraMapperService;
        public AttractionYatraMapperController(IAttractionYatraMapperService attractionYatraMapperService)
        {
            _attractionYatraMapperService = attractionYatraMapperService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [HttpPut(StaticValues.MasterAttractionYatraMapperPath)]
        public async Task<int> Add([FromBody] YatraAttractionMapperRequest req)
        {
            return await _attractionYatraMapperService.Add(req);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost(StaticValues.MasterAttractionYatraMapperPath)]
        public async Task<bool> Update([FromBody] YatraAttractionMapperRequest req)
        {
            return await _attractionYatraMapperService.Update(req);
        }

        [ProducesResponseType(typeof(PagingResponse<YatraAttractionMapperResponse>), 200)]
        [HttpGet(StaticValues.MasterAttractionYatraMapperPath)]
        public async Task<PagingResponse<YatraAttractionMapperResponse>> GetAll([FromQuery] PagingRequest req)
        {
            return await _attractionYatraMapperService.GetAll(req);
        }

        [ProducesResponseType(typeof(List<YatraAttractionMapperResponse>), 200)]
        [HttpGet(StaticValues.MasterAttractionYatraMapperSearchPath)]
        public async Task<PagingResponse<YatraAttractionMapperResponse>> Search([FromQuery] SearchPagingRequest searchTearm)
        {
            return await _attractionYatraMapperService.Search(searchTearm);
        }


        [ProducesResponseType(typeof(List<YatraAttractionMapperResponse>), 200)]
        [HttpGet(StaticValues.MasterAttractionYatraMapperGetByYatraIdPath)]
        public async Task<List<YatraAttractionMapperResponse>> GetByYatraId([FromQuery] int yatraId)
        {
            return await _attractionYatraMapperService.GetByYatraId(yatraId);
        }

        [ProducesResponseType(typeof(YatraAttractionMapperResponse), 200)]
        [HttpGet(StaticValues.MasterAttractionYatraMapperGetByIdPath)]
        public async Task<YatraAttractionMapperResponse> GetById([FromRoute] int id)
        {
            return await _attractionYatraMapperService.GetById(id);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete(StaticValues.MasterAttractionYatraMapperDeletePath)]
        public async Task<bool> Delete([FromRoute] int id)
        {
            return await _attractionYatraMapperService.Delete(id);
        }
    }
}
