using EventManagementPlatform.Api.Extensions;
using EventManagementPlatform.Application.Interfaces;
using EventManagementPlatform.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<IHasher,  Hasher>();
    builder.Services.AddMappers();
    builder.Services.AddRepositories();
    builder.Services.AddEmpDbContext(builder.Configuration);
    builder.Services.AddMediatr();
    
    if (builder.Environment.IsDevelopment())
        builder.Services.AddSwaggerDocumentation();
}

var app = builder.Build();

if (builder.Environment.IsDevelopment())
    app.UseSwaggerDocumentation();

app.MapControllers();

app.Run();