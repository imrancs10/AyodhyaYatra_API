using AyodhyaYatra.API.DTO.Base;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;

namespace AyodhyaYatra.API.DTO.Response
{
    public class TempleCategoryResponse : BaseResponse
    {
        public string EnCategoryName { get; set; }
        public string HiCategoryName { get; set; }
        public string TaCategoryName { get; set; }
        public string TeCategoryName { get; set; }
    }
}
