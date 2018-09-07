import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { TarefaState, Tarefa } from '../store/state';


@Component
export default class TarefaCadastroComponent extends Vue {
    @State('moduleTarefas') state: TarefaState;
    @Action('actionCadastrar') actionCadastrar: any;
    @Action('actionEditar') actionEditar: any;
    @Action('actionCarregar') actionCarregar: any;
    @Getter('getTarefaEmEdicao') getTarefaEmEdicao: any;

    
    tarefaDto: Tarefa = new Tarefa();
    alertMessage: string[] = [];

    mounted() {
        
        let id = this.$route.params.id;
        if(id){
            this.actionCarregar(id)
                .then(() => {
                    this.tarefaDto = this.state.TarefaEmEdicao;
                } );
        }
    }

    salvar() {
         this.actionCadastrar(this.tarefaDto)
            .then((responseData: any) => {
                if (responseData[0] == '400') {
                    this.alertMessage = ['400',"Erro"];
                }
                else {
                    this.$router.push('/tarefa');
                }
            });
    }

    editar() {
         this.actionEditar(this.tarefaDto)
            .then((responseData: any) => {
                debugger;
                if (responseData[0] == '400') {
                    this.alertMessage = ['400',"Erro"];
                }
                else {
                    this.$router.push('/tarefa');
                }
            });
    }

}
