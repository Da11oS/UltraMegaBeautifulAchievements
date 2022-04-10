import axios from 'axios';
import { Type } from '@/api';
import { Column } from '@/components/Types/ColumnOfType.vue';

export function useAchievementTypeData () {
  async function createAchievementType (achievementType: Partial<Type>, columns: Column[]) {
    const query = { type: achievementType, columns: columns };
    const columnsResponse = await axios.post('Types/WithColumns', query);
  }

  async function getTypes (groupId: number) {
    try {
      const response = await axios.get('Types/Group/' + groupId);
      return response.data;
    } catch (ex) {
      console.warn(ex);
    }
  }
  async function getColumns (typeId: number) {
    try {
      const response = await axios.get('Types/Group/' + typeId);
      return response.data;
    } catch (ex) {
      console.warn(ex);
    }
  }
  return {
    createAchievementType,
    getTypes,
    getColumns
  };
}
