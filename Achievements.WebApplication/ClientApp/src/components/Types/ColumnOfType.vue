<template>
  <v-list-item>
    <v-list-item-content style="display: grid; grid-template-columns: 50% 50%">
      <v-text-field
        label="Label"
        :rules="rules"
        hide-details="auto"
      ></v-text-field>
      <v-select
        :items="selectList"
        @change="consoleLog($event)"
      ></v-select>
    </v-list-item-content>
    <v-list-item-action>
      <v-btn icon @click="$emit('column:remove', model)">
        <v-icon>
          mdi-minus
        </v-icon>
      </v-btn>
    </v-list-item-action>
  </v-list-item>
</template>

<script lang="ts">
import { computed, defineComponent, PropType } from '@vue/composition-api';
import { DataTypes, columnTypes } from './AchievementInstance.vue';

// Колонки в БД
export interface Column {
  dataType: DataTypes;
  id: number | null;
  typeId: number;
  label: string;
}
export interface SelectItem {
  value: number;
  text: string;
}
export default defineComponent({
  name: 'ColumnOfType',
  props: {
    model: { type: Object as PropType<Column> }
  },
  setup () {
    const selectList = computed((): SelectItem[] => {
      return columnTypes.map(m => {
        return {
          value: m.dataType as number,
          text: m.display as string
        };
      });
    });
    return {
      selectList
    };
  },
  methods: {
    consoleLog (msg: any) {
      console.log(msg);
    }

  }
});
</script>
