import axios from 'axios';
import { ref } from '@vue/composition-api';
export function useTypeData(groupId) {
    const groups = ref([{ id: 1, name: 'тест' }]);
    async function getTypes() {
        try {
            const response = await axios.get('Types/Group/' + groupId);
            groups.value = response.data;
        }
        catch (ex) {
            console.warn(ex);
        }
    }
    async function createGroup(name) {
        try {
            const response = await axios.post('Achievements/Groups/Create', { name });
            await getTypes();
        }
        catch (ex) {
            console.error(ex);
        }
    }
    return {
        createGroup,
        groups
    };
}
//# sourceMappingURL=typesComposable.js.map