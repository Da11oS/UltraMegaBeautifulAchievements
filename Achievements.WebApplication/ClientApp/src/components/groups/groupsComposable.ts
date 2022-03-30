import axios from 'axios';
import { ref } from '@vue/composition-api';
import { Group } from '@/api';

export function useGroupData () {
  const groups = ref<Group[]>([{ id: 1, name: 'тест' }]);

  async function getGroups () {
    try {
      const response = await axios.get('Achievements/Groups');
      groups.value = response.data as Group[];
    } catch (ex) {
      console.warn(ex);
    }
  }
  async function createGroup (group: Partial<Group>) {
    try {
      const response = await axios.post('Achievements/Groups/Create', group);
      await getGroups();
    } catch (ex) {
      console.error(ex);
    }
  }
  return {
    getGroups,
    createGroup,
    groups
  };
}
