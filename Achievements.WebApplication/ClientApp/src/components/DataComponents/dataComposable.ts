import TextField from '@/components/DataComponents/TextField.vue';
import FileField from '@/components/DataComponents/FileField.vue';
import NumberField from '@/components/DataComponents/NumberField.vue';

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
