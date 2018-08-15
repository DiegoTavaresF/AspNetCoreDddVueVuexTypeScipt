import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

@Component({
    name: 'ModalExcluir',
})
export default class ModalExcluirComponent extends Vue {
    @Prop() titulo: string;
    @Prop() id: number;
    @Prop() descricao: string;

    excluir() {
        this.$emit('excluir', this.id);
    }

    fecharModalExcluir() {
        this.$emit('alterarRegistroASerExcluido',-1,'');
    }
}
