import axios from 'axios';
import { ref } from '@vue/composition-api';
import { Group, Type } from '@/api';

export interface GroupWithTypes {
  id: number;
  name: string;
  types: Type[];
}

export function useGroupData () {
  const groups = ref<Group[]>([{ id: 1, name: 'тест' }]);
  const groupsWithTypes = ref<GroupWithTypes[]>([{ id: 1, name: 'тест', types: [] }]);
  async function getGroups () {
    try {
      const response = await axios.get('Achievements/Groups');
      groups.value = response.data as Group[];
    } catch (ex) {
      console.warn(ex);
    }
  }

  async function getGroupsWithTypes () {
    try {
      const response = await axios.get('Achievements/Groups/WithTypes');
      groupsWithTypes.value = response.data as GroupWithTypes[];
      return groupsWithTypes;
    } catch (ex) {
      console.warn(ex);
    }
  }

  async function createGroup (group: Partial<Group>) {
    try {
      const response = await axios.post('Achievements/Groups/Create', group);
      await getGroups();
      await getGroupsWithTypes();
    } catch (ex) {
      console.error(ex);
    }
  }
  return {
    getGroups,
    createGroup,
    getGroupsWithTypes,
    groups,
    groupsWithTypes
  };
}
