using AutoMapper;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Repository;

namespace AyodhyaYatra.API.Services
{
    public class MobileLogicService : IMobileLogicService
    {
        private readonly IMobileLogicRespository _repository;
        private readonly IMapper _mapper;
        public MobileLogicService(IMobileLogicRespository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AttractionMobileResponse>> GetAttractionList()
        {
            return _mapper.Map<List<AttractionMobileResponse>>(await  _repository.GetAttractionList());
        }
    }
}
