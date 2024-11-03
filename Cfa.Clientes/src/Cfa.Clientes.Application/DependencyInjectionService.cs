using AutoMapper;
using Cfa.Clientes.Application.Configuration;
using Cfa.Clientes.Application.DataBase.Clientes.Commands.CrearCliente;
using Cfa.Clientes.Application.DataBase.Clientes.Commands.DeleteClient;
using Cfa.Clientes.Application.DataBase.Clientes.Commands.UpdateCliente;
using Cfa.Clientes.Application.DataBase.Clientes.Queries.GetAllClientFilter;
using Cfa.Clientes.Application.Validators.Cliente;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cfa.Clientes.Application;

public static class DependencyInjectionService
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile(new MapperProfile());
        });


        services.AddSingleton(mapper.CreateMapper());

        #region Client 
        services.AddTransient<ICreateClientCommand, CreateClientCommand>();
        services.AddTransient<IUpdateClientCommand, UpdateClientCommand>();
        services.AddTransient<IDeleteClientModel, DeleteClientCommand>();
        services.AddTransient<IGetAllClientFilterQuery, GetAllClientFilterQuery>();
        #endregion

        #region Validator
        services.AddScoped<IValidator<CreateClientModel>, ClienteValidator>();
        services.AddScoped<IValidator<UpdateClientModel>, UpdateClientValidator>();
        services.AddScoped<IValidator<DeleteClientModel>, DeleteClientValidator>();

        #endregion


        return services;
    }
}