import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { TarefaState, Tarefa } from '../store/state';


@Component
export default class TarefaCadastroComponent extends Vue {
    @State('moduleTarefas') state: TarefaState;
    @Action('actionCadastrar') actionCadastrar: any;
    @Getter('getTotalDeItensEncontrados') getTotalDeItensEncontrados: any;

    
    tarefaDto: Tarefa = {} as Tarefa;
    alertMessage: string[] = [];

    salvar() {
        var response = this.actionCadastrar(this.tarefaDto)
            .then((responseData: any) => {
                if (responseData[0] == '400') {
                    this.alertMessage = ['400',"Erro"];
                }
                else {
                    this.$router.push('./');
                }
            });
    }

}
