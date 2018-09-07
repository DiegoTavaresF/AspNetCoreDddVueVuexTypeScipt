export class TarefaState  {

    constructor(){
        this.TarefaEmEdicao = new Tarefa();
        this.Tarefas = [];
        this.TotalDeItensEncontrados = 0;
        this.AlertMessage = [];
    }

    Tarefas: Tarefa[];
    TarefaEmEdicao: Tarefa;
    TotalDeItensEncontrados: number;
    AlertMessage: string[];

}

export class Tarefa {
    constructor(){
        this.id = 0,
        this.descricao = "",
        this.titulo = "",
        this.concluido = false
    }

    id: number;
    descricao: string;
    titulo: string;
    concluido: boolean;
}

export const state: TarefaState = new TarefaState();
  