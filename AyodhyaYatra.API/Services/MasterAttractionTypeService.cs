using AutoMapper;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;

namespace AyodhyaYatra.API.Services
{
    public class MasterAttractionTypeService : IMasterAttractionTypeService
    {
        private readonly IMasterAttractionTypeRepository _masterAttractionTypeRepository;
        private readonly IMapper _mapper;

        public MasterAttractionTypeService(IMasterAttractionTypeRepository masterAttractionTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _masterAttractionTypeRepository = masterAttractionTypeRepository;
        }
        public async Task<int> Add(MasterAttractionTypeRequest masterAttractionTypeReq)
        {
            var req = _mapper.Map<MasterAttractionType>(masterAttractionTypeReq);
            return await _masterAttractionTypeRepository.Add(req);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _masterAttractionTypeRepository.Delete(Id);
        }

        public async Task<PagingResponse<MasterAttractionTypeResponse>> GetAll(PagingRequest pagingRequest)
        {
            return _mapper.Map<PagingResponse<MasterAttractionTypeResponse>>(await _masterAttractionTypeRepository.GetAll(pagingRequest));
        }

        public async Task<MasterAttractionTypeResponse> GetByCode(string code)
        {
            return _mapper.Map<MasterAttractionTypeResponse>(await _masterAttractionTypeRepository.GetByCode(code));
        }

        public async Task<MasterAttractionTypeResponse> GetById(int id)
        {
           return _mapper.Map<MasterAttractionTypeResponse>(await _masterAttractionTypeRepository.GetById(id));
        }

        public async Task<List<MasterAttractionTypeResponse>> Search(string searchTerm)
        {
            return _mapper.Map<List<MasterAttractionTypeResponse>>(await _masterAttractionTypeRepository.Search(searchTerm));
        }

        public async Task<bool> Update(MasterAttractionTypeRequest masterAttractionTypeReq)
        {
            var req = _mapper.Map<MasterAttractionType>(masterAttractionTypeReq);
            return await _masterAttractionTypeRepository.Update(req);
        }
    }
}
