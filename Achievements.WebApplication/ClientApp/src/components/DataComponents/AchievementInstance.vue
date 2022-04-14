<template>
  <v-container>
    <v-row style="border-bottom: solid gray 1px;">
    <v-col dense>
    <v-col dense v-for="(value, index) in valueModels"
           :key="value.id"
           cols="auto">
      <component :is="columnTypes.find(f => f.dataType === value.column.dataType).component" :modelValue="valueModels[index]" >
      </component>
    </v-col>

    </v-col>
    <v-col class=" d-flex align-center">
      <v-btn @click="saveAll">
        Сохранить
      </v-btn>
    </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { useAchievementTypeData } from '@/components/Types/AchievementTypeComposable';
import { computed, defineComponent, inject, PropType, provide, ref, toRef, watch } from '@vue/composition-api';
import { columnTypes, Instance, InstanceValue } from './dataComposable';
import axios from 'axios';

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
    const userId = inject<number>('userId');
    const busComponents = ref<Set<SaveBusComponent>>(new Set());
    const { getColumns } = useAchievementTypeData();

    function registerSaveBusComponent (form: SaveBusComponent) {
      busComponents.value.add(form);
    }

    function unregisterSaveBusComponent (form: SaveBusComponent) {
      busComponents.value.delete(form);
    }

    async function saveAll () {
      // if ((modelValue.value?.id ?? 0) === 0) {
      const user = await axios.get('Users/' + userId);
      if (modelValue.value)modelValue.value.user = user.data;
      await axios.post('Instances', modelValue.value);
      // }
      busComponents.value.forEach(f => f.save());
    }
    provide(provideAchievementInstance, {
      register: registerSaveBusComponent,
      unRegister: unregisterSaveBusComponent
    } as AchievementInstanceProvide);

    watch(modelValue, async (val?: Instance) => {
      emit('update:modelValue', val as Instance);
    });

    return {
      valueModels,
      columnTypes,
      saveAll
    };
  }
});

</script>
