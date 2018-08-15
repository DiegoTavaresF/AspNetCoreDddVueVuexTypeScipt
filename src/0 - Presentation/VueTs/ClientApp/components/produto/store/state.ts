export const state: ProdutoState = {
    Produtos: [],
    TotalDeItensEncontrados: 0,
    AlertMessage: []
};

export interface ProdutoState  {
    Produtos: Array<Produto>;
    TotalDeItensEncontrados: number;
    AlertMessage: string[];

}

export interface Produto {
    Id: number;
    Nome: string;
    PrecoDeVenda: number;
}

  