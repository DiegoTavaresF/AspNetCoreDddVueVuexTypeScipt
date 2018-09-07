using AutoMapper;
using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.Entities.Tarefas;
using Ddd.Infra.Data.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ddd.Application.Services.Tarefas
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IContextBase _context;
        private readonly IMapper _mapper;
        private readonly IValidator<TarefaFormDto> _tarefaFormDtoValidator;

        public TarefaAppService(IContextBase context, IMapper mapper, IValidator<TarefaFormDto> tarefaFormDtoValidator)
        {
            _context = context;
            _mapper = mapper;
            _tarefaFormDtoValidator = tarefaFormDtoValidator;
        }

        public TarefaFormDto Cadastrar(TarefaFormDto formDto)
        {
            if (formDto == null)
            {
                formDto = new TarefaFormDto();
                formDto.Erros.Add("Erro...");
                return formDto;
            }

            formDto.ValidationErros = _tarefaFormDtoValidator.Validate(formDto).Errors
                                                    .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                    .ToList();

            if (!formDto.IsValid())
            {
                return formDto;
            }

            var tarefa = new Tarefa();
            tarefa = _mapper.Map<Tarefa>(formDto);

            if (!tarefa.IsValid())
            {
                formDto.Erros = tarefa.Errors;
                return formDto;
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return _mapper.Map<TarefaFormDto>(_context.Tarefas.Find(tarefa.Id));
        }

        public TarefaFormDto CarregarForm(long id)
        {
            return _context.Tarefas
                           .Where(w => w.Id == id)
                           .Select(p => new TarefaFormDto
                           {
                               Id = p.Id,
                               Titulo = p.Titulo,
                               Descricao = p.Descricao
                           })
                           .FirstOrDefault();
        }

        public GridDto<TarefaGridDto> CarregarGrid(int numeroDaPagina, int registrosPorPagina, string filtro, TarefaGridFiltroAvancadoDto filtroAvancado = null)
        {
            var gridDto = new GridDto<TarefaGridDto>();

            if (numeroDaPagina < 1) numeroDaPagina = 1;

            var query = _context.Tarefas
                                .OrderBy(p => p.Titulo)
                                .AsQueryable();

            if (filtroAvancado != null)
            {
                if (!string.IsNullOrWhiteSpace(filtroAvancado.Titulo))
                {
                    query = query.Where(t => EF.Functions.Like(t.Titulo, $"%{filtro}%"));
                }
            }
            else if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(t => !t.Excluido);
                query = query.Where(t => EF.Functions.Like(t.Titulo, $"%{filtro}%"));
            }

            gridDto.TotalDeItensEncontrados = query.Count();
            gridDto.Itens = query
                                .Select(t => new TarefaGridDto()
                                {
                                    Id = t.Id,
                                    Titulo = t.Titulo,
                                    Descricao = t.Descricao,
                                    Concluido = t.Concluido,
                                    DataDaUltimaAlteracao = t.DataDaUltimaAlteracao == null ? "" : ((DateTime)t.DataDaUltimaAlteracao).ToString("MM/dd/yyyy HH:mm"),
                                    DataDeCadastro = t.DataDeCadastro.ToString("MM/dd/yyyy HH:mm"),
                                    DataDeConclusao = t.DataDeConclusao == null ? "" : ((DateTime)t.DataDeConclusao).ToString("MM/dd/yyyy HH:mm"),
                                    Excluido = t.Excluido
                                })
                                .Skip((numeroDaPagina - 1) * registrosPorPagina)
                                .Take(registrosPorPagina)
                                .ToList();

            return gridDto;
        }

        public TarefaFormDto Editar(TarefaFormDto formDto)
        {
            if (formDto == null || formDto.Id <= 0)
            {
                formDto = new TarefaFormDto();
                formDto.Erros.Add("Erro...");
                return formDto;
            }

            formDto.ValidationErros = _tarefaFormDtoValidator.Validate(formDto).Errors
                                                    .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                    .ToList();

            if (!formDto.IsValid())
            {
                return formDto;
            }

            var tarefa = _context.Tarefas.Find(formDto.Id);
            tarefa.SetConcluido(formDto.Concluido);
            tarefa.SetDescricao(formDto.Descricao);
            tarefa.SetTitulo(formDto.Titulo);

            if (!tarefa.IsValid())
            {
                formDto.Erros = tarefa.Errors;
                return formDto;
            }

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

            return _mapper.Map<TarefaFormDto>(_context.Tarefas.Find(tarefa.Id));
        }

        public ExcluirDto Excluir(long id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return new ExcluirDto()
                {
                    Id = id,
                    Erro = "Tarefa não encontrado."
                };
            }

            tarefa.Excluido = true;
            tarefa.DataDaUltimaAlteracao = DateTime.Now;

            _context.Attach(tarefa);
            _context.Entry(tarefa).Property(x => x.Excluido).IsModified = true;
            _context.Entry(tarefa).Property(x => x.DataDaUltimaAlteracao).IsModified = true;
            _context.SaveChanges();

            return new ExcluirDto() { Id = id };
        }
    }
}