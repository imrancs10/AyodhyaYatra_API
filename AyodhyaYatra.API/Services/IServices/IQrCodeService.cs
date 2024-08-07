﻿namespace AyodhyaYatra.API.Services.IServices
{
    public interface IQrCodeService
    {
        void GenerateQrCode(string qrCodeText, string fileName);
        string GenerateVisitorQrCode(string qrCodeText, string fileName);
        Task<bool> GenerateMasterAttractionQrCode();
    }
}
