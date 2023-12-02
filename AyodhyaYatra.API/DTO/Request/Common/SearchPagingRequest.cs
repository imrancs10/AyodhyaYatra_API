using AyodhyaYatra.API.DTO.Request.Common;

namespace AyodhyaYatra.API.DTO.Request
{
    public class SearchPagingRequest:PagingRequest
    {
        public string SearchTerm { get; set; }
    }
}
