using AyodhyaYatra.API.DTO.Base;

namespace AyodhyaYatra.API.DTO.Request
{
    public class MasterYatraRequest : BaseRequest
    {
        public string enName { get; set; }
        public string hiName { get; set; }
        public string taName { get; set; }
        public string teName { get; set; }
        public string enDescription { get; set; }
        public string hiDescription { get; set; }
        public string taDescription { get; set; }
        public string teDescription { get; set; }
    }
}
