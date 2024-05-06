using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IMasterAttractionTypeService
    {
        Task<int> Add(MasterAttractionTypeRequest masterAttractionType);
        Task<bool> Update(MasterAttractionTypeRequest masterAttractionType);
        Task<bool> Delete(int Id);
        Task<PagingResponse<MasterAttractionTypeResponse>> GetAll(PagingRequest pagingRequest);
        Task<MasterAttractionTypeResponse> GetByCode(string code); 
        Task<List<MasterAttractionTypeResponse>> Search(string searchTerm);
        Task<MasterAttractionTypeResponse> GetById(int id);
    }
}
