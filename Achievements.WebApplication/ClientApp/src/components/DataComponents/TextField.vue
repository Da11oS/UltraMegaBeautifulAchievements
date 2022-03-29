<template>
<v-text-field>
</v-text-field>
</template>

<script lang="ts">
import { defineComponent, PropType } from '@vue/composition-api';
import { ValueOfInstanceColumn } from '@/components/Types/AchievementInstance.vue';

export default defineComponent({
  name: 'TextField',
  props: {
    model: { type: Object as PropType<ValueOfInstanceColumn> }
  }
});
</script>
