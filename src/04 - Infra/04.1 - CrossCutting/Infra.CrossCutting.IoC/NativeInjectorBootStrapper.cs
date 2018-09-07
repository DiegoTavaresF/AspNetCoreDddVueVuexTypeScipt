using Ddd.Application.Services.Tarefas;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Application.Services.Tarefas.Validator;
using Ddd.Domain.Entities.Usuarios;
using Ddd.Infra.CrossCutting.Identity.Authorization;
using Ddd.Infra.CrossCutting.Identity.Models;
using Ddd.Infra.CrossCutting.Identity.Services;
using Ddd.Infra.Data.Contexts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ddd.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application

            services.AddScoped<ITarefaAppService, TarefaAppService>();

            services.AddTransient<IValidator<TarefaFormDto>, TarefaFormDtoValidator>();

            // Infra - Data
            services.AddScoped<IContextBase, ContextBase>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}