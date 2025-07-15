using System.Reflection;
using EventManagementPlatform.Application.Features.Events.Commands.CreateEvent;
using EventManagementPlatform.Application.Mappers.ForEvent.PublicMapper;
using EventManagementPlatform.Application.Mappers.ForOrganizer.PublicMapper;
using EventManagementPlatform.Application.Mappers.ForVisitor.PublicMapper;
using EventManagementPlatform.Domain.IRepositories;
using EventManagementPlatform.Infrastructure.Persistence;
using EventManagementPlatform.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EventManagementPlatform.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddMediatr(this IServiceCollection service)
    {
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateEventCommandHandler).Assembly);
        });
        
        return service;
    }
    public static IServiceCollection AddEmpDbContext(this IServiceCollection service, IConfiguration config)
    {
        service.AddDbContext<EmpDbContext>(options => 
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        
        return service;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IEventRepository, EventRepoPostgres>();
        service.AddScoped<IOrganizerRepository, OrganizerRepoPostgres>();
        service.AddScoped<IUnitOfWork, UnitOfWorkPostgres>();
        service.AddScoped<IVisitorRepository, VisitorRepoPostgres>();
        service.AddScoped<IVisitorInEventRepository, VisitorInEventRepoPostgres>();
        
        return service;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection service)
    {
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Event Management Platform Api",
                Version = "v1",
                Description = "API Documentation",
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath);

        });
        
        return service;
    }
    public static IServiceCollection AddMappers(this IServiceCollection service)
    {
        service.AddSingleton<IEventPublicMapper, EventPublicMapper>();
        service.AddSingleton<IOrganizerPublicMapper, OrganizerPublicMapper>();
        service.AddSingleton<IVisitorPublicMapper, VisitorPublicMapper>();
        
        return service;
    }
}
