using AyodhyaYatra.API.Services.IServices;
using Microsoft.Extensions.Configuration;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AyodhyaYatra.API.Services
{
    public class QrCodeService : IQrCodeService
    {
        private readonly IConfiguration _configuration;
        private readonly IMasterAttractionService _templeService;
        public QrCodeService(IConfiguration configuration, IMasterAttractionService templeService)
        {
            _configuration = configuration;
            _templeService = templeService;
        }
        public void GenerateQrCode(string qrCodeText, string fileName)
        {
            string basePath = GetImageBasePath();
            var fullFilePath = Path.Combine(basePath, fileName+".png");

            if (File.Exists(fullFilePath))
                File.Delete(fullFilePath);

            QRCodeGenerator QrGenerator = new();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new (QrCodeInfo);
            Bitmap QrBitmap = qrCode.GetGraphic(60);
            QrBitmap.Save(fullFilePath,ImageFormat.Png);
        }

        public async Task<bool> GenerateMasterAttractionQrCode()
        {
            var attractionIds = await _templeService.GetMasterAttractionIds();
            string qrCodeUrl = _configuration.GetSection("QrCodeUrlBasePath").Value;
            foreach (var attractionId in attractionIds)
            {
                var qrCodeFileName = $"AttractionId-{attractionId}";
                GenerateQrCode(qrCodeUrl + attractionId, qrCodeFileName);
            }
          
            return default(bool);
        }

        private string GetImageBasePath()
        {
            string? ImagePath = _configuration.GetSection("QrCodesPath").Value;
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImagePath);
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
            return basePath;
        }

        public string GenerateVisitorQrCode(string qrCodeText, string fileName)
        {
            string? ImagePath = _configuration.GetSection("VisitorQrCodesPath").Value;
            var absPath= Path.Combine(ImagePath, fileName + ".png");
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImagePath);
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var fullFilePath = Path.Combine(basePath, fileName + ".png");

            if (File.Exists(fullFilePath))
                File.Delete(fullFilePath);

            QRCodeGenerator QrGenerator = new();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(QrCodeInfo);
            Bitmap QrBitmap = qrCode.GetGraphic(60);
            QrBitmap.Save(fullFilePath, ImageFormat.Png);
            return absPath;
        }
    }
}
