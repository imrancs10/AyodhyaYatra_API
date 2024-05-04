using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IMasterAttractionRepository
    {
        Task<MasterAttraction> AddMasterAttraction(MasterAttraction temple);
        Task<MasterAttraction> UpdateMasterAttraction(MasterAttraction temple);
        Task<bool> UpdateMasterAttraction(List<MasterAttraction> temples);
        Task<bool> DeleteMasterAttraction(int id);
        Task<MasterAttraction> GetMasterAttractionById(int id);
        Task<MasterAttraction> GetMasterAttractionById(string idorbarcodeId);
        Task<List<MasterAttraction>> GetMasterAttractionByYatraId(int yatraId,bool includeAllChildYatraTemple=false);
        Task<PagingResponse<MasterAttraction>> GetMasterAttractions(PagingRequest pagingRequest);
        Task<PagingResponse<MasterAttraction>> SearchMasterAttractions(SearchPagingRequest pagingRequest);
        Task<List<int>> GetTempleIds();
        //Task<List<TempleCategory>> GetTempleCategory();

    }
}
