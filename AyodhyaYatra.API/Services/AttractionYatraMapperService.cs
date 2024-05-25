using AutoMapper;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Yatra;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services.IServices;

namespace AyodhyaYatra.API.Services
{
    public class AttractionYatraMapperService : IAttractionYatraMapperService
    {
        private readonly IAttractionYatraMapperRepository _attractionYatraMapperRepository;
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        public AttractionYatraMapperService(IAttractionYatraMapperRepository attractionYatraMapperRepository, IMapper mapper, IImageStoreRepository imageStoreRepository)
        {
            _mapper = mapper;
            _attractionYatraMapperRepository = attractionYatraMapperRepository;
            _imageStoreRepository = imageStoreRepository;
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
            var data = _mapper.Map<List<YatraAttractionMapperResponse>>(await _attractionYatraMapperRepository.GetByYatraId(yatraId));
            var listOfIds = new List<int>();
            //listOfIds.AddRange(data.Select(x => x.YatraId).Distinct().ToList());
            //set yatra images
            listOfIds.Add(yatraId);
            var yatraImages = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Yatra, listOfIds, true));
            if (data.Any())
                data.FirstOrDefault().Yatra.Images.AddRange(yatraImages);

            //set master attraction images
            if (data != null && data.Count > 0)
            {
                var moduleIds = data.Select(x => x.MasterAttractionResponse.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.MasterAttraction, moduleIds, true));
                foreach (var item in data)
                {
                    item.MasterAttractionResponse.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }

            return data;
        }

        public async Task<PagingResponse<YatraAttractionMapperResponse>> Search(SearchPagingRequest request)
        {
            return _mapper.Map<PagingResponse<YatraAttractionMapperResponse>>(await _attractionYatraMapperRepository.Search(request));
        }

        public async Task<bool> Update(YatraAttractionMapperRequest masterAttractionTypeReq)
        {
            var req = _mapper.Map<YatraAttractionMapper>(masterAttractionTypeReq);
            return await _attractionYatraMapperRepository.Update(req);
        }
    }
}
