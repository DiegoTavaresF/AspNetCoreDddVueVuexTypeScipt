import { GetterTree } from 'vuex';
import { ProdutoState } from './state';
import { RootState } from '../../../store/rootstate';

export const getters: GetterTree<ProdutoState, RootState> = {

    getTotalDeItensEncontrados: (context: any): number => {       
        return context.TotalDeItensEncontrados || 0;
    },

    getAlertMessage: (context: any) : string[] => {
        return context.AlertMessage || [];
    }
}