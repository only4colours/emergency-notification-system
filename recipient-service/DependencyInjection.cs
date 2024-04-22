using Microsoft.EntityFrameworkCore;
using recipient_service.Database;

namespace recipient_service;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContext<RecipientDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("ConnectionStrings:Postgres")));
    }
}