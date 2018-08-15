using AutoMapper;
using Ddd.Application.Services.Produtos.Dtos;
using Ddd.Domain.Entities.Produtos;

namespace Ddd.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoFormDto, Produto>();
        }
    }
}