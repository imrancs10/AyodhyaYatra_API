using AutoMapper;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;

namespace AyodhyaYatra.API.Services
{
    public class MasterDataService : IMasterDataService
    {
        #region Private Members
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;
        private readonly IImageStoreRepository _imageStoreRepository;
        #endregion

        #region CTOR
        public MasterDataService(IMasterDataRepository masterDataRepository, IMapper mapper, IImageStoreRepository imageStoreRepository)
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
        }


        #endregion

        #region Public Methods
      
        public async Task<List<MasterResponse>> GetYatras()
        {
            var res = _mapper.Map<List<MasterResponse>>(await _masterDataRepository.GetYatras());
            if (res != null && res.Count() > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Yatra, moduleIds));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<MasterResponse> GetYatraById(int id)
        {
            var response = _mapper.Map<MasterResponse>(await _masterDataRepository.GetYatraById(id));
            response.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Yatra, response.Id));
            return response;
        }

        public async Task<MasterResponse> AddYatras(MasterYatraRequest request)
        {
            var masterDivision = _mapper.Map<MasterYatra>(request);
            return _mapper.Map<MasterResponse>(await _masterDataRepository.AddYatras(masterDivision));
        }

        public async Task<bool> DeleteDivisions(int id)
        {
            return await _masterDataRepository.DeleteDivisions(id);
        }

        public async Task<bool> DeleteSequenceNos(int id)
        {
            return await _masterDataRepository.DeleteDivisions(id);
        }

        public async Task<bool> DeleteYatras(int id)
        {
            return await _masterDataRepository.DeleteYatras(id);
        }


        public async Task<List<MasterResponse>> GetMasterData(ModuleNameEnum masterDataType)
        {
            var res = _mapper.Map<List<MasterResponse>>(await _masterDataRepository.GetMasterData(masterDataType));
            if (res != null && res.Count() > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                List<ImageStore> imageStores = new List<ImageStore>();
                if (masterDataType == ModuleNameEnum.MasterAttraction)
                    imageStores = await _imageStoreRepository.GetImageStore(masterDataType, moduleIds, true);
                else
                    imageStores = await _imageStoreRepository.GetImageStore(masterDataType, moduleIds);
                var images = _mapper.Map<List<ImageStoreResponse>>(imageStores);
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }

        public async Task<List<DropdownResponse>> GetMasterDataDropdown(ModuleNameEnum masterDataType)
        {
            return _mapper.Map<List<DropdownResponse>>(await _masterDataRepository.GetMasterData(masterDataType));
        }

        public async Task<int> AddMasterData(MasterRequest request)
        {
            MasterData masterData = _mapper.Map<MasterData>(request);
            return await _masterDataRepository.AddMasterData(masterData);
        }

        public async Task<int> DeleteMasterData(int id)
        {
            return await _masterDataRepository.DeleteMasterData(id);
        }

        public async Task<MasterResponse> GetMasterData(int id)
        {
            var res = _mapper.Map<MasterResponse>(await _masterDataRepository.GetMasterData(id));
            var moduleName = Enums.ModuleNameEnum.MasterAttraction;
            if (res != null)
            {
                moduleName = res.MasterDataType;
            }
            res.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(moduleName, res.Id));
            return res;
        }

        public async Task<int> UpdateMasterData(MasterRequest masterData)
        {
            MasterData request = _mapper.Map<MasterData>(masterData);
            return await _masterDataRepository.UpdateMasterData(request);
        }
        public async Task<int> UpdateYatra(MasterYatraRequest masterData)
        {
            MasterYatra request = _mapper.Map<MasterYatra>(masterData);
            return await _masterDataRepository.UpdateYatra(request);
        }

        public async Task<List<MasterResponse>> GetMasterDataNearByPlaces(MasterNearByPlacesRequest request)
        {
            var res = _mapper.Map<List<MasterResponse>>(await _masterDataRepository.GetMasterDataNearByPlacesPath(request));
            if (res != null && res.Count() > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(null, moduleIds));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id && x.ModuleName == ((ModuleNameEnum)item.MasterDataType).ToString()).ToList();
                }
            }
            res.ForEach(x =>
            {
                x.MasterDataTypeName = ((ModuleNameEnum)x.MasterDataType).ToString();
            });
            return res;
        }
        public async Task<PagingResponse<MasterResponse>> SearchMasterData(SearchPagingRequest pagingRequest)
        {
            var result = await _masterDataRepository.SearchMasterData(pagingRequest);
            var res = _mapper.Map<PagingResponse<MasterResponse>>(result);
            if (res != null && res.Data.Count() > 0)
            {
                var moduleIds = res.Data.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(null, moduleIds));
                foreach (var item in res.Data)
                {
                    item.Images = images.Where(x => x.ModuleName == item.MasterDataType.ToString() && x.ModuleId == item.Id).ToList();
                }
            }
            res.Data.ForEach(x =>
            {
                x.MasterDataTypeName = ((ModuleNameEnum)x.MasterDataType).ToString();
            });
            return res;
        }

        public async Task<List<MasterResponse>> GetMasterData(List<ModuleNameEnum> masterDataTypes)
        {
            var res = _mapper.Map<List<MasterResponse>>(await _masterDataRepository.GetMasterData(masterDataTypes));
            if (res != null && res.Count() > 0)
            {
                Dictionary<ModuleNameEnum, List<int>> moduleNameAndIds = new Dictionary<ModuleNameEnum, List<int>>();
                foreach (var item in res)
                {
                    if (!moduleNameAndIds.ContainsKey(item.MasterDataType))
                    {
                        var key = item.MasterDataType;
                        var value = res.Where(x => x.MasterDataType == key).Select(x => x.Id).ToList();
                        moduleNameAndIds.Add(key, value);
                    }
                }
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(moduleNameAndIds));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id && x.ModuleName == item.MasterDataType.ToString()).ToList();
                }
            }
            return res;
        }
        #endregion
    }
}
