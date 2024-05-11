using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.Visitor;

namespace AyodhyaYatra.API.DTO.Response.MasterData
{
    public class DashboardResponse : BaseResponse
    {
        public int YatraCount { get; set; }
        public int RegistrationCount { get; set; }
        public List<MonthlyVisitorCountResponse>? MonthlyVisitorCounts { get; set; }

        public List<AttractionCountResponse>? AttractionCounts { get; set; }
    }
}
