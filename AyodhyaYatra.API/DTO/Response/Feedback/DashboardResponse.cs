using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;

namespace AyodhyaYatra.API.DTO.Response.MasterData
{
    public class DashboardResponse : BaseResponse
    {
        public int YatraCount { get; set; }
        public int TempleCount { get; set; }
        public int RegistrationCount { get; set; }
    }
}
