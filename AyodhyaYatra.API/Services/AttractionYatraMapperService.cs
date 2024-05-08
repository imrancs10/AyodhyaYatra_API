using AutoMapper;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Request.Yatra;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services.IServices;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace AyodhyaYatra.API.Services
{
    public class AttractionYatraMapperService : IAttractionYatraMapperService
    {
        private readonly IAttractionYatraMapperRepository _attractionYatraMapperRepository;
        private readonly IMapper _mapper;

        public AttractionYatraMapperService(IAttractionYatraMapperRepository attractionYatraMapperRepository, IMapper mapper)
        {
            _mapper = mapper;
            _attractionYatraMapperRepository = attractionYatraMapperRepository;
        }
        public async Task<int> Add(YatraAttractionMapperRequest masterAttractionTypeReq)
        {
            var req = _mapper.Map<YatraAttractionMapper>(masterAttractionTypeReq);
            return await _attractionYatraMapperRepository.Add(req);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _attractionYatraMapperRepository.Delete(Id);
        }

        public async Task<PagingResponse<YatraAttractionMapperResponse>> GetAll(PagingRequest pagingRequest)
        {
            return _mapper.Map<PagingResponse<YatraAttractionMapperResponse>>(await _attractionYatraMapperRepository.GetAll(pagingRequest));
        }


        public async Task<YatraAttractionMapperResponse> GetById(int id)
        {
            return _mapper.Map<YatraAttractionMapperResponse>(await _attractionYatraMapperRepository.GetById(id));
        }

        public async Task<List<YatraAttractionMapperResponse>> GetByYatraId(int yatraId)
        {
            return _mapper.Map<List<YatraAttractionMapperResponse>>(await _attractionYatraMapperRepository.GetByYatraId(yatraId));
        }

        public async Task<List<YatraAttractionMapperResponse>> Search(string searchTerm)
        {
            return _mapper.Map<List<YatraAttractionMapperResponse>>(await _attractionYatraMapperRepository.Search(searchTerm));
        }

        public async Task<bool> Update(YatraAttractionMapperRequest masterAttractionTypeReq)
        {
            var req = _mapper.Map<YatraAttractionMapper>(masterAttractionTypeReq);
            return await _attractionYatraMapperRepository.Update(req);
        }
    }
}
