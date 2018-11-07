using AutoMapper;
using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.Entities.Tarefas;
using Ddd.Domain.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ddd.Application.Services.Tarefas
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<TarefaFormDto> _tarefaFormDtoValidator;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaAppService(ITarefaRepository tarefaRepository, IMapper mapper, IValidator<TarefaFormDto> tarefaFormDtoValidator)
        {
            _tarefaRepository = tarefaRepository;
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

            _tarefaRepository.Add(tarefa);

            return _mapper.Map<TarefaFormDto>(tarefa);
        }

        public TarefaFormDto CarregarForm(long id)
        {
            return _tarefaRepository.GetAll()
                           .Where(w => w.Id == id)
                           .Select(t => new TarefaFormDto
                           {
                               Id = t.Id,
                               Titulo = t.Titulo,
                               Descricao = t.Descricao,
                           })
                           .FirstOrDefault();
        }

        public GridDto<TarefaGridDto> CarregarGrid(int numeroDaPagina, int registrosPorPagina, string filtro, TarefaGridFiltroAvancadoDto filtroAvancado = null)
        {
            var gridDto = new GridDto<TarefaGridDto>();

            if (numeroDaPagina < 1) numeroDaPagina = 1;

            var query = _tarefaRepository.GetAll()
                                .OrderBy(p => p.Titulo)
                                .AsQueryable();

            if (filtroAvancado != null)
            {
                if (!string.IsNullOrWhiteSpace(filtroAvancado.Titulo))
                {
                    query = query.Where(t => EF.Functions.Like(t.Titulo, $"%{filtroAvancado.Titulo}%"));
                }
            }
            else
            {
                query = query.Where(t => !t.Excluido);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query = query.Where(t => EF.Functions.Like(t.Titulo, $"%{filtro}%"));
                }
            }

            gridDto.TotalDeItensEncontrados = query.Count();
            gridDto.Itens = query
                                .Select(t => new TarefaGridDto()
                                {
                                    Id = t.Id,
                                    Titulo = t.Titulo,
                                    Descricao = t.Descricao,
                                    DataDaUltimaAlteracao = t.DataDaUltimaAlteracao == null ? "" : ((DateTime)t.DataDaUltimaAlteracao).ToString("MM/dd/yyyy HH:mm"),
                                    DataDeCadastro = t.DataDeCadastro.ToString("MM/dd/yyyy HH:mm"),
                                    Excluido = t.Excluido
                                })
                                .Skip((numeroDaPagina - 1) * registrosPorPagina)
                                .Take(registrosPorPagina)
                                .ToList();

            return gridDto;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
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

            var tarefa = _tarefaRepository.GetById(formDto.Id);
            tarefa.SetDescricao(formDto.Descricao);
            tarefa.SetTitulo(formDto.Titulo);
            tarefa.AtualizarDataDaUltimaAlteracao();

            if (!tarefa.IsValid())
            {
                formDto.Erros = tarefa.Errors;
                return formDto;
            }

            _tarefaRepository.Update(tarefa);

            return _mapper.Map<TarefaFormDto>(tarefa);
        }

        public ExcluirDto Excluir(long id)
        {
            var tarefa = _tarefaRepository.GetById(id);

            if (tarefa == null)
            {
                return new ExcluirDto()
                {
                    Id = id,
                    Erro = "Tarefa não encontrada."
                };
            }

            _tarefaRepository.Excluir(tarefa);

            return new ExcluirDto() { Id = tarefa.Id };
        }
    }
}