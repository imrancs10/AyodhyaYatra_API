using AyodhyaYatra.API.Config;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Repositories;
using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Repository.IRepository;
using AyodhyaYatra.API.Services;
using AyodhyaYatra.API.Services.Interfaces;
using AyodhyaYatra.API.Services.IServices;
using AyodhyaYatra.API.Utility;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Middleware
{
    public static class Registrar
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>()
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IMasterDataRepository, MasterDataRepository>()
                .AddScoped<IMasterDataService, MasterDataService>()
                .AddScoped<IMasterAttractionRepository, MasterAttractionRepository>()
                .AddScoped<IMasterAttractionService, MasterAttractionService>()
                .AddScoped<IMasterAttractionTypeRepository, MasterAttractionTypeRepository>()
                .AddScoped<IMasterAttractionTypeService, MasterAttractionTypeService>()
                .AddScoped<IAttractionYatraMapperRepository, AttractionYatraMapperRepository>()
                .AddScoped<IAttractionYatraMapperService, AttractionYatraMapperService>()
                .AddScoped<IImageStoreRepository, ImageStoreRepository>()
                .AddScoped<IFileStorageRepository, FileStorageRepository>()
                .AddScoped<IFileStorageService, FileStorageService>()
                .AddScoped<IFileUploadService, FileUploadService>()
                .AddScoped<IMailService, MailService>()
                .AddScoped<INewsUpdateService, NewsUpdateService>()
                .AddScoped<IExcelReader, ExcelReader>()
                .AddScoped<IQrCodeService, QrCodeService>()
                .AddScoped<IGalleryService, GalleryService>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<IFeedbackService, FeedbackService>();

            return services;
        }

        public static IServiceCollection RegisterDataServices(this IServiceCollection services)
        {
            //var DefaultConnection = "workstation id=mssql-88450-0.cloudclusters.net,12597;TrustServerCertificate=true;user id=LaBeachUser;pwd=Gr8@54321;data source=mssql-88450-0.cloudclusters.net,12597;persist security info=False;initial catalog=ayodhya_yatra";
            var DefaultConnection = "workstation id=mssql-88450-0.cloudclusters.net,12597;TrustServerCertificate=true;user id=LaBeachUser;pwd=Gr8@54321;data source=mssql-88450-0.cloudclusters.net,12597;persist security info=False;initial catalog=ayodhya_yatra";
            services.AddDbContext<AyodhyaYatraContext>(
                options => { options.UseSqlServer(DefaultConnection); }
            );
            var serviceProvider = services.BuildServiceProvider();
            ApplyMigrations(serviceProvider);
            return services;
        }


        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AyodhyaYatraContext>();
            //db.Database.Migrate();
        }
    }
}