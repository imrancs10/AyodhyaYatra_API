using KaashiYatra.API.Models;
using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.ImageStore;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.Enums;

namespace KaashiYatra.API.Services.IServices
{
    public interface IFileUploadService
    {
        Task<string> UploadDesignSamplePhoto(IFormFile files, int sampleId);
        Task<List<ImageStoreResponse>> UploadPhoto(List<FileUploadRequest> fileUploadRequest);
        Task<bool> DeleteFile(int id);
    }
}