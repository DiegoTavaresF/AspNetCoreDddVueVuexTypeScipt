using AutoMapper;
using Ddd.Application.AutoMapper;
using Ddd.Application.Services.Tarefas;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Application.Services.Tarefas.Validator;
using Ddd.Domain.Entities.Tarefas;
using Ddd.Infra.Data.Contexts;
using Ddd.Infra.Data.Repositories.Tarefas;
using Ddd.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace Ddd_Application_Tests.Services
{
    public class TarefaAppServiceTests
    {
        private IMapper mapper;

        public TarefaAppServiceTests()
        {
            mapper = CriarMockMapper();
        }

        [Fact]
        public void Cadastrar_com_todas_informacoes()
        {
            var options = new DbContextOptionsBuilder<ContextBase>()
               .UseInMemoryDatabase(databaseName: "Test_in_memory_database_1")
               .Options;

            var tarefaFormDto = new TarefaFormDto
            {
                Descricao = "Desc 3",
                Titulo = "Titulo 3",
            };

            // Run the test against one instance of the context
            using (var context = new ContextBase(options))
            {
                var unitOfWork = new UnitOfWork(context);
                var tarefaRepository = new TarefaRepository(context);

                var tarefaAppService = new TarefaAppService(tarefaRepository, mapper, new TarefaFormDtoValidator());

                var dtoResult = tarefaAppService.Cadastrar(tarefaFormDto);

                tarefaFormDto.Id = dtoResult.Id;

                unitOfWork.Commit();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ContextBase(options))
            {
                var tarefa = context.Tarefas.Find(tarefaFormDto.Id);

                Assert.Equal(tarefa.Titulo, tarefaFormDto.Titulo);
                Assert.Equal(tarefa.Descricao, tarefaFormDto.Descricao);
            }
        }

        [Fact]
        public void CarregarForm()
        {
            var options = new DbContextOptionsBuilder<ContextBase>()
               .UseInMemoryDatabase(databaseName: "Test_in_memory_database_1")
               .Options;

            var tarefa = new Tarefa("aaa", "bbb");

            // Run the test against one instance of the context
            using (var context = new ContextBase(options))
            {
                var unitOfWork = new UnitOfWork(context);

                context.Add(tarefa);
                unitOfWork.Commit();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ContextBase(options))
            {
                var tarefaRepository = new TarefaRepository(context);
                var tarefaAppService = new TarefaAppService(tarefaRepository, mapper, new TarefaFormDtoValidator());
                var tarefaFormDto = tarefaAppService.CarregarForm(tarefa.Id);

                Assert.Equal(tarefa.Titulo, tarefaFormDto.Titulo);
                Assert.Equal(tarefa.Descricao, tarefaFormDto.Descricao);
            }
        }

        private List<Tarefa> CarregarTarefas()
        {
            return new List<Tarefa>
            {
                new Tarefa("Desc 1","Titulo 1"),
                new Tarefa("Desc 2","Titulo 2"),
            };
        }

        private IMapper CriarMockMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            return config.CreateMapper();
        }
    }
}