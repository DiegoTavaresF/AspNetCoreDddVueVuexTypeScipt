using AutoMapper;
using Ddd.Application.Services.Produtos.Dtos;
using Ddd.Domain.Entities.Produtos;

namespace Ddd.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoFormDto>();
        }
    }
}