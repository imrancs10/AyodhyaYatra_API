using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;
using Microsoft.AspNetCore.Http;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IMasterAttractionService
    {
        Task<MasterAttractionResponse> AddMasterAttraction(MasterAttractionRequest request);
        Task<MasterAttractionResponse> UpdateMasterAttraction(MasterAttractionRequest request);
        Task<bool> DeleteMasterAttraction(int id);
        Task<MasterAttractionResponse> GetMasterAttractionById(int id);

        Task<MasterAttractionResponse> GetMasterAttractionById(string idorbarcodeId);
        Task<PagingResponse<MasterAttractionResponse>> GetMasterAttractions(PagingRequest pagingRequest);
        Task<PagingResponse<MasterAttractionResponse>> SearchMasterAttractions(SearchPagingRequest pagingRequest);
        //Task<List<MasterAttractionCategoryResponse>> GetMasterAttractionCategory();
        
        Task<List<MasterAttractionResponse>> GetMasterAttractionByYatraId(int yatraId, bool includeAllChildYatraMasterAttraction = false);

        Task<List<int>> GetMasterAttractionIds();
        Task<string> UpdateMasterAttractionFromExcel(IFormFile formFile);

    }
}
