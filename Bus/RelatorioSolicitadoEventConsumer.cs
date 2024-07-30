using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using rabbitmq.Relatorios;

namespace rabbitmq.Bus;
internal sealed class RelatorioSolicitadoEventConsumer : IConsumer<RelatorioSolicitadoEvent>
{
    private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;

    public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
    {
        _logger.LogInformation($"Processando Relatorio: {context.Message.Id} - {context.Message.Nome}");

        await Task.Delay(10000);

        var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == context.Message.Id);

        if (relatorio != null)
        {
            relatorio.Status = "Processado";
            relatorio.ProcessedTime = DateTime.Now;
        }

        _logger.LogInformation($"Relatorio Processado : {context.Message.Id} - {context.Message.Nome}");

    }

}
