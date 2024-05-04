using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IMasterDataRepository
    {
        Task<List<MasterYatra>> GetYatras();
        Task<MasterYatra> GetYatraById(int id);
        Task<List<MasterDataExt>> GetMasterData(ModuleNameEnum masterDataType);
        Task<List<MasterDataExt>> GetMasterData(List<ModuleNameEnum> masterDataTypes);
        Task<MasterData> GetMasterData(int id);
        Task<int> UpdateMasterData(MasterData masterData);
        Task<MasterYatra> AddYatras(MasterYatra request);
        Task<int> AddMasterData(MasterData request);

        Task<bool> DeleteDivisions(int id);
        Task<bool> DeleteYatras(int id);
        Task<int> DeleteMasterData(int id);
        Task<int> UpdateYatra(MasterYatra masterData);
        Task<List<MasterDataExt>> GetMasterDataNearByPlacesPath(MasterNearByPlacesRequest request);
        Task<PagingResponse<MasterData>> SearchMasterData(SearchPagingRequest pagingRequest);
    }
}
