import TextField from '@/components/DataComponents/TextField.vue';
import FileField from '@/components/DataComponents/FileField.vue';
import NumberField from '@/components/DataComponents/NumberField.vue';
import axios from 'axios';
import { Column } from '@/components/Types/ColumnOfType.vue';
import { Type, User } from '@/api';

export enum DataTypes {
  text = 1,
  file = 2,
  int = 3,
}

// Колонки для генерации компонентов
interface ColumnType {
  dataType: DataTypes;
  display: string;
  component: any;
}

export interface InstanceValue {
  id: number;
  value: string | null;
  column: Column;
}

// Список компонентов для генерации
export const columnTypes = [
  {
    dataType: DataTypes.text,
    display: 'Текстовый',
    component: TextField
  },
  {
    dataType: DataTypes.file,
    display: 'Файл',
    component: FileField
  },
  {
    dataType: DataTypes.int,
    display: 'Числовой',
    component: NumberField
  }
] as ColumnType[];

export interface Instance {
  id: number | null
  achievementType: Type;
  user: User
  achievementsStatus: number;
  expert: User;
  checkedDate: string;
  createdDate: string;
  values: InstanceValue[];
}

export async function getTypeValues (userId: number, typeId: number): Promise<InstanceValue[]> {
  try {
    const result = await axios.get('Columns/Type/' + typeId);
    return result.data;
  } catch (ex) {
    console.log(ex);
    return [];
  }
}
export async function getTypeColumns (userId: number, typeId: number): Promise<Column[]> {
  try {
    const result = await axios.get('Columns/ForType', { data: { typeId: typeId, userId: userId } });
    return result.data as Column[];
  } catch (ex) {
    console.log(ex);
    return [];
  }
}

export async function createAchievementInstance (value: Instance) {
  try {
    const result = await axios.post('Columns', { data: { instance: value } });
    return result.data;
  } catch (ex) {
    console.log(ex);
    return [];
  }
}
export function useAchievementValue (userId: number, typeId: number) {
  // todo
}
