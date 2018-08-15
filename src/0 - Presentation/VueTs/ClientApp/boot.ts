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
    { path: '/produto', component: require('./components/produto/index/index.vue.html') },
    { path: '/produto/novo', component: require('./components/produto/createEdit/produto.cadastro.vue.html') },
    { path: '/produto/editar:id', name:'editarProduto', component: require('./components/produto/createEdit/produto.cadastro.vue.html') },
];

new Vue({
    el: '#app-root',
    store,
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
