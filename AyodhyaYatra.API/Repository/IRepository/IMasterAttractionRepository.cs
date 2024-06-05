using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository
{
    public interface IMasterAttractionRepository
    {
        Task<MasterAttraction> AddMasterAttraction(MasterAttraction temple);
        Task<MasterAttraction> UpdateMasterAttraction(MasterAttraction temple);
        Task<bool> UpdateMasterAttraction(List<MasterAttraction> temples);
        Task<bool> DeleteMasterAttraction(int id);
        Task<MasterAttraction> GetMasterAttractionById(int id);
        Task<MasterAttraction> GetMasterAttractionById(string idorbarcodeId);
        Task<List<YatraAttractionMapper>> GetMasterAttractionByYatraId(int yatraId);
        Task<PagingResponse<MasterAttraction>> GetMasterAttractions(PagingRequest pagingRequest);
        Task<PagingResponse<MasterAttraction>> SearchMasterAttractions(SearchPagingRequest pagingRequest);
        Task<List<int>> GetMasterAttractionIds();

        Task<List<MasterAttraction>> GetMasterAttractionByTypeId(int typeId);
        Task<List<MasterAttraction>> GetSpecificMasterAttraction();
        //Task<List<TempleCategory>> GetTempleCategory();

    }
}
