<template>
  <v-row>
    <v-col v-for="(value,index) in valueModels" :key="value.id" cols="auto">
      <component :is="columnTypes[value.column.dataType].component" v-model="valueModels[index]" >
      </component>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { useAchievementTypeData } from '@/components/Types/AchievementTypeComposable';
import { computed, defineComponent, PropType, provide, ref, toRef, watch } from '@vue/composition-api';
import { columnTypes, Instance, InstanceValue } from './dataComposable';

export interface SaveBusComponent {
  save() : any;
}

export interface AchievementInstanceProvide {
  register(form: SaveBusComponent): void;
  unRegister(form: SaveBusComponent): void;
}

export const provideAchievementInstance = Symbol('provideAchievementInstance');
export default defineComponent({
  name: 'AchievementInstance',
  props: { modelValue: { type: Object as PropType<Instance> } },
  emits: {
    'update:modelValue': (value: Instance) => true
  },
  model: {
    prop: 'modelValue',
    event: 'update:modelValue'
  },
  setup (props, { emit }) {
    const modelValue = toRef(props, 'modelValue');
    const valueModels = computed((): InstanceValue[] => {
      return modelValue?.value?.values ?? [];
    });
    const busComponents = ref<Set<SaveBusComponent>>(new Set());
    const { getColumns } = useAchievementTypeData();

    function registerSaveBusComponent (form: SaveBusComponent) {
      busComponents.value.add(form);
    }

    function unregisterSaveBusComponent (form: SaveBusComponent) {
      busComponents.value.delete(form);
    }

    function saveAll () {
      busComponents.value.forEach(f => f.save());
    }

    provide(provideAchievementInstance, {
      register: registerSaveBusComponent,
      unRegister: unregisterSaveBusComponent
    } as AchievementInstanceProvide);

    watch(modelValue, (val?: Instance) => {
      emit('update:modelValue', val);
    });

    return {
      valueModels,
      columnTypes
    };
  }
});

</script>
