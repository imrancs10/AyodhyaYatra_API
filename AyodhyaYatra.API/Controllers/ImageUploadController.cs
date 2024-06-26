﻿using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyodhyaYatra.API.Controllers
{
    [Route(StaticValues.APIPrefix)]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileService;
        private readonly IFileStorageService _fileStoreService;
        private readonly IMapper _mapper;

        public ImageUploadController(IFileUploadService fileUploadService,IMapper mapper, IFileStorageService fileStoreService)
        {
            _fileService = fileUploadService;
            _mapper = mapper;
            _fileStoreService = fileStoreService;
        }
        [ProducesResponseType(typeof(ImageStoreResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost(StaticValues.FileUploadPath)]
        public async Task<List<ImageStoreResponse>> UpdateFile([FromQuery] FileUploadQueryRequest request, [FromForm] List<IFormFile> files)
        {
            List<FileUploadRequest> requests = new();
            foreach (IFormFile file in files)
            {
                var newRequest= _mapper.Map<FileUploadRequest>(request);
                newRequest.File = file;
                requests.Add(newRequest);
            }
            return  await _fileService.UploadPhoto(requests);
        }

        [ProducesResponseType(typeof(List<ImageStoreResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileGetImageByModNameModIdPath)]
        public async Task<List<ImageStoreResponse>> GetImageStore([FromQuery] ModuleNameEnum moduleName, [FromQuery] int moduleId,[FromQuery] string imageType="image")
        {
            return await _fileStoreService.GetImageStore(moduleName, moduleId, imageType);
        }

        [ProducesResponseType(typeof(List<ImageStoreResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileGetImageByModNameModNamePath)]
        public async Task<List<ImageStoreResponse>> GetImageStoreByModule([FromQuery] ModuleNameEnum moduleName)
        {
            return await _fileStoreService.GetByModuleName(moduleName.ToString());
        }

        [ProducesResponseType(typeof(List<ImageStoreResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileGetImageByModNameModIdsPath)]
        public async Task<List<ImageStoreResponse>> GetImageStore([FromQuery] ModuleNameEnum moduleName, [FromQuery] List<int> moduleIds, [FromQuery] string imageType = "image")
        {
            return await _fileStoreService.GetImageStore(moduleName, moduleIds, imageType);
        }
        [ProducesResponseType(typeof(List<ImageStoreResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileGetImageByModNameModIdSeqPath)]
        public async Task<List<ImageStoreResponse>> GetImageStore([FromQuery] ModuleNameEnum moduleName, [FromQuery] int moduleId,[FromQuery] int sequence, [FromQuery] string imageType = "image")
        {
            return await _fileStoreService.GetImageStore(moduleName, moduleId,sequence, imageType);
        }

        [ProducesResponseType(typeof(List<ImageStoreWithNameResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileGetImageByModNamePagingPath)]
        public async Task<List<ImageStoreWithNameResponse>> GetImageStore([FromQuery] ModuleNameEnum moduleName, [FromQuery] int pageNo, [FromQuery] int pageSize,[FromQuery] bool allImage=false, [FromQuery] string imageType = "360degreeimage")
        {
            return await _fileStoreService.GetImageStore(moduleName, pageNo,pageSize, allImage, imageType);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete(StaticValues.FileDeleteImageByIdPath)]
        public async Task<bool> DeleteFile([FromQuery] int id)
        {
            return await _fileService.DeleteFile(id);
        }
        
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet(StaticValues.FileDeleteExistingThumbAndGenerateNewThumbPath)]
        public bool DeleteExistingThumbAndGenerateNewThumb([FromQuery] int height=200,[FromQuery] int width=300)
        {
            return _fileService.DeleteExistingThumbAndGenerateNewThumb();
        }
    }
}
