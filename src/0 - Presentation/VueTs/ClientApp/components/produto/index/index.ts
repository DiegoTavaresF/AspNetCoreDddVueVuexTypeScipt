import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { ProdutoState, Produto } from '../store/state';
import Paginacao from '../../helpers/paginacao/paginacao';
import ModalExcluir from '../../helpers/modalExcluir/modalExcluir';


@Component({
    components: { Paginacao, ModalExcluir }
})
export default class ProdutoIndexComponent extends Vue {
    @State('moduleProdutos') state: ProdutoState;
    @Action('actionCarregarGrid') actionCarregarGrid: any;
    @Action('actionSetPaginaAtual') actionSetPaginaAtual: any;
    @Action('actionExcluir') actionExcluir: any;
    @Action('actionSetAlertMessage') actionSetAlertMessage: any;
    @Getter('getTotalDeItensEncontrados') getTotalDeItensEncontrados: any;
    @Getter('getAlertMessage') getAlertMessage: string[];

    exibirPesquisaAvancada: boolean = false;
    paginaAtual: number = 1;
    itensPorPagina: number = 2;
    arrayRegistrosPorPagina: number[] = [2, 4, 8];
    filtro: string = '';
    alertMessage: string[] = [];

    idItemExcluir: number = 0;
    descricaoItemExcluir: string = '';


    mounted() {
        this.alertMessage = this.getAlertMessage;
        this.actionSetAlertMessage([]);
        this.atualizarGrid();      
    }

    setItensPorPagina(itensPorPagina: number) {
        this.itensPorPagina = itensPorPagina;
        this.atualizarGrid();
    }

    setPaginaAtual(numeroDaPagina: number) {
        this.paginaAtual = numeroDaPagina;
        this.atualizarGrid();
    }

    atualizarGrid() {
        this.exibirPesquisaAvancada = false;
        let parametros = { paginaAtual: this.paginaAtual, itensPorPagina: this.itensPorPagina, filtro: this.filtro };
        this.actionCarregarGrid(parametros);
    }

    abrirFecharPesquisaAvancada() {
        this.exibirPesquisaAvancada = !this.exibirPesquisaAvancada;
    }

    alterarRegistroASerExcluido(id: number, descricao: string) {
        this.idItemExcluir = id;
        this.descricaoItemExcluir = descricao;
    }

    excluir(id: number) {
        this.alterarRegistroASerExcluido(-1, '');
        this.actionExcluir(id)
            .then(() => {
                this.alertMessage = this.getAlertMessage;
                this.atualizarGrid();
            });
       
    }
    


    
}
