import axios from 'axios';
import VueRouter from 'vue';

const actionCadastrar = async function (context: any, values: any): Promise<string[]> {
    let result: string[] = [];

    await axios.post('./api/produto/cadastrar', values)
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

    await axios.delete('./api/produto/excluir', { params: { 'id': id } })
        .then((response) => {
            debugger;
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

export const actions: any = {

    actionCarregarGrid: (context: any, values: any) => {
        let url = './api/produto/CarregarGrid?';

        const params = new URLSearchParams({
            paginaAtual: values.paginaAtual,
            itensPorPagina: values.itensPorPagina,
            filtro: values.filtro
        } as any);

        axios.get(url + params.toString())
            .then(response => {
                context.commit('atualizaGrid', response.data);
            })
            .catch(error => {
                console.log(error)
            })

    },

    actionCadastrar,

    actionSetAlertMessage: (context: any, message: string[]) => {
        context.commit('setAlertMessage', message);
    },

    actionExcluir


};


