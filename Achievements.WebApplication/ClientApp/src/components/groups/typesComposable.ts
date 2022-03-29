import axios from 'axios';
import { ref } from '@vue/composition-api';
import { Group, Type } from '@/api';

export function useTypeData (groupId: number) {
  const groups = ref<Type[]>([{ id: 1, name: 'тест' }]);

  async function getTypes () {
    try {
      const response = await axios.get('Types/Group/' + groupId);
      groups.value = response.data as Type[];
    } catch (ex) {
      console.warn(ex);
    }
  }
  async function createGroup (name: string) {
    try {
      const response = await axios.post('Achievements/Groups/Create', { name });
      await getTypes();
    } catch (ex) {
      console.error(ex);
    }
  }
  return {
    createGroup,
    groups
  };
}
