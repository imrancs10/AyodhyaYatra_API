using AutoMapper;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Visitor;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;
using System.Text.Json;

namespace AyodhyaYatra.API.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;
        private readonly IQrCodeService _qrCodeService;
        private readonly IConfiguration _configuration;
        public VisitorService(IVisitorRepository visitorRepository,IMapper mapper,IQrCodeService qrCodeService, IConfiguration configuration)
        {
            _mapper = mapper;
            _visitorRepository = visitorRepository;
            _qrCodeService = qrCodeService;
            _configuration = configuration;
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

            var visitorResponse= _mapper.Map<VisitorResponse>(await _visitorRepository.GetVisitor(visitorId));
            var visitorJson=JsonSerializer.Serialize(visitorResponse);
           
            visitorResponse.QrImage = _qrCodeService.GenerateVisitorQrCode(visitorJson, visitorResponse.UniqueId.ToString());
            return visitorResponse;
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
            var data = _mapper.Map<List<VisitorResponse>>(await _visitorRepository.GetVisitor(mobileNo));
            string? ImagePath = _configuration.GetSection("VisitorQrCodesPath").Value;
            foreach (var item in data)
            {
                item.QrImage = Path.Combine(ImagePath, item.UniqueId.ToString() + ".png");
            }
           return data;
        }

        public async Task<bool> UpdateDocumentType(VisitorDocumentTypeRequest documentTypeReq)
        {
            var documentType = _mapper.Map<VisitorDocumentType>(documentTypeReq);
            return await _visitorRepository.UpdateDocumentType(documentType);
        }

        public async Task<VisitorResponse> ValidateVisitor(Guid uniqueId)
        {
            return _mapper.Map<VisitorResponse>(await _visitorRepository.ValidateVisitor(uniqueId));
        }

        public async Task<int> VisitorCount(int month, int year)
        {
            return await _visitorRepository.VisitorCount(month,year);
        }
    }
}
