using AutoMapper;
using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Request.ImageStore;
using KaashiYatra.API.DTO.Request.NewsUpdate;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.DTO.Response.Image;
using KaashiYatra.API.DTO.Response.MasterData;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Config
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
            CreateMap<MasterDivision, DropdownResponse>()
               .ForMember(des => des.EnValue, src => src.MapFrom(x => x.DivisionName));

            CreateMap<MasterPadav, MasterPadavResponse>()
                .ForMember(des => des.EnYatraName, src => src.MapFrom(x => x.Yatra.EnName))
                .ForMember(des => des.HiYatraName, src => src.MapFrom(x => x.Yatra.HiName))
                .ForMember(des => des.EnPadavName, src => src.MapFrom(x => x.EnName))
                .ForMember(des => des.HiPadavName, src => src.MapFrom(x => x.HiName));

            CreateMap<MasterYatra, DropdownResponse>()
                .ForMember(des => des.EnValue, src => src.MapFrom(x => x.EnName))
                .ForMember(des => des.HiValue, src => src.MapFrom(x => x.HiName))
                .ForMember(des => des.TaValue, src => src.MapFrom(x => x.TaName))
                .ForMember(des => des.TeValue, src => src.MapFrom(x => x.TeName))
                .ForMember(des => des.ParentId, src => src.MapFrom(x => x.ParentYatraId));
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

            CreateMap<MasterDataRequest, MasterDivision>()
                .ForMember(des => des.DivisionName, src => src.MapFrom(x => x.Value));

            CreateMap<MasterPadavRequest, MasterPadav>()
                .ForMember(des => des.YatraId, src => src.MapFrom(x => x.YatraId))
                .ForMember(des => des.EnName, src => src.MapFrom(x => x.EnPadavName))
                .ForMember(des => des.HiName, src => src.MapFrom(x => x.HiPadavName))
                .ForMember(des => des.TaName, src => src.MapFrom(x => x.TaPadavName))
                .ForMember(des => des.TeName, src => src.MapFrom(x => x.TePadavName))
                .ForMember(des => des.EnDescription, src => src.MapFrom(x => x.EnDescription))
                .ForMember(des => des.HiDescription, src => src.MapFrom(x => x.HiDescription));

            CreateMap<MasterDataRequest, MasterYatra>()
                .ForMember(des => des.EnName, src => src.MapFrom(x => x.Value));

            CreateMap<MasterYatraRequest, MasterYatra>()
              .ForMember(des => des.EnName, src => src.MapFrom(x => x.enName))
              .ForMember(des => des.HiName, src => src.MapFrom(x => x.hiName))
              .ForMember(des => des.TaName, src => src.MapFrom(x => x.taName))
              .ForMember(des => des.TeName, src => src.MapFrom(x => x.teName));
            CreateMap<MasterData, MasterDataExt>();
            CreateMap<MasterYatra, MasterDataExt>();
            CreateMap<Temple, MasterDataExt>();
            CreateMap<Temple, MasterData>();
            #endregion

            #region Temple
            CreateMap<TempleRequest, Temple>();
            CreateMap<Temple, TempleResponse>()
                  .ForMember(des => des.PadavHiName, src => src.MapFrom(x => x.Padav.HiName))
                  .ForMember(des => des.PadavEnName, src => src.MapFrom(x => x.Padav.EnName))
                  .ForMember(des => des.PadavTaName, src => src.MapFrom(x => x.Padav.TaName))
                  .ForMember(des => des.PadavTeName, src => src.MapFrom(x => x.Padav.TeName));
            CreateMap<PagingResponse<Temple>, PagingResponse<TempleResponse>>();
            CreateMap<Temple, MasterData>();
            CreateMap<PagingResponse<MasterData>, PagingResponse<MasterResponse>>();
            //CreateMap<TempleCategory, TempleCategoryResponse>();
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
