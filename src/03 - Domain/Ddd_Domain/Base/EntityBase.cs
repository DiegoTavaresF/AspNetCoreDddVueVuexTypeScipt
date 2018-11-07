using System;

namespace Ddd.Domain.Base
{
    public class EntityBase : MainError
    {
        public EntityBase()
        {
            DataDeCadastro = DateTime.Now;
        }

        public DateTime? DataDaUltimaAlteracao { get; protected set; }
        public DateTime DataDeCadastro { get; }
        public bool Excluido { get; protected set; }
        public long Id { get; protected set; }

        public void AtualizarDataDaUltimaAlteracao()
        {
            DataDaUltimaAlteracao = DateTime.Now;
        }

        public void SetExcluido()
        {
            Excluido = true;
            AtualizarDataDaUltimaAlteracao();
        }
    }
}