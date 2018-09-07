using System;

namespace Ddd.Domain.Base
{
    public class EntityBase : MainError
    {
        public DateTime? DataDaUltimaAlteracao { get; protected set; }
        public DateTime DataDeCadastro { get; protected set; }
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