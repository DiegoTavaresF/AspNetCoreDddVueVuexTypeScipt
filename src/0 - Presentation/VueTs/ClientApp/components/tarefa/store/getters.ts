import { GetterTree } from 'vuex';
import { TarefaState } from './state';
import { Tarefa } from './state';
import { RootState } from '../../../store/rootstate';

export const getters: GetterTree<TarefaState, RootState> = {

    getTotalDeItensEncontrados: (context: any): number => {       
        return context.TotalDeItensEncontrados || 0;
    },

    getTarefaEmEdicao: (context: any): Tarefa => {       
        return context.TarefaEmEdicao as Tarefa || new Tarefa();
    },

    getAlertMessage: (context: any) : string[] => {
        return context.AlertMessage || [];
    }


}