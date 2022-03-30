<template>
  <v-file-input>
  </v-file-input>
</template>

<script lang="ts">
import { defineComponent, PropType } from '@vue/composition-api';
import { ValueOfInstanceColumn } from '@/components/DataComponents/AchievementInstance.vue';

export default defineComponent({
  name: 'FileField',
  props: {
    model: { type: Object as PropType<ValueOfInstanceColumn> }
  }
});
</script>

<style scoped>

</style>
