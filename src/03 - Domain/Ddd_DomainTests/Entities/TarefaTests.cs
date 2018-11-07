using Ddd.Domain.Entities.Tarefas;
using Ddd.Infra.Data.CrossCutting.Resources;
using System.Linq;
using Xunit;

namespace Ddd_DomainTests.Entities
{
    public class TarefaTests
    {
        [Fact]
        public void Construtor_com_titulo_NotNull_deve_retornar_titulo_NotNull()
        {
            var titulo = "teste";

            var tarefa = new Tarefa(null, titulo);

            Assert.Equal(titulo, tarefa.Titulo);
        }

        [Fact]
        public void Construtor_com_titulo_null_deve_retornar_erro()
        {
            var tarefa = new Tarefa(null, null);

            var achouErro = tarefa.Errors.Any(e => e == DomainResources.Tarefa_TituloEObrigatorio);

            Assert.True(achouErro);
        }

        [Fact]
        public void ConstrutorComDescricaoNotNull_deve_retornar_DescricaoNotNull()
        {
            var descricao = "teste";

            var tarefa = new Tarefa(descricao, null);

            Assert.Equal(descricao, tarefa.Descricao);
        }

        [Fact]
        public void ConstrutorComDescricaoNull_deve_retornar_Descricaonull()
        {
            var tarefa = new Tarefa(null, null);

            Assert.Null(tarefa.Descricao);
        }

        [Fact]
        public void SetTituloComValorNotNull_deve_AtualizarValorDoTituloENaoGerarErros()
        {
            var titulo = "teste";
            var tarefa = new Tarefa(null, titulo);

            Assert.Equal(titulo, tarefa.Titulo);
            Assert.NotNull(tarefa.Titulo);
        }

        [Fact]
        public void SetTituloComValorNull_deve_retornar_erro()
        {
            var tarefa = new Tarefa(null, null);

            Assert.NotEmpty(tarefa.Errors);
        }
    }
}