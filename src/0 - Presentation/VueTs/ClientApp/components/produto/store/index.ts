import { state } from './state';
import { actions } from "./actions";
import { mutations } from "./mutations";
import { getters } from "./getters"
import { Module } from 'vuex';
import { ProdutoState } from './state';
import { RootState } from '../../../store/rootstate';

const namespaced: boolean = false;

export const moduleProdutos: Module<ProdutoState, RootState> = {
    namespaced,
    state,
    actions,
    mutations,
    getters
}