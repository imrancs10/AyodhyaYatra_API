using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.DTO.Response.MasterData
{
    public class DashboardResponse : BaseResponse
    {
        public int YatraCount { get; set; }
        public int TempleCount { get; set; }
        public int RegistrationCount { get; set; }
    }
}
