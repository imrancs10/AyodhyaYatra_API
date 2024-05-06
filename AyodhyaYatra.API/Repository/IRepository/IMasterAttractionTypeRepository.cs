using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IMasterAttractionTypeRepository
    {
        Task<int> Add(MasterAttractionType masterAttractionType);
        Task<bool> Update(MasterAttractionType masterAttractionType);
        Task<bool> Delete(int Id);
        Task<PagingResponse<MasterAttractionType>> GetAll(PagingRequest pagingRequest);
        Task<MasterAttractionType> GetByCode(string code);
        Task<MasterAttractionType> GetById(int id);
        Task<List<MasterAttractionType>> Search(string searchTerm);
    }
}
