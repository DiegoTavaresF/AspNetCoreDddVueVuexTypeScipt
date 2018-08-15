import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

@Component({
    name: 'Paginacao',
})
export default class PaginacaoComponent extends Vue {
    @Prop() paginaAtual: number;
    @Prop() itensPorPagina: number;
    @Prop() totalDeItens: number;
   
    arrayRegistrosPorPagina: number[] = [2, 4, 8];


    setItensPorPagina(itensPorPagina: number) {
        this.$emit('setItensPorPagina', itensPorPagina)
    }

    setPaginaAtual(numeroDaPagina: number) {
        this.$emit('setPaginaAtual', numeroDaPagina)
    }

    getNumeroDePaginas() {
        let totalDePaginas = (this.totalDeItens + this.itensPorPagina - 1) / this.itensPorPagina;
        if (totalDePaginas <= 1) totalDePaginas = 1; 
        let result = [];
        

        for (var i = this.paginaAtual-1||1; i <= totalDePaginas; i++) {
            if (i < 1) continue;
            if (result.length > 2) break;

            result.push(i);
        }

        return result;
    }
}
