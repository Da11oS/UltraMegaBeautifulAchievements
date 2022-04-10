<template>
  <v-list-item>
    <v-list-item-content style="display: grid; grid-template-columns: auto 50% 50%">
      <slot>

      </slot>
      <v-text-field
        label="Label"
        hide-details="auto"
        v-model="modelProp.label"
      ></v-text-field>
      <v-select
        :items="selectList"
        @change="modelProp.dataType = $event"
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
import { Type } from '@/api';
import { computed, defineComponent, PropType, toRef, watch } from '@vue/composition-api';
import { columnTypes, DataTypes } from '../DataComponents/dataComposable';

// Колонки в БД
export interface Column {
  dataType: DataTypes;
  id: number | null;
  label: string;
  achievementType: Type | null;
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
  model: {
    prop: 'model',
    event: 'update:model'
  },
  setup (props, { emit }) {
    const modelProp = toRef(props, 'model');
    const selectList = computed((): SelectItem[] => {
      return columnTypes.map(m => {
        return {
          value: m.dataType as number,
          text: m.display as string
        };
      });
    });

    watch(modelProp, (value) => {
      emit('update:model', value);
    });

    return {
      selectList,
      modelProp
    };
  },
  methods: {
    consoleLog (msg: any) {
      console.log(msg);
    }

  }
});
</script>
