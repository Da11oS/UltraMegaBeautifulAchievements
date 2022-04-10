<template>
<v-list>
  <v-list-item>
  <v-list-item-title>
    <AchievemntsInstanceHeader >
    </AchievemntsInstanceHeader>
  </v-list-item-title>
  <v-list-item-content>
      <AchievementInstance>

      </AchievementInstance>
  </v-list-item-content>
  </v-list-item>
</v-list>
</template>

<script lang="ts">
import { defineComponent } from '@vue/composition-api';
import AchievementInstance from '@/components/DataComponents/AchievementInstance.vue';
import AchievemntsInstanceHeader from '@/components/DataComponents/AchievemntsInstanceHeader.vue';

export default defineComponent({
  name: 'UserTypeAchievements',
  components: { AchievemntsInstanceHeader, AchievementInstance },
  props: {
    typeId: Number
  },
  setup (props, { parent }) {
    if (parent) {
      console.log(parent);
      parent.$on('click', () => console.log(props.typeId + ', ' + parent.$data.isActive));
    }
  }
});
</script>
