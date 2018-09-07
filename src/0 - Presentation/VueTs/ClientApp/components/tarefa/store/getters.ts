import { GetterTree } from 'vuex';
import { TarefaState } from './state';
import { RootState } from '../../../store/rootstate';

export const getters: GetterTree<TarefaState, RootState> = {

    getTotalDeItensEncontrados: (context: any): number => {       
        return context.TotalDeItensEncontrados || 0;
    },

    getAlertMessage: (context: any) : string[] => {
        return context.AlertMessage || [];
    }
}