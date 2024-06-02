
using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;

namespace AyodhyaYatra.API.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IFileStorageRepository _fileStorageRepository;
        private readonly IImageStoreRepository _imageStorageRepository;
        private readonly IMapper _mapper;
        private readonly IMasterAttractionService _masterAttractionService;
        public FileStorageService(IFileStorageRepository fileStorageRepository,IMapper mapper, IImageStoreRepository imageStorageRepository, IMasterAttractionService masterAttractionService)
        {
            _fileStorageRepository = fileStorageRepository;
            _mapper = mapper;
            _imageStorageRepository = imageStorageRepository;
            _masterAttractionService= masterAttractionService;
        }
        public async Task<List<ImageStoreResponse>> Add(List<ImageStore> ImageStore)
        {
            return _mapper.Map <List<ImageStoreResponse>>( await _fileStorageRepository.Add(ImageStore));
        }

        public async Task<int> Delete(int storageId)
        {
            return await _fileStorageRepository.Delete(storageId);
        }

        public async Task<ImageStoreResponse> Get(int storageId)
        {
            return _mapper.Map<ImageStoreResponse>(await _fileStorageRepository.Get(storageId));
        }

        public async Task<List<ImageStoreResponse>> GetByModuleIds(List<int> moduleIds, ModuleNameEnum moduleName)
        {
            return _mapper.Map<List<ImageStoreResponse>>(await _fileStorageRepository.GetByModuleIds(moduleIds, moduleName));
        }

        public async Task<List<ImageStoreResponse>> GetByModuleName(string moduleName)
        {
            ModuleNameEnum modName = Enum.Parse<ModuleNameEnum>(moduleName, true);
            if (modName == null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidModuleName, StaticValues.Error_InvalidModuleName);
            }
            return _mapper.Map<List<ImageStoreResponse>>(await _fileStorageRepository.GetByModuleName(modName));
        }

        public async Task<List<ImageStoreResponse>> GetImageStore(ModuleNameEnum moduleName, int moduleId, string imageType = "image")
        {
            var data= _mapper.Map<List<ImageStoreResponse>>(await _imageStorageRepository.GetImageStore(moduleName,moduleId,imageType));
            if(moduleName==ModuleNameEnum.MasterAttraction && imageType?.ToLower()== "360degreeimage")
            {
                var attraction=await _masterAttractionService.GetMasterAttractionById(moduleId);
                if(attraction != null)
                {
                    if(!string.IsNullOrEmpty(attraction.Video360URL))
                    {
                        foreach (var item in attraction.Video360URL.Split(",").ToList())
                        {
                            data.Add(new ImageStoreResponse()
                            {
                                FilePath = item,
                                ModuleId = moduleId,
                                ModuleName = moduleName.ToString(),
                                FileType = "Youtube360",
                                Id = 0,
                                Remark = "Youtube 360 video URL"

                            });
                        }
                    }
                }
            }
            return data;
        }

        public async Task<List<ImageStoreResponse>> GetImageStore(ModuleNameEnum moduleName, List<int> moduleIds, string imageType = "image")
        {
            return _mapper.Map<List<ImageStoreResponse>>(await _imageStorageRepository.GetImageStore(moduleName, moduleIds, imageType));
        }

        public async  Task<List<ImageStoreResponse>> GetImageStore(ModuleNameEnum moduleName, int moduleId, int sequenceNo, string imageType = "image")
        {
            return _mapper.Map<List<ImageStoreResponse>>(await _imageStorageRepository.GetImageStore(moduleName, moduleId,sequenceNo, imageType));
        }

        public async Task<List<ImageStoreWithNameResponse>> GetImageStore(ModuleNameEnum? moduleName, int pageNo, int pageSize, bool allImage = false, string imageType = "image")
        {
            return _mapper.Map<List<ImageStoreWithNameResponse>>(await _imageStorageRepository.GetImageStore(moduleName,pageNo, pageSize, allImage, imageType));
        }

        public async Task<ImageStoreResponse> Update(ImageStore ImageStore)
        {
            return _mapper.Map<ImageStoreResponse>(await _fileStorageRepository.Update(ImageStore));
        }
    }
}
