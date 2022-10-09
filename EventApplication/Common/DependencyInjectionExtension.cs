using EventApplication.Data;
using EventApplication.Services;

namespace EventApplication.Common
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddSingleton<IEventStore, EventStore>();
        }
    }
}
