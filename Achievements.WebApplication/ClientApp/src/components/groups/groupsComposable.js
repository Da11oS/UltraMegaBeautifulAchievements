import axios from 'axios';
import { ref } from '@vue/composition-api';
export function useGroupData() {
    const groups = ref([{ id: 1, name: 'тест' }]);
    async function getGroups() {
        try {
            const response = await axios.get('Achievements/Groups');
            groups.value = response.data;
        }
        catch (ex) {
            console.warn(ex);
        }
    }
    async function createGroup(name) {
        try {
            const response = await axios.post('Achievements/Groups/Create', { name });
            await getGroups();
        }
        catch (ex) {
            console.error(ex);
        }
    }
    return {
        getGroups,
        createGroup,
        groups
    };
}
//# sourceMappingURL=groupsComposable.js.map