using Api01.Application.Mappings;
using Api01.Application.Services;
using Api01.Application.Services.Interfaces;
using Api01.Domain.Repositories;
using Api01.Infra.Data.Context;
using Api01.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Infra.IoC;

public static class DependencyInject
{
    //injecao para os repositorios / infraestrutura do proejto
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //injetando o banco
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();

        return services;
    }

    
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        //lembrar de instalar a dependency do AutoMapper e injetar aqui
        services.AddAutoMapper(typeof(DomainToDtoMapping));

        services.AddScoped<IPersonService, PersonService>();

        return services;
    }
    //agora devemos referenciar essa classe no program
}
