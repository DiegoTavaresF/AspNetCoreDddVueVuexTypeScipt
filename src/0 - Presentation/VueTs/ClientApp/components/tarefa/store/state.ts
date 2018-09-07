export const state: TarefaState = {
    Tarefas: [],
    TotalDeItensEncontrados: 0,
    AlertMessage: []
};

export interface TarefaState  {
    Tarefas: Array<Tarefa>;
    TotalDeItensEncontrados: number;
    AlertMessage: string[];

}

export interface Tarefa {
    Id: number;
    Descricao: string;
    Titulo: string;
    Concluido: boolean,
}

  