using AutoMapper;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Visitor;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;

namespace AyodhyaYatra.API.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;
        public VisitorService(IVisitorRepository visitorRepository,IMapper mapper)
        {
            _mapper = mapper;
            _visitorRepository = visitorRepository;
        }
        public async Task<int> AddDocumentType(VisitorDocumentTypeRequest documentTypeReq)
        {
            var documentType = _mapper.Map<VisitorDocumentType>(documentTypeReq);
            return await _visitorRepository.AddDocumentType(documentType);
        }

        public async Task<VisitorResponse> AddVisitor(VisitorRequest visitorReq)
        {
            var visitor = _mapper.Map<Visitor>(visitorReq);
            var visitorId=await _visitorRepository.AddVisitor(visitor);

            return _mapper.Map<VisitorResponse>(await _visitorRepository.GetVisitor(visitorId));
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            return await _visitorRepository.DeleteDocumentType(id);
        }

        public async Task<List<VisitorDocumentTypeResponse>> GetsDocumentType()
        {
            return _mapper.Map<List<VisitorDocumentTypeResponse>>(await _visitorRepository.GetsDocumentType());
        }

        public async Task<List<VisitorResponse>> GetsVisitors(PagingRequest pagingRequest)
        {
            return _mapper.Map<List<VisitorResponse>>( await _visitorRepository.GetsVisitors(pagingRequest));
        }

        public async Task<List<VisitorResponse>> GetVisitor(string mobileNo)
        {
            return _mapper.Map<List<VisitorResponse>>(await _visitorRepository.GetVisitor(mobileNo));
        }

        public async Task<bool> UpdateDocumentType(VisitorDocumentTypeRequest documentTypeReq)
        {
            var documentType = _mapper.Map<VisitorDocumentType>(documentTypeReq);
            return await _visitorRepository.UpdateDocumentType(documentType);
        }

        public async Task<int> VisitorCount(int month, int year)
        {
            return await _visitorRepository.VisitorCount(month,year);
        }
    }
}
