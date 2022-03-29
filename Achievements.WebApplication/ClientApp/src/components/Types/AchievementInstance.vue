<template>
    <v-row>
      <v-col v-for="col in instanceColumns" :key="col.column">
      <component :is="col">

      </component>
      </v-col>
    </v-row>
</template>

<script lang="ts">
import TextField from '@/components/DataComponents/TextField.vue';
import FileField from '@/components/DataComponents/FileField.vue';
import NumberField from '@/components/DataComponents/NumberField.vue';
import { Type, User } from '@/api';
import { onMounted, PropType, ref, set } from '@vue/composition-api';
import { Column } from '@/components/Types/ColumnOfType.vue';

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

export enum AchievementType {

}

export interface Instance {
  id: number | null
  achievementType: AchievementType;
  user: User
  achievementsStatus: number;
  expert: User;
  checkedDate: string;
  createdDate: string;
}

export interface ValueOfInstanceColumn {
  column: Column;
  value: string;
}
export default {
  name: 'AchievementInstance',
  props: { model: { type: Object as PropType<Instance> } },
  setup () {
    const instanceColumns = ref<ValueOfInstanceColumn[]>();
    function getColumns () {
      /// to do подгрузка колонок
    }
    function getData () {
      // to do подгрузка данных
    }
    onMounted(() => {
      getData();
    });
    return {
      instanceColumns
    };
  }
};

</script>

<style scoped>

</style>
