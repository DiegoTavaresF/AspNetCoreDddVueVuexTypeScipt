import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { ProdutoState, Produto } from '../store/state';


@Component
export default class ProdutoCadastroComponent extends Vue {
    @State('moduleProdutos') state: ProdutoState;
    @Action('actionCadastrar') actionCadastrar: any;
    @Getter('getTotalDeItensEncontrados') getTotalDeItensEncontrados: any;

    
    produtoDto: Produto = {} as Produto;
    alertMessage: string[] = [];

    salvar() {
        var response = this.actionCadastrar(this.produtoDto)
            .then((responseData: any) => {
                debugger;
                if (responseData[0] == '400') {
                    this.alertMessage = ['400',"Erro"];
                }
                else {
                    this.$router.push('./');
                }
            });
    }

}
