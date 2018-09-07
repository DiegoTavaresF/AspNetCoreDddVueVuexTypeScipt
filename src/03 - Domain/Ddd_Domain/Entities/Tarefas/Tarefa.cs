using Ddd.Domain.Base;
using System;

namespace Ddd.Domain.Entities.Tarefas
{
    public class Tarefa : EntityBase
    {
        public Tarefa(bool concluido, string descricao, string titulo)
        {
            if (DataDeCadastro != DateTime.MinValue && Id > 0)
            {
                DataDaUltimaAlteracao = DateTime.Now;
            }
            else
            {
                DataDeCadastro = DateTime.Now;
            }

            SetConcluido(concluido);
            SetDescricao(descricao);
            SetTitulo(titulo);
        }

        public Tarefa()
        {
        }

        public bool Concluido { get; private set; }
        public DateTime? DataDeConclusao { get; private set; }
        public string Descricao { get; private set; }
        public string Titulo { get; private set; }

        public void SetConcluido(bool concluido)
        {
            if (Concluido != concluido)
            {
                if (concluido)
                {
                    DataDeConclusao = DateTime.Now;
                }
                else
                {
                    DataDeConclusao = null;
                }

                Concluido = concluido;
            }
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetTitulo(string titulo)
        {
            Titulo = titulo;
        }
    }
}