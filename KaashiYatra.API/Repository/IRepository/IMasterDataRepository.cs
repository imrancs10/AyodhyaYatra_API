using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.Enums;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Repository.IRepository
{
    public interface IMasterDataRepository
    {
        Task<List<MasterDivision>> GetDivisions();
        Task<List<MasterPadav>> GetPadavs();
        Task<List<MasterPadav>> GetPadavs(int yatraId);
        Task<MasterPadav> GetPadavById(int Id);
        Task<List<MasterYatra>> GetYatras();
        Task<MasterYatra> GetYatraById(int id);
        Task<List<MasterDataExt>> GetMasterData(ModuleNameEnum masterDataType);
        Task<List<MasterDataExt>> GetMasterData(List<ModuleNameEnum> masterDataTypes);
        Task<MasterData> GetMasterData(int id);
        Task<int> UpdateMasterData(MasterData masterData);

        Task<MasterDivision> AddDivisions(MasterDivision request);
        Task<MasterPadav> AddPadavs(MasterPadav request);
        Task<int> UpdatePadavs(MasterPadav request);
        Task<MasterYatra> AddYatras(MasterYatra request);
        Task<int> AddMasterData(MasterData request);

        Task<bool> DeleteDivisions(int id);
        Task<bool> DeletePadavs(int id);
        Task<bool> DeleteYatras(int id);
        Task<int> DeleteMasterData(int id);
        Task<int> UpdateYatra(MasterYatra masterData);
        Task<List<MasterDataExt>> GetMasterDataNearByPlacesPath(MasterNearByPlacesRequest request);
        Task<PagingResponse<MasterData>> SearchMasterData(SearchPagingRequest pagingRequest);
    }
}
