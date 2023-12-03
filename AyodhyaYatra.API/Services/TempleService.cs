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

namespace AyodhyaYatra.API.Services
{
    public class TempleService : ITempleService
    {
        private readonly ITempleRepository _templeRepository;
        private readonly IImageStoreRepository _imageStoreRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly IExcelReader _excelReader;

        public TempleService(ITempleRepository templeRepository, IMapper mapper, IImageStoreRepository imageStoreRepository, IConfiguration configuration, IWebHostEnvironment environment,IExcelReader excelReader)
        {
            _templeRepository = templeRepository;
            _mapper = mapper;
            _imageStoreRepository = imageStoreRepository;
            _configuration = configuration;
            _environment = environment;
            _excelReader = excelReader;
        }
        public async Task<TempleResponse> AddTemple(TempleRequest request)
        {
            Temple temple = _mapper.Map<Temple>(request);
            if(temple.YatraId==-1)
            {
                temple.YatraId = null;
            }
            var data = await _templeRepository.AddTemple(temple);

            return _mapper.Map<TempleResponse>(data);
        }

        public async Task<bool> DeleteTemple(int id)
        {
            return await _templeRepository.DeleteTemple(id);
        }

        public async Task<TempleResponse> GetTempleById(int id)
        {
            var response = _mapper.Map<TempleResponse>(await _templeRepository.GetTempleById(id));
            var listOfIds = new List<int>() { response.Id };
            response.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, listOfIds, true));
            return response;
        }
        public async Task<TempleResponse> GetTempleById(string idorbarcodeId)
        {
            var response = _mapper.Map<TempleResponse>(await _templeRepository.GetTempleById(idorbarcodeId));
            var listOfIds = new List<int>() { response.Id };
            response.Images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, listOfIds, true));
            return response;
        }
        public async Task<List<TempleResponse>> GetTempleByYatraId(int yatraId, bool includeAllChildYatraTemple = false)
        {
            var res = _mapper.Map<List<TempleResponse>>(await _templeRepository.GetTempleByYatraId(yatraId,includeAllChildYatraTemple));
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, moduleIds, true));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }

        public async Task<List<TempleResponse>> GetTempleByPadavId(int padavId)
        {
            var res = _mapper.Map<List<TempleResponse>>(await _templeRepository.GetTempleByPadavId(padavId));
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, moduleIds));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }
        public async Task<List<TempleResponse>> GetTempleByYatraAndPadavId(int yatraId, int padavId)
        {
            var res = _mapper.Map<List<TempleResponse>>(await _templeRepository.GetTempleByYatraAndPadavId(yatraId, padavId));
            if (res != null && res.Count > 0)
            {
                var moduleIds = res.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, moduleIds));
                foreach (var item in res)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                }
            }
            return res;
        }

        public async Task<PagingResponse<TempleResponse>> GetTemples(PagingRequest pagingRequest)
        {
            var res = _mapper.Map<PagingResponse<TempleResponse>>(await _templeRepository.GetTemples(pagingRequest));
            if (res != null && res.Data.Count > 0)
            {
                var moduleIds = res.Data.Select(x => x.Id).Distinct().ToList();
                var images = _mapper.Map<List<ImageStoreResponse>>(await _imageStoreRepository.GetImageStore(Enums.ModuleNameEnum.Temple, moduleIds, true));
                foreach (var item in res.Data)
                {
                    item.Images = images.Where(x => x.ModuleId == item.Id).ToList();
                    item.TempleCategoryName = item.TempleCategoryId == 1 ? "Famous Temple" : "Temple in Ayodhya";                 
                }
            }
            return res;
        }

        public async Task<PagingResponse<TempleResponse>> SearchTemples(SearchPagingRequest pagingRequest)
        {
            return _mapper.Map<PagingResponse<TempleResponse>>(await _templeRepository.SearchTemples(pagingRequest));
        }

        public async Task<TempleResponse> UpdateTemple(TempleRequest request)
        {
            Temple temple = _mapper.Map<Temple>(request);
            return _mapper.Map<TempleResponse>(await _templeRepository.UpdateTemple(temple));
        }

        public async Task<List<int>> GetTempleIds()
        {
            return await _templeRepository.GetTempleIds();
        }

        public async Task<string> UpdateTempleFromExcel(IFormFile file)
        {
            try
            {
                string result="Updated successfully.";
                if (file == null || file.Length == 0)
                {
                    return "Please upload valid excel file.";
                }

                string uploadPath = _configuration.GetSection("TempleExcelFile:Uploads").Value;
                string fullUploadPath = Path.Combine(_environment.WebRootPath, uploadPath);
                if (!Directory.Exists(fullUploadPath))
                    Directory.CreateDirectory(fullUploadPath);

                var excelFilePath = Path.Combine(fullUploadPath, file.FileName);
                using (var stream = new FileStream(excelFilePath, FileMode.Create))
                {
                   await file.CopyToAsync(stream);
                }

                DataTable dt = _excelReader.ReadExcelasDataTable(excelFilePath);
                var templeModel=GetTemplesModelFromDataTable(dt);
                if(File.Exists(excelFilePath))
                {
                    File.Delete(excelFilePath);
                }
                if(await _templeRepository.UpdateTemple(templeModel))
                return result;
                return "Update unsuccessfully";
            }
            catch (Exception ex)
            {
                return "Something went wrong. Please try againg !! " + ex.Message;
            }
        }

        private static List<Temple> GetTemplesModelFromDataTable(DataTable dt)
        {
            return dt.ConvertToList<Temple>();
        }
        //public async Task<List<TempleCategoryResponse>> GetTempleCategory()
        //{
        //    var result = await _templeRepository.GetTempleCategory();
        //    var res = _mapper.Map<List<TempleCategoryResponse>>(result);
        //    return res;
        //}
    }
}
