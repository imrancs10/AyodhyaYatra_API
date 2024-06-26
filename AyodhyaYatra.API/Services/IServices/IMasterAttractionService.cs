﻿using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;

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
        
        Task<YatraAttractionResponse> GetMasterAttractionByYatraId(int yatraId);

        Task<List<int>> GetMasterAttractionIds();
        Task<string> UpdateMasterAttractionFromExcel(IFormFile formFile);

        Task<List<MasterAttractionResponse>> GetMasterAttractionByTypeId(int typeId);

        Task<List<MasterAttractionResponse>> GetSpecificMasterAttraction();

    }
}
