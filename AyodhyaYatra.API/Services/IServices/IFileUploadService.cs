using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.ImageStore;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Services.IServices
{
    public interface IFileUploadService
    {
        Task<string> UploadDesignSamplePhoto(IFormFile files, int sampleId);
        Task<List<ImageStoreResponse>> UploadPhoto(List<FileUploadRequest> fileUploadRequest);
        Task<bool> DeleteFile(int id);

        bool DeleteExistingThumbAndGenerateNewThumb(int height = 200,int width=300);
    }
}