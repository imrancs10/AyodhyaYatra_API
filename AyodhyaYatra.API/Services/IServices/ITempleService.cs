using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;
using Microsoft.AspNetCore.Http;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface ITempleService
    {
        Task<TempleResponse> AddTemple(TempleRequest request);
        Task<TempleResponse> UpdateTemple(TempleRequest request);
        Task<bool> DeleteTemple(int id);
        Task<TempleResponse> GetTempleById(int id);

        Task<TempleResponse> GetTempleById(string idorbarcodeId);
        Task<PagingResponse<TempleResponse>> GetTemples(PagingRequest pagingRequest);
        Task<PagingResponse<TempleResponse>> SearchTemples(SearchPagingRequest pagingRequest);
        //Task<List<TempleCategoryResponse>> GetTempleCategory();
        
        Task<List<TempleResponse>> GetTempleByYatraId(int yatraId, bool includeAllChildYatraTemple = false);

        Task<List<TempleResponse>> GetTempleByPadavId(int padavId);
        Task<List<TempleResponse>> GetTempleByYatraAndPadavId(int yatraId, int padavId);
        Task<List<int>> GetTempleIds();
        Task<string> UpdateTempleFromExcel(IFormFile formFile);

    }
}
