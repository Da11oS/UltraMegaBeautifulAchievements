<template>
  <v-row>
    <v-col v-for="value in instanceValues" :key="value.id" cols="auto">
      <component :is="value">
      </component>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { Column } from '@/components/Types/ColumnOfType.vue';
import { useAchievementTypeData } from '@/components/Types/AchievementTypeComposable';
import { User } from '@/api';
import { defineComponent, PropType, ref } from '@vue/composition-api';

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

export default defineComponent({
  name: 'AchievementInstance',
  props: { model: { type: Object as PropType<Instance> } },
  setup () {
    const instanceValues = ref<ValueOfInstanceColumn[]>();
    const { getColumns } = useAchievementTypeData();
    return {
      instanceValues
    };
  }
});

</script>
