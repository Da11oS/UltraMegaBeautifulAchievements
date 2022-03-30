import axios from 'axios';

export function useTypeData (groupId: number) {
  async function createGroup (name: string) {
    try {
      const response = await axios.post('Achievements/Groups/Create', { name });
    } catch (ex) {
      console.error(ex);
    }
  }
  return {
    createGroup
  };
}
