<template>
<v-text-field :label="modelValue.column.label" outlined v-model="instanceValue">

</v-text-field>
</template>

<script lang="ts">
import { computed, defineComponent, PropType, toRef, watch } from '@vue/composition-api';
import { InstanceValue } from '@/components/DataComponents/dataComposable';

export default defineComponent({
  name: 'NumberField',
  props: {
    modelValue: { type: Object as PropType<InstanceValue> }
  },
  setup (props, { emit }) {
    const modelValue = toRef(props, 'modelValue');
    const instanceValue = computed({
      get (): string | undefined {
        return props.modelValue?.value ?? undefined;
      },
      set (value: string | undefined) {
        if (modelValue.value) {
          modelValue.value.value = value ?? null;
        }
      }
    });
    watch(modelValue, (value) => {
      emit('update:modelValue', value);
    });
    return {
      instanceValue
    };
  }
});
</script>

<style scoped>

</style>
