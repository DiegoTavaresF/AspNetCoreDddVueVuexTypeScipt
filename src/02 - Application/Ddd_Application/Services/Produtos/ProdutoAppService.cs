using AutoMapper;
using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Produtos.Dtos;
using Ddd.Domain.Entities.Produtos;
using Ddd.Infra.Data.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ddd.Application.Services.Produtos
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IContextBase _context;
        private readonly IMapper _mapper;
        private readonly IValidator<ProdutoFormDto> _produtoFormDtoValidator;

        public ProdutoAppService(IContextBase context, IMapper mapper, IValidator<ProdutoFormDto> produtoFormDtoValidator)
        {
            _context = context;
            _mapper = mapper;
            _produtoFormDtoValidator = produtoFormDtoValidator;
        }

        public ProdutoFormDto Cadastrar(ProdutoFormDto formDto)
        {
            if (formDto == null)
            {
                formDto = new ProdutoFormDto();
                formDto.Erros.Add("Erro...");
                return formDto;
            }

            formDto.ValidationErros = _produtoFormDtoValidator.Validate(formDto).Errors
                                                    .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                    .ToList();

            if (!formDto.IsValid())
            {
                return formDto;
            }

            var produto = new Produto();
            produto = _mapper.Map<Produto>(formDto);

            if (!produto.IsValid())
            {
                formDto.Erros = produto.Errors;
                return formDto;
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return _mapper.Map<ProdutoFormDto>(_context.Produtos.Find(produto.Id));
        }

        public ProdutoFormDto CarregarForm(int id)
        {
            return _context.Produtos
                           .Where(w => w.Id == id)
                           .Select(p => new ProdutoFormDto
                           {
                               Id = p.Id,
                               Nome = p.Nome,
                               PrecoDeVenda = p.PrecoDeVenda
                           })
                           .FirstOrDefault();
        }

        public GridDto<ProdutoGridDto> CarregarGrid(int numeroDaPagina, int registrosPorPagina, string filtro)
        {
            var gridDto = new GridDto<ProdutoGridDto>();

            if (numeroDaPagina < 1) numeroDaPagina = 1;

            var query = _context.Produtos
                                .OrderBy(p => p.Nome)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(p => EF.Functions.Like(p.Nome, $"%{filtro}%"));
            }

            gridDto.TotalDeItensEncontrados = query.Count();
            gridDto.Itens = query
                                .Select(p => new ProdutoGridDto()
                                {
                                    Id = p.Id,
                                    Nome = p.Nome,
                                    PrecoDeVenda = p.PrecoDeVenda
                                })
                                .Skip((numeroDaPagina - 1) * registrosPorPagina)
                                .Take(registrosPorPagina)
                                .ToList();

            return gridDto;
        }

        public ProdutoFormDto Editar(ProdutoFormDto formDto)
        {
            if (formDto == null || formDto.Id <= 0)
            {
                formDto = new ProdutoFormDto();
                formDto.Erros.Add("Erro...");
                return formDto;
            }

            formDto.ValidationErros = _produtoFormDtoValidator.Validate(formDto).Errors
                                                    .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                    .ToList();

            if (!formDto.IsValid())
            {
                return formDto;
            }

            var produto = _context.Produtos.Find(formDto.Id);
            produto.SetNome(formDto.Nome);
            produto.SetPrecoDeVenda(formDto.PrecoDeVenda);

            if (!produto.IsValid())
            {
                formDto.Erros = produto.Errors;
                return formDto;
            }

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return _mapper.Map<ProdutoFormDto>(_context.Produtos.Find(produto.Id));
        }

        public ExcluirDto Excluir(int id)
        {
            var produto = _context.Produtos.Find(id);

            // se produto tem dependencias, return new ExcluidoDto(){Erro = "Não pode ser exlcuído};

            if (produto == null)
            {
                return new ExcluirDto()
                {
                    Id = id,
                    Erro = "Produto não encontrado."
                };
            }

            produto.Excluido = true;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return new ExcluirDto() { Id = id };
        }
    }
}