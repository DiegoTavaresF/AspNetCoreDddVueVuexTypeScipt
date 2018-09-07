import axios from 'axios';
import VueRouter from 'vue';

const actionCadastrar = async function (context: any, values: any): Promise<string[]> {
    let result: string[] = [];

    await axios.post('./api/tarefa/cadastrar', values)
        .then((response) => {
            if (response.data.validationErros.length > 0) {
                result = ['400', "Erro"];
            }
            else {
                result = ['200', 'Cadastrado com sucesso'];
            }

            context.commit('setAlertMessage', result);
        })
        .catch(function (error) {
            return ['500', error];
        });

    return result;
};


const actionEditar = async function (context: any, values: any): Promise<string[]> {
    let result: string[] = [];

    await axios.put('./api/tarefa/editar', values)
        .then((response) => {
            if (response.data.validationErros.length > 0) {
                result = ['400', "Erro"];
            }
            else {
                result = ['200', 'Cadastrado com sucesso'];
            }

            context.commit('setAlertMessage', result);
        })
        .catch(function (error) {
            return ['500', error];
        });

    return result;
};

const actionExcluir = async function (context: any, id: number): Promise<string[]> {
    let result: string[] = [];

    await axios.delete('./api/tarefa/excluir', { params: { 'id': id } })
        .then((response) => {
            if (response.data.erro != '' && response.data.erro != null) {
                result = ['400', "Erro"];
            }
            else {
                result = ['200', 'Excluído com sucesso'];
            }

            context.commit('setAlertMessage', result);
        })
        .catch(function (error) {
            return ['500', error];
        });;

    return result;
};

const actionCarregar = async function(context: any, id: number): Promise<boolean> {
   
    let url = './api/tarefa/CarregarForm?id=' + id;
    await axios.get(url)
                .then(response => {
                    context.commit('carregarParaEditar', response.data);
                    return true;
                })
                .catch(error => {
                    console.log(error);
                });

    return false;
};

export const actions: any = {

    actionCarregarGrid: (context: any, values: any) => {
        let url = './api/tarefa/CarregarGrid?';
        const params = new URLSearchParams({
            paginaAtual: values.paginaAtual,
            itensPorPagina: values.itensPorPagina,
            filtro: values.filtro            
        } as any);
        
        if(values.utilizarPesquisaAvancada == true){
            params.append( "usarFiltroAvancado", "true");
            params.append( "filtroAvancado.Titulo", values.filtroAvancado.Titulo);
            params.append( "filtroAvancado.ExibirExcluidos", values.filtroAvancado.ExibirExcluidos);
        }

        axios.get(url + params.toString())
            .then(response => {
                context.commit('atualizaGrid', response.data);
            })
            .catch(error => {
                console.log(error)
            })
    },

    actionCadastrar,
    actionCarregar,
    actionEditar,

    actionSetAlertMessage: (context: any, message: string[]) => {
        context.commit('setAlertMessage', message);
    },

    actionExcluir


};


