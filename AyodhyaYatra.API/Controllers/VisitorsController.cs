using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.Visitor;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.Services;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Text.Json;

namespace AyodhyaYatra.API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        public VisitorsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPut(StaticValues.VisitorAddDocTypePath)]
        public async Task<int> AddDocumentType([FromBody] VisitorDocumentTypeRequest documentType)
        {
            return await _visitorService.AddDocumentType(documentType);
        }

        [HttpPut(StaticValues.VisitorAddPath)]
        public async Task<VisitorResponse> AddVisitor([FromBody] VisitorRequest visitor)
        {
            var resp= await _visitorService.AddVisitor(visitor);
            var respJson= JsonSerializer.Serialize(resp);
            resp.QrImage =  GenerateQrCodeBytes(respJson);
            return resp;
        }

        [HttpDelete(StaticValues.VisitorDeleteDocTypePath)]
        public async Task<bool> DeleteDocumentType([FromRoute] int id)
        {
           return await _visitorService.DeleteDocumentType(id);
        }

        [HttpGet(StaticValues.VisitorGetDocTypePath)]
        public async Task<List<VisitorDocumentTypeResponse>> GetsDocumentType()
        {
            return await _visitorService.GetsDocumentType();
        }

        [HttpGet(StaticValues.VisitorGetPath)]
        public async Task<List<VisitorResponse>> GetsVisitors([FromQuery] PagingRequest pagingRequest)
        {
           return await _visitorService.GetsVisitors(pagingRequest);
        }

        [HttpPost(StaticValues.VisitorUpdateDocTypePath)]
        public async Task<bool> UpdateDocumentType([FromBody]VisitorDocumentTypeRequest documentType)
        {
            return await _visitorService.UpdateDocumentType(documentType);
        }

        [HttpGet(StaticValues.VisitorGetCountPath)]
        public async Task<int> VisitorCount([FromQuery] int month,[FromQuery] int year)
        {
            return await _visitorService.VisitorCount(month, year);
        }

        private static byte[] GenerateQrCodeBytes(string content)
        {
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            using var bitmap = qrCode.GetGraphic(20);
            using var stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
