using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Yatra;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IAttractionYatraMapperService
    {
        Task<int> Add(YatraAttractionMapperRequest masterAttractionType);
        Task<bool> Update(YatraAttractionMapperRequest masterAttractionType);
        Task<bool> Delete(int Id);
        Task<PagingResponse<YatraAttractionMapperResponse>> GetAll(PagingRequest pagingRequest);
        Task<YatraAttractionMapperResponse> GetById(int id);
        Task<List<YatraAttractionMapperResponse>> Search(string searchTerm);
    }
}
