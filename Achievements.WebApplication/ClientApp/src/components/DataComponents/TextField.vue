<template>
<v-text-field ref="fileField">
</v-text-field>
</template>

<script lang="ts">
import { defineComponent, inject, onMounted, onUnmounted, PropType, ref } from '@vue/composition-api';
import { InstanceValue } from '@/components/DataComponents/dataComposable';
import {
  AchievementInstanceProvide,
  provideAchievementInstance,
  SaveBusComponent
} from '@/components/DataComponents/AchievementInstance.vue';
import axios from 'axios';

export default defineComponent({
  name: 'TextField',
  props: {
    modelValue: { type: Object as PropType<InstanceValue> }
  },
  setup () {
    function save () {
      axios.post('File/Load');
    }
    const saveBusComponent = ref<SaveBusComponent>({
      save: save
    });

    const busComponent = inject(provideAchievementInstance) as AchievementInstanceProvide;
    const fileField = ref();

    onMounted(() => {
      console.log(fileField);
      busComponent.register(saveBusComponent.value);
    });

    onUnmounted(() => {
      busComponent.unRegister(saveBusComponent.value);
    });
  }
});
</script>
