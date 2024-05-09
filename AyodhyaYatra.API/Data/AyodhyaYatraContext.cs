using AyodhyaYatra.API.Config;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AyodhyaYatra.API.Data
{
    public class AyodhyaYatraContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private readonly string _defaultConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AyodhyaYatraContext(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            //_defaultConnection = "workstation id=mssql-88450-0.cloudclusters.net,12597;TrustServerCertificate=true;user id=LaBeachUser;pwd=Gr8@54321;data source=mssql-88450-0.cloudclusters.net,12597;persist security info=False;initial catalog=ayodhya_yatra";
            _defaultConnection = "workstation id=mssql-88450-0.cloudclusters.net,12597;TrustServerCertificate=true;user id=LaBeachUser;pwd=Gr8@54321;data source=mssql-88450-0.cloudclusters.net,12597;persist security info=False;initial catalog=ayodhya_yatra";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(_defaultConnection);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MasterAttraction> MasterAttractions { get; set; }
        public DbSet<MasterAttractionType> MasterAttractionTypes { get; set; }
        public DbSet<ImageStore> ImageStores { get; set; }
        public DbSet<MasterYatra> MasterYatras { get; set; } 
        public DbSet<YatraAttractionMapper> YatraAttractionMappers { get; set; }
        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<NewsUpdate> NewsUpdates { get; set; }
        public DbSet<ThreeSixtyDegreeGallery> ThreeSixtyDegreeGallery { get; set; }
        public DbSet<AudioGallery> AudioGallery { get; set; }
        public DbSet<VideoGallery> VideoGallery { get; set; }
        public DbSet<PhotoGallery> PhotoGallery { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbum { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorDocumentType> VisitorDocumentTypes { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public override int SaveChanges()
        {
            AddDateTimeStamp();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddDateTimeStamp();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void AddDateTimeStamp()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                var hasChange = entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified;
                if (!hasChange) continue;
                if (!(entityEntry.Entity is BaseModel baseModel)) continue;
                var now = DateTime.Now;
                int? userId = null;
                if ((bool)_httpContextAccessor.HttpContext?.Request.Headers.ContainsKey("userId"))
                {
                    string value = _httpContextAccessor.HttpContext?.Request.Headers["userId"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (int.TryParse(value, out int newUserId))
                        {
                            userId = newUserId;
                        }
                    }
                }
                if (entityEntry.State is EntityState.Added)
                {
                    baseModel.CreatedBy = 0;
                    baseModel.CreatedAt = now;
                }
                else
                {
                    baseModel.UpdatedBy = 0;
                    entityEntry.Property("CreatedAt").IsModified = false;
                    baseModel.UpdatedAt = now;
                }
            }
        }
    }
}
