<template>
<v-text-field type="number">

</v-text-field>
</template>

<script lang="ts">
import { defineComponent, PropType } from '@vue/composition-api';
import { ValueOfInstanceColumn } from '@/components/DataComponents/AchievementInstance.vue';

export default defineComponent({
  name: 'NumberField',
  props: {
    model: { type: Object as PropType<ValueOfInstanceColumn> }
  }
});
</script>

<style scoped>

</style>
