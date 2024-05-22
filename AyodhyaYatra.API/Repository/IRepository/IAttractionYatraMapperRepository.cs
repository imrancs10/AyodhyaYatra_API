using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IAttractionYatraMapperRepository
    {
        Task<int> Add(YatraAttractionMapper masterAttractionType);
        Task<bool> Update(YatraAttractionMapper masterAttractionType);
        Task<bool> Delete(int Id);
        Task<PagingResponse<YatraAttractionMapper>> GetAll(PagingRequest pagingRequest);
        Task<YatraAttractionMapper> GetById(int id);
        Task<PagingResponse<YatraAttractionMapper>> Search(SearchPagingRequest searchTerm); 
        Task<List<YatraAttractionMapper>> GetByYatraId(int yatraId);
    }
}
