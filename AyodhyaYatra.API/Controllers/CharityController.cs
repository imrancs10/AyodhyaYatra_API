using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityRepository _charityRepository;
        private readonly IMapper _mapper;

        public CharityController(ICharityRepository charityRepository,IMapper mapper)
        {
            _charityRepository = charityRepository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(bool), 201)]
        [HttpPut(StaticValues.CharityPath)]
        public async Task<bool> AddCharity([FromBody] CharityRequest request)
        {
            var charity = _mapper.Map<Charity>(request);
            return await _charityRepository.AddCharity(charity);
        }

        [ProducesResponseType(typeof(bool), 201)]
        [HttpPut(StaticValues.CharityMasterPath)]
        public async Task<bool> AddCharityMasterData([FromBody] CharityMasterDataRequest request)
        {
            var charity = _mapper.Map<CharityMasterData>(request);
            return await _charityRepository.AddCharityDataType(charity);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost(StaticValues.CharityPath)]
        public async Task<bool> UpdateCharity([FromBody] CharityRequest request)
        {
            var charity = _mapper.Map<Charity>(request);
            return await _charityRepository.UpdateCharity(charity);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost(StaticValues.CharityMasterPath)]
        public async Task<bool> UpdateCharityDataType([FromBody] CharityMasterDataRequest request)
        {
            var charity = _mapper.Map<CharityMasterData>(request);
            return await _charityRepository.UpdateCharityDataType(charity);
        }


        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete(StaticValues.CharityPath)]
        public async Task<bool> DaleteCharity([FromQuery] int id)
        {
            return await _charityRepository.DeleteCharity(id);
        }

        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete(StaticValues.CharityMasterPath)]
        public async Task<bool> DeleteCharityDataType([FromQuery] int id)
        {
            return await _charityRepository.DeleteCharityDataType(id);
        }

        [ProducesResponseType(typeof(CharityResponse), 200)]
        [HttpGet(StaticValues.CharityGetByIdPath)]
        public async Task<CharityResponse> GetCharity([FromRoute] int id)
        {
            return _mapper.Map<CharityResponse>(await _charityRepository.GetCharity(id));
        }

        [ProducesResponseType(typeof(CharityMasterDataResponse), 200)]
        [HttpGet(StaticValues.CharityMasterGetByIdPath)]
        public async Task<CharityMasterDataResponse> GetCharityDataType([FromRoute] int id)
        {
            return _mapper.Map<CharityMasterDataResponse>(await _charityRepository.GetCharityDataType(id));
        }

        [ProducesResponseType(typeof(PagingResponse<CharityResponse>), 200)]
        [HttpGet(StaticValues.CharityPath)]
        public async Task<PagingResponse<CharityResponse>> GetAllCharity([FromQuery] PagingRequest request)
        {
            return _mapper.Map<PagingResponse<CharityResponse>>(await _charityRepository.GetAllCharityDataType(request));
        }

        [ProducesResponseType(typeof(PagingResponse<CharityMasterDataResponse>), 200)]
        [HttpGet(StaticValues.CharityMasterPath)]
        public async Task<PagingResponse<CharityMasterDataResponse>> GetAllCharityDataType([FromQuery] PagingRequest request)
        {
            return _mapper.Map<PagingResponse<CharityMasterDataResponse>>(await _charityRepository.GetAllCharityDataType(request));
        }

    }
}
