import './css/site.css';
import Vue from 'vue'
import Vuex from 'vuex'
import VueRouter from 'vue-router';
Vue.use(VueRouter);


import store from './store';

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/modalExcluir', component: require('./components/helpers/modalExcluir/modalExcluir.vue.html') },
    { path: '/paginacao', component: require('./components/helpers/paginacao/paginacao.vue.html') },
    { path: '/tarefa', component: require('./components/tarefa/index/index.vue.html') },
    { path: '/tarefa/novo', component: require('./components/tarefa/createEdit/tarefa.cadastro.vue.html') },
    { path: '/tarefa/editar:id', name:'editarTarefa', component: require('./components/tarefa/createEdit/tarefa.cadastro.vue.html') },
];

new Vue({
    el: '#app-root',
    store,
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
