<template>
  <v-card>
    <v-list>
    <v-list-group v-for="group in groupsWithTypes "
                  :key="group.id"
                  prepend-icon="mdi-format-list-bulleted">
      <template v-slot:activator>
        <v-list-item-content>
          <v-list-item-title>{{ group.name }}</v-list-item-title>
        </v-list-item-content>
      </template>
      <v-list>
        <v-list-item v-for="type in group.types "
                     :key="type.id">
          <v-list-group prepend-icon="mdi-trophy-variant-outline"
                        sub-group
          style="width: 100%"
          @click="showTypeHandler(type)">
            <template v-slot:activator>
              <v-list-item-content>
                <v-list-item-title>{{ type.name }}</v-list-item-title>
              </v-list-item-content>
            </template>
            <UserTypeAchievements :type-id="type.id">

            </UserTypeAchievements>
          </v-list-group>
        </v-list-item>
      </v-list>
    </v-list-group>
    </v-list>
  </v-card>
</template>

<script lang="ts">
import UserTypeAchievements from '@/components/UserAchievemnts/UserTypeAchievements.vue';
import { defineComponent, onMounted } from '@vue/composition-api';
import { useGroupData } from '../groups/groupsComposable';
import { Type } from '@/api';

export default defineComponent({
  name: 'UserAchievementsList',
  components: { UserTypeAchievements },
  setup (props, { emit }) {
    const { getGroupsWithTypes, groupsWithTypes } = useGroupData();
    onMounted(getGroupsWithTypes);
    function showTypeHandler (type: Type) {
      emit('showType', type);
    }

    return {
      groupsWithTypes,
      showTypeHandler
    };
  }
});
</script>
