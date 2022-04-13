<template>
  <v-file-input ref = input :label="modelValue.column.label"  outlined
                v-model="file">
  </v-file-input>
</template>

<script lang="ts">
import { computed, defineComponent, inject, onMounted, onUnmounted, PropType, ref, toRef } from '@vue/composition-api';
import { InstanceValue } from '@/components/DataComponents/dataComposable';
import axios from 'axios';
import {
  AchievementInstanceProvide,
  provideAchievementInstance,
  SaveBusComponent
} from '@/components/DataComponents/AchievementInstance.vue';

export default defineComponent({
  name: 'FileField',
  props: {
    modelValue: { type: Object as PropType<InstanceValue> }
  },
  setup (props) {
    const file = ref<any>();
    const input = ref<any>();
    function save () {
      console.log('save');
      console.log(file.value);
      axios.post('File/Load', file.value, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
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
    return {
      file,
      input
    };
  }
});
</script>
