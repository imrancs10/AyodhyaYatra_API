using KaashiYatra.API.DTO.Base;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.Image;

namespace KaashiYatra.API.DTO.Response
{
    public class TempleCategoryResponse : BaseResponse
    {
        public string EnCategoryName { get; set; }
        public string HiCategoryName { get; set; }
        public string TaCategoryName { get; set; }
        public string TeCategoryName { get; set; }
    }
}
