
using MassTransit;
using rabbitmq.Relatorios;

namespace rabbitmq.Controllers
{
    /// <summary>
    /// relatorio na memoria simualr banco
    /// </summary>
    internal static class ApiEndpoints
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            app.MapPost("solicitar-relatorio/{name}", async (string name, IBus bus) =>
            {
                var soliitacao = new SolicitacaoRelatorio()
                {
                    Id = Guid.NewGuid(),
                    Nome = name,
                    Status = "Pendente",
                    ProcessedTime = null
                };
                Lista.Relatorios.Add(soliitacao);

                var eventRequest = new RelatorioSolicitadoEvent(soliitacao.Id, soliitacao.Nome);

                await bus.Publish(eventRequest);

                return Results.Ok(soliitacao);
            });

            app.MapGet("relatorios", () =>
            {
                return Results.Ok(Lista.Relatorios);
            });
        }

    }
}