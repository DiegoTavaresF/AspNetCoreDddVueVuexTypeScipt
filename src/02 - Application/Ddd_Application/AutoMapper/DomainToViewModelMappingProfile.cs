using AutoMapper;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.Entities.Tarefas;

namespace Ddd.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tarefa, TarefaFormDto>();
        }
    }
}