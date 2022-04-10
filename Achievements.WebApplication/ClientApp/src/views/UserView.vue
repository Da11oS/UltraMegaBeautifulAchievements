<template>
  <v-container>
    <UserAchievementsList>

    </UserAchievementsList>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, provide } from '@vue/composition-api';
import UserAchievementsList from '@/components/UserAchievemnts/UserAchivementsList.vue';

export default defineComponent({
  name: 'UserView',
  components: { UserAchievementsList },
  props: { userId: { type: Number } },
  setup (props) {
    provide('userId', props.userId);
  }
});
</script>
