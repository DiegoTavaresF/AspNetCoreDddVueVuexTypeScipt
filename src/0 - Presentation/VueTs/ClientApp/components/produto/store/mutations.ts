import { MutationTree } from 'vuex';
import { ProdutoState } from './state';

export const mutations:any = {

    atualizaGrid(state: any, produtos: any  ) {
        state.Produtos = produtos.itens;
        state.TotalDeItensEncontrados = produtos.totalDeItensEncontrados;
    },
    setAlertMessage(state: any, alertMessage: string[]) {
        state.AlertMessage = alertMessage;
    },
}

