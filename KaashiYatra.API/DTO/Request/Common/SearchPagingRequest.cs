using KaashiYatra.API.DTO.Request.Common;

namespace KaashiYatra.API.DTO.Request
{
    public class SearchPagingRequest:PagingRequest
    {
        public string SearchTerm { get; set; }
    }
}
