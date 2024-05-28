using AutoMapper;
using Azure;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services.IServices;
using AyodhyaYatra.API.Utility;
using System.Data;
using AyodhyaYatra.API.DTO.Response.MasterData;

namespace AyodhyaYatra.API.Services
{
    public class MasterAttractionService : IMasterAttractionService
    {
        private readonly IMasterAttractionRepository _MasterAttractionRepository;
        private readonly IImageStoreRepository _imageStoreRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly IExcelReader _excelReader;

        public MasterAttractionService(IMasterAttractionRepository MasterAttractionRepository, IMapper mapper, IImageStoreRepository imageStoreRepository, IConfiguration configuration, IWebHostEnvironment environment,IExcelReader excelReader)
        {
            _MasterAttractionRepository = MasterAttractionRepository;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
            _configuration = configuration;
            _environment = environment;
            _excelReader = excelReader;
        }
        public async Task<MasterAttractionResponse> AddMasterAttraction(MasterAttractionRequest request)
        {
            MasterAttraction MasterAttraction = _mapper.Map<MasterAttraction>(request);
            var data = await _MasterAttractionRepository.AddMasterAttraction(MasterAttraction);

            return _mapper.Map<MasterAttractionResponse>(data);
        }

        public async Task<bool> DeleteMasterAttraction(int id)
        {
            return await _MasterAttractionRepository.DeleteMasterAttraction(id);
        }

        public async Task<MasterAttractionResponse> GetMasterAttractionById(int id)
        {
            var response = _mapper.Map<MasterAttractionResponse>(await _MasterAttractionRepository.GetMasterAttractionById(id));
            if (response != null) { 
            var listOfIds = new List<int>() { response.Id };
            response.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.MasterAttraction, listOfIds, true));
            }
            return response;
        }
        public async Task<MasterAttractionResponse> GetMasterAttractionById(string idorbarcodeId)
        {
            var response = _mapper.Map<MasterAttractionResponse>(await _MasterAttractionRepository.GetMasterAttractionById(idorbarcodeId));
            if (response != null)
            {
                var listOfIds = new List<int>() { response.Id };
                response.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.MasterAttraction, listOfIds, true));
            }
            return response;
        }
        public async Task<YatraAttractionResponse> GetMasterAttractionByYatraId(int yatraId)
        {
            var outRes = new YatraAttractionResponse();
            var res = await _MasterAttractionRepository.GetMasterAttractionByYatraId(yatraId);
            if (res != null && res.Count > 0)
            {
                outRes.Yatra = _mapper.Map<MasterResponse>(res.First().MasterYatra);
                outRes.Attractions = _mapper.Map<List<MasterAttractionResponse>>(res.Select(x => x.MasterAttraction));
                var attractionIds=res.Select(x=>x.MasterAttractionId).ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.MasterAttraction, attractionIds, true));
                foreach (var item in outRes.Attractions)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
                attractionIds = new List<int>() { outRes.Yatra.Id };
                var yatraImages = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Yatra, attractionIds, true));
                outRes.Yatra.Images = yatraImages;
            }
            return outRes;
        }

        public async Task<PagingResponse<MasterAttractionResponse>> GetMasterAttractions(PagingRequest pagingRequest)
        {
            var res = _mapper.Map<PagingResponse<MasterAttractionResponse>>(await _MasterAttractionRepository.GetMasterAttractions(pagingRequest));
            var images =await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.MasterAttraction);
            if(images.Count>0)
            {
                var imageDic = images.ToLookup(x => x.ModuleId).ToDictionary(x => x.Key, x => x.First());
                foreach (var masterAttraction in res.Data) {
                    masterAttraction.Images = imageDic.ContainsKey(masterAttraction.Id) ?
                        new List<ImageStoreResponse>() { 
                            _mapper.Map<ImageStoreResponse>(imageDic[masterAttraction.Id]) 
                        } : 
                        new List<ImageStoreResponse>();
                }
            }
           
            return res;
        }

        public async Task<PagingResponse<MasterAttractionResponse>> SearchMasterAttractions(SearchPagingRequest pagingRequest)
        {
            return _mapper.Map<PagingResponse<MasterAttractionResponse>>(await _MasterAttractionRepository.SearchMasterAttractions(pagingRequest));
        }

        public async Task<MasterAttractionResponse> UpdateMasterAttraction(MasterAttractionRequest request)
        {
            MasterAttraction MasterAttraction = _mapper.Map<MasterAttraction>(request);
            return _mapper.Map<MasterAttractionResponse>(await _MasterAttractionRepository.UpdateMasterAttraction(MasterAttraction));
        }

        public async Task<List<int>> GetMasterAttractionIds()
        {
            return default;
        }

        public async Task<string> UpdateMasterAttractionFromExcel(IFormFile file)
        {
            try
            {
                string result="Updated successfully.";
                if (file == null || file.Length == 0)
                {
                    return "Please upload valid excel file.";
                }

                string uploadPath = _configuration.GetSection("MasterAttractionExcelFile:Uploads").Value;
                string fullUploadPath = Path.Combine(_environment.WebRootPath, uploadPath);
                if (!Directory.Exists(fullUploadPath))
                    Directory.CreateDirectory(fullUploadPath);

                var excelFilePath = Path.Combine(fullUploadPath, file.FileName);
                using (var stream = new FileStream(excelFilePath, FileMode.Create))
                {
                   await file.CopyToAsync(stream);
                }

                DataTable dt = _excelReader.ReadExcelasDataTable(excelFilePath);
                var MasterAttractionModel=GetMasterAttractionsModelFromDataTable(dt);
                if(File.Exists(excelFilePath))
                {
                    File.Delete(excelFilePath);
                }
                if(await _MasterAttractionRepository.UpdateMasterAttraction(MasterAttractionModel))
                return result;
                return "Update unsuccessfully";
            }
            catch (Exception ex)
            {
                return "Something went wrong. Please try againg !! " + ex.Message;
            }
        }

        private static List<MasterAttraction> GetMasterAttractionsModelFromDataTable(DataTable dt)
        {
            return dt.ConvertToList<MasterAttraction>();
        }
        //public async Task<List<MasterAttractionCategoryResponse>> GetMasterAttractionCategory()
        //{
        //    var result = await _MasterAttractionRepository.GetMasterAttractionCategory();
        //    var res = _mapper.Map<List<MasterAttractionCategoryResponse>>(result);
        //    return res;
        //}
    }
}
