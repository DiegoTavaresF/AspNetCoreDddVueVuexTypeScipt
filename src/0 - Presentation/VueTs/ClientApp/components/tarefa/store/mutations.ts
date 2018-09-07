import { MutationTree } from 'vuex';
import { TarefaState } from './state';

export const mutations:any = {

    atualizaGrid(state: any, tarefas: any  ) {
        state.Tarefas = tarefas.itens;
        state.TotalDeItensEncontrados = tarefas.totalDeItensEncontrados;
    },
    setAlertMessage(state: any, alertMessage: string[]) {
        state.AlertMessage = alertMessage;
    },
}

