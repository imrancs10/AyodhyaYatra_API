using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository
{
    public interface IMobileLogicRespository
    {
        Task<List<MasterAttraction>> GetAttractionList();
    }
}
