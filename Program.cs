using rabbitmq.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRabbitMQService();

var app = builder.Build();

app.AddApiEndpoints();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();


app.Run();
