import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { RootState } from './rootState';
import { moduleTarefas } from '../components/tarefa/store'
Vue.use(Vuex);


const storeOp: StoreOptions<RootState> = {
    state: {
        loginState: {
            user: '1.0.0',
            isLoggedIn: false
        }
    },
    modules: {
        moduleTarefas,
    }
};

const store =  new Vuex.Store<RootState>(storeOp);

export default store;