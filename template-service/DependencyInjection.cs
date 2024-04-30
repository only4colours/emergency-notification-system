using Microsoft.EntityFrameworkCore;
using template_service.Database;
using template_service.Database.Repositories;

namespace template_service;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContext<TemplateDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("ConnectionStrings:Postgres")));
        
        services.AddScoped<ITemplatesRepository, PostgresTemplatesRepository>();
    }
}