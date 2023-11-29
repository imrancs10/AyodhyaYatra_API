
using AutoMapper;
using KaashiYatra.API.Contants;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Exceptions;
using KaashiYatra.API.Models;
using KaashiYatra.API.Repository.IRepository;
using KaashiYatra.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace KaashiYatra.API.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IFileStorageRepository _fileStorageRepository;
        private readonly IImageStoreRepository _imageStorageRepository;
        private readonly IMapper _mapper;
        public FileStorageService(IFileStorageRepository fileStorageRepository,IMapper mapper, IImageStoreRepository imageStorageRepository)
        {
            _fileStorageRepository = fileStorageRepository;
            _mapper = mapper;
            _imageStorageRepository = imageStorageRepository;
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
            return _mapper.Map<List<ImageStoreResponse>>(await _imageStorageRepository.GetImageStore(moduleName,moduleId,imageType));
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
