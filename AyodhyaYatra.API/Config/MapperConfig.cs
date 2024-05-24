using AutoMapper;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Request.ImageStore;
using AyodhyaYatra.API.DTO.Request.MasterAttraction;
using AyodhyaYatra.API.DTO.Request.NewsUpdate;
using AyodhyaYatra.API.DTO.Request.Visitor;
using AyodhyaYatra.API.DTO.Request.Yatra;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.DTO.Response.Image;
using AyodhyaYatra.API.DTO.Response.MasterAttraction;
using AyodhyaYatra.API.DTO.Response.MasterData;
using AyodhyaYatra.API.DTO.Response.Visitor;
using AyodhyaYatra.API.DTO.Response.Yatra;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region Login

            #endregion

            #region User
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>()
                .ForMember(des => des.EmailVerificationCode, src => src.MapFrom(x => Guid.NewGuid().ToString()))
                .ForMember(des => des.EmailVerificationCodeExpireOn, src => src.MapFrom(x => DateTime.Now.AddHours(24)));
            #endregion

            #region Common

            CreateMap<MasterYatra, DropdownResponse>()
                .ForMember(des => des.EnValue, src => src.MapFrom(x => x.EnName))
                .ForMember(des => des.HiValue, src => src.MapFrom(x => x.HiName))
                .ForMember(des => des.TaValue, src => src.MapFrom(x => x.TaName))
                .ForMember(des => des.TeValue, src => src.MapFrom(x => x.TeName));
            CreateMap<MasterData, DropdownResponse>()
                 .ForMember(des => des.EnValue, src => src.MapFrom(x => x.EnName))
                .ForMember(des => des.HiValue, src => src.MapFrom(x => x.HiName))
                .ForMember(des => des.TaValue, src => src.MapFrom(x => x.TaName))
                .ForMember(des => des.TeValue, src => src.MapFrom(x => x.TeName));
            CreateMap<MasterDataExt, DropdownResponse>()
                .ForMember(des => des.EnValue, src => src.MapFrom(x => x.EnName))
                .ForMember(des => des.HiValue, src => src.MapFrom(x => x.HiName))
                .ForMember(des => des.TaValue, src => src.MapFrom(x => x.TaName))
                .ForMember(des => des.TeValue, src => src.MapFrom(x => x.TeName))
               .ForMember(des => des.ParentId, src => src.MapFrom(x => x.ParentYatraId));


            CreateMap<MasterDataRequest, MasterYatra>()
                .ForMember(des => des.EnName, src => src.MapFrom(x => x.Value));

            CreateMap<MasterYatraRequest, MasterYatra>()
              .ForMember(des => des.EnName, src => src.MapFrom(x => x.enName))
              .ForMember(des => des.HiName, src => src.MapFrom(x => x.hiName))
              .ForMember(des => des.TaName, src => src.MapFrom(x => x.taName))
              .ForMember(des => des.TeName, src => src.MapFrom(x => x.teName));
            CreateMap<MasterData, MasterDataExt>();
            CreateMap<MasterYatra, MasterDataExt>();
            CreateMap<MasterAttraction, MasterDataExt>();
            CreateMap<MasterAttraction, MasterData>();
            #endregion

            #region MasterAttraction
            CreateMap<MasterAttractionRequest, MasterAttraction>();
            CreateMap<MasterAttraction, MasterAttractionResponse>()
                .ForMember(des => des.AttractionType, src => src.MapFrom(x => x.MasterAttractionType.Name));
            CreateMap<PagingResponse<MasterAttraction>, PagingResponse<MasterAttractionResponse>>();
            CreateMap<MasterAttraction, MasterData>();
            CreateMap<PagingResponse<MasterData>, PagingResponse<MasterResponse>>();
            CreateMap<MasterAttractionTypeRequest, MasterAttractionType>();
            CreateMap<MasterAttractionType, MasterAttractionTypeResponse>();
            CreateMap<PagingResponse<MasterAttractionType>, PagingResponse<MasterAttractionTypeResponse>>();
            #endregion

            #region Yatra
            CreateMap<YatraAttractionMapperRequest, YatraAttractionMapper>();
            CreateMap<YatraAttractionMapper, YatraAttractionMapperResponse>()
                .ForMember(des => des.Yatra, src => src.MapFrom(x => x.MasterYatra))
                .ForMember(des => des.MasterAttractionResponse, src => src.MapFrom(x => x.MasterAttraction))
                .ForMember(des => des.MasterAttractionName, src => src.MapFrom(x => x.MasterAttraction.EnName))
                .ForMember(des => des.YatraName, src => src.MapFrom(x => x.MasterYatra.EnName));
            CreateMap<PagingResponse<YatraAttractionMapper>, PagingResponse<YatraAttractionMapperResponse>>();
            #endregion

            #region Visitor
            CreateMap<VisitorRequest, Visitor>();
            CreateMap<Visitor, VisitorResponse>()
                .ForMember(des => des.DocumentType, src => src.MapFrom(x => x.VisitorDocumentType.Name));
            CreateMap<PagingResponse<Visitor>, PagingResponse<VisitorResponse>>();
            CreateMap<VisitorDocumentTypeRequest, VisitorDocumentType>();
            CreateMap<VisitorDocumentType, VisitorDocumentTypeResponse>();
            CreateMap<PagingResponse<VisitorDocumentType>, PagingResponse<VisitorDocumentTypeResponse>>();
            #endregion

            #region Image
            CreateMap<ImageStore, ImageStoreResponse>();
            CreateMap<ImageStore, ImageStoreWithName>();
            CreateMap<ImageStoreWithName, ImageStoreWithNameResponse>();
            CreateMap<ImageStoreRequest, ImageStore>();
            CreateMap<FileUploadQueryRequest, FileUploadRequest>();
            #endregion

            #region MasterData
            CreateMap<MasterRequest, MasterData>();
            CreateMap<MasterData, MasterResponse>()
                             .ForMember(des => des.MasterDataTypeName, src => src.MapFrom(x => x.MasterDataType.ToString()));
            CreateMap<MasterYatra, MasterResponse>();
            CreateMap<MasterDataExt, MasterResponse>()
                 .ForMember(des => des.MasterDataTypeName, src => src.MapFrom(x => x.MasterDataType.ToString()));
            CreateMap<MasterYatra, MasterData>();

            CreateMap<NewsUpdate, NewsUpdateResponse>();
            CreateMap<NewsUpdateRequest, NewsUpdate>()
                .ForMember(des => des.EventDate, src => src.MapFrom(x => !string.IsNullOrEmpty(x.EventDate) ? x.EventDate : null));

            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();
            #endregion

            #region Gallery
            CreateMap<PhotoAlbumRequest, PhotoAlbum>();
            CreateMap<PhotoAlbum, PhotoAlbumResponse>();

            CreateMap<PhotoGalleryRequest, PhotoGallery>();
            CreateMap<PhotoGallery, PhotoGalleryResponse>()
                  .ForMember(des => des.PhotoAlbumName, src => src.MapFrom(x => x.PhotoAlbum.EnName));

            CreateMap<AudioGalleryRequest, AudioGallery>();
            CreateMap<AudioGallery, AudioGalleryResponse>();

            CreateMap<VideoGalleryRequest, VideoGallery>();
            CreateMap<VideoGallery, VideoGalleryResponse>();

            CreateMap<ThreeSixtyDegreeGalleryRequest, ThreeSixtyDegreeGallery>();
            CreateMap<ThreeSixtyDegreeGallery, ThreeSixtyDegreeGalleryResponse>();
            #endregion
        }

        public static IMapper GetMapperConfig()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperConfig()); });
            return config.CreateMapper();
        }
    }
}
