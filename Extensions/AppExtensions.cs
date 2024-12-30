
using MassTransit;
using rabbitmq.Bus;

namespace rabbitmq.Controllers;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<RelatorioSolicitadoEventConsumer>();

            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("amqp://guest:guest@IP_SERVIDOR");
                cfg.ConfigureEndpoints(ctx);
            });
        });

    }
}
