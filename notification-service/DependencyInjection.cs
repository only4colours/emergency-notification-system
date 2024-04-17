using Twilio;

namespace notification_service;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        TwilioClient.Init(
            configuration.GetValue<string>("Twilio:AccountSid"), 
            configuration.GetValue<string>("Twilio:AuthToken"));
    }
}