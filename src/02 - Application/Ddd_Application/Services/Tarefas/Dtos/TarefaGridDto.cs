namespace Ddd.Application.Services.Tarefas.Dtos
{
    public class TarefaGridDto
    {
        public bool Concluido { get; set; }
        public string DataDaUltimaAlteracao { get; set; }
        public string DataDeCadastro { get; set; }
        public string DataDeConclusao { get; set; }
        public string DataDeExclusao { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
        public long Id { get; set; }
        public string Titulo { get; set; }
    }
}