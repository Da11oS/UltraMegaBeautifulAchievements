<template>
  <v-container>
    <v-tabs centered>
      <v-tab>Категории достижений</v-tab>
      <v-tab>Принять</v-tab>
      <v-tab-item>
        <groups-list></groups-list>
      </v-tab-item>
    </v-tabs>
  </v-container>
</template>

<script lang="ts">
import GroupsList from '@/components/groups/GroupsList.vue';
import { defineComponent, ref } from '@vue/composition-api';

export default defineComponent({
  name: 'AdminView',
  components: { GroupsList },
  setup () {
    const tabId = ref<number>(1);
    return {
      tabId
    };
  }
});
</script>
