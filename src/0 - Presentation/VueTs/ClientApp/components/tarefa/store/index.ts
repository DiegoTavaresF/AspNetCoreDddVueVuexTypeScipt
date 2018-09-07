import { state } from './state';
import { actions } from "./actions";
import { mutations } from "./mutations";
import { getters } from "./getters"
import { Module } from 'vuex';
import { TarefaState } from './state';
import { RootState } from '../../../store/rootstate';

const namespaced: boolean = false;

export const moduleTarefas: Module<TarefaState, RootState> = {
    namespaced,
    state,
    actions,
    mutations,
    getters
}