using FluentValidation;
using Mediatr.CQRS.Behaviours;
using Mediatr.CQRS.Processors;
using MediatR;
using MediatR.Pipeline;
using RWA.Web;
using Serilog;
using VWB.Api.Queries;
using VWB.App.QueryHandlers;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Mediatr related stuff
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(GetFruitQueryHandler).Assembly);
});

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(GenericPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));
builder.Services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(GenericRequestPostProcessor<,>));

// register reuqest validators
builder.Services.RegisterAllTypesAsInterface(typeof(GetFruitQuery).Assembly, typeof(IValidator<>));

// adding httpclient
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-7.0

var app = builder.Build();

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

