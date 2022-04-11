<template>
<v-list>
  <v-list-item v-for="instance in achievements"
               :key="instance.id">
  <v-list-item-content>
      <AchievementInstance model-value="instance">
      </AchievementInstance>
  </v-list-item-content>
  </v-list-item>
</v-list>
</template>

<script lang="ts">
import { defineComponent, ref } from '@vue/composition-api';
import AchievementInstance from '@/components/DataComponents/AchievementInstance.vue';
import { Instance } from '@/components/DataComponents/dataComposable';

export default defineComponent({
  name: 'UserTypeAchievements',
  components: { AchievementInstance },
  props: {
    typeId: Number
  },
  setup (props, { parent }) {
    const achievements = ref<Instance[]>([]);
    if (parent) {
      console.log(parent);
      parent.$once('click', () => console.log(props.typeId + ', ' + parent.$data.isActive));
    }
    return {
      achievements
    };
  }
});
</script>
