using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Visitor;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Services
{
    public interface IVisitorService
    {
        Task<int> AddDocumentType(VisitorDocumentTypeRequest documentType);
        Task<bool> UpdateDocumentType(VisitorDocumentTypeRequest documentType);
        Task<bool> DeleteDocumentType(int id);
        Task<List<VisitorDocumentTypeResponse>> GetsDocumentType();

        Task<VisitorResponse> AddVisitor(VisitorRequest visitor);
        Task<List<VisitorResponse>> GetsVisitors(PagingRequest pagingRequest);
        Task<int> VisitorCount(int month, int year);
        Task<List<VisitorResponse>> GetVisitor(string mobileNo);
    }
}
