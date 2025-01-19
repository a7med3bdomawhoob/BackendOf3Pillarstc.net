using BLL.Interfaces;
using BLL.Services;
using HubTask.Mapper;
namespace HubTask.Extensions
{
    public static class ScopedServiceExtention
    {
        public static IServiceCollection AddMyScopedSeviceExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>(); //
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
