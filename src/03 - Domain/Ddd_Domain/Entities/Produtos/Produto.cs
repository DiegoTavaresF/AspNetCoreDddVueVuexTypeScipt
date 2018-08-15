using Ddd.Domain.Base;

namespace Ddd.Domain.Entities.Produtos
{
    public class Produto : EntityBase
    {
        public Produto()
        {
        }

        public string Nome { get; private set; }
        public decimal PrecoDeVenda { get; private set; }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                this.AddError("Nome não pode ser vazio.");
            }

            this.Nome = nome;
        }

        public void SetPrecoDeVenda(decimal precoDeVenda)
        {
            if (precoDeVenda <= 0)
            {
                this.AddError("Preço de venda deve ser maior que zero.");
            }

            this.PrecoDeVenda = precoDeVenda;
        }
    }
}