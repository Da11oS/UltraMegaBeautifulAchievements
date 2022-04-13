<template>
<v-list>
  <v-list-item-action style="position: absolute; top: 0px; right: 15px;"
  class="d-flex flex-row">
    <v-btn icon>
      <v-icon @click="createNewInstanceHandler">
        mdi-tag-plus-outline
      </v-icon>
    </v-btn>
    <v-btn icon @click="saveAll">
      <v-icon>
        mdi-content-save-all-outline
      </v-icon>
    </v-btn>
  </v-list-item-action>
  <v-list-item v-for="(instance, index) in achievements"
               :key="instance.id">
  <v-list-item-content>
      <AchievementInstance v-model="achievements[index]">
      </AchievementInstance>
  </v-list-item-content>
  </v-list-item>
</v-list>
</template>

<script lang="ts">
import { defineComponent, ref } from '@vue/composition-api';
import AchievementInstance from '@/components/DataComponents/AchievementInstance.vue';
import { Instance, InstanceValue } from '@/components/DataComponents/dataComposable';
import axios from 'axios';

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

    async function createNewInstanceHandler () {
      // todo
      const newInstance = await axios.get('Instances/Empty/' + props.typeId);
      achievements.value.push(newInstance.data as Instance);
    }

    function saveAll () {
      // todo
    }
    return {
      achievements,
      createNewInstanceHandler,
      saveAll
    };
  }
});
</script>
