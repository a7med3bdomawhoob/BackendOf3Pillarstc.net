using DAL.Context;
using DAL.Database;
using HubTask.Extensions;
using HubTask.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
       
  using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
   var builder = WebApplication.CreateBuilder(args);
   // Access the configuration
   var configuration = new ConfigurationBuilder()
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json")
       .Build();
   builder.Services.AddDbContext<context>(options =>
   {
       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
   });
   builder.Services.AddDbContext<IdentityContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDefaultConnection")));
   // Add Identity
   builder.Services.AddIdentity<AppUser, IdentityRole>()
       .AddEntityFrameworkStores<IdentityContext>()
       .AddDefaultTokenProviders();
   builder.Services.AddDbContext<context>(options =>
       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
   var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
   builder.Services.AddAuthentication(options =>
   {
       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
   })
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(key)
       };
   });
   builder.Services.AddMyScopedSeviceExt(configuration);  //from My Extension
   builder.Services.AddControllers();
   // Add logging services
   builder.Logging.AddConsole();
   builder.Services.AddEndpointsApiExplorer();
   builder.Services.AddSwaggerGen();
   builder.Services.AddCors(opt =>
   {
       //I Must accept only listed port but now allow all to test
       opt.AddPolicy("CorsPolicy", policy =>
       {
           policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
       });
   });
   var app = builder.Build();
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.UseSwagger();
       app.UseSwaggerUI();
   }
   app.UseStaticFiles(); //To Allow Acess Wwwroot Folder From React Response
   app.UseHttpsRedirection();
   app.UseCors("CorsPolicy");//for link api with react
   app.UseAuthorization();
   app.UseMiddleware<ErrorHandlingMiddleware>();
   app.MapControllers();
   app.Run();
   