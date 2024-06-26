using FluentValidation.AspNetCore;
using AyodhyaYatra.API.Config;
using AyodhyaYatra.API.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AyodhyaYatra.API.Middleware;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using AyodhyaYatra.API.Dto;

var _policyName = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterDataServices();
builder.Services.RegisterValidator();
builder.Services.AddControllers()
    .AddFluentValidation(c =>
    c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "WebAPI",
        Description = "Ayodhya Yatra Web API"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});
builder.Services.AddSingleton(MapperConfig.GetMapperConfig());
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ConfigManager.AppSetting["JWT:ValidIssuer"],
        ValidAudience = ConfigManager.AppSetting["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigManager.AppSetting["JWT:Secret"]))
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(_policyName,
        builder =>
        {
            builder.SetIsOriginAllowed(isOriginAllowed: _ => true).WithOrigins("https://ayodhya-dham.in", "http://localhost:3000/", "*")
            .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    //if (app.Environment.IsDevelopment())
    options.SwaggerEndpoint("/swagger/V1/swagger.json", "Ayodhya Yatra Web API");
    //else 
    //    options.SwaggerEndpoint("/api/swagger/V1/swagger.json", "Ayodhya Yatra Web API");
    options.DocExpansion(DocExpansion.None);
});

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(_policyName);
app.Run();
