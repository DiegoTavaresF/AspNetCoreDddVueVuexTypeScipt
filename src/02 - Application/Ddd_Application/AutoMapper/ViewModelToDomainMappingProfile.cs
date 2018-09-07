using AutoMapper;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.Entities.Tarefas;

namespace Ddd.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TarefaFormDto, Tarefa>();
        }
    }
}