<template>
  <v-card>
  <v-expansion-panels>
    <v-spacer></v-spacer>
    <v-btn
      icon
      @click="createGroupDialog = true">
      <v-icon>mdi-playlist-plus</v-icon>
    </v-btn>
    <v-expansion-panel v-for="group in groupsWithTypes"
                       :key="group.id">
      <v-expansion-panel-header
        class="px-2 rounded-0"
        style="border-top:1px solid gainsboro; border-bottom: 1px solid gainsboro;">
        <template #actions>
          <v-icon
            class="text--primary"
            style="order: 0"
          >
            mdi-menu-right
          </v-icon>
        </template>
        <div style="order: 1; ">
          <div style="display: grid; column-gap: 8px; grid-template-columns: 1fr auto; align-items: center;">
            <div
              class="text-body-1 d-inline-block d-flex text-truncate"
            >
                <span
                  class="font-weight-medium pl-1 pr-2 "
                >
                  {{group.name}}
                </span>
            </div>
            <template>
              <div>
              <v-btn icon color="red">
                <v-icon>mdi-trash-can</v-icon>
              </v-btn>
              <v-btn icon @click="createTypeClickHandler(group)">
                <v-icon> mdi-playlist-plus</v-icon>
              </v-btn>
              </div>
            </template>
          </div>
        </div>
      </v-expansion-panel-header>
      <v-expansion-panel-content eager>
            <v-list-item v-for="type in group.types"
                         :key="type.id"
            tag="div">
              <v-list-item-title>
                <span> {{ type.id }} </span>
                <span> {{ type.name }}</span>
              </v-list-item-title>
              <v-list-item-action
                style="display: grid;
                       column-gap: 8px;
                       grid-template-columns: repeat(auto-fill, auto)">
                <v-btn icon  color="red" @click="consoleLog">
                  <v-icon> mdi-trash-can</v-icon>
                </v-btn>
                <v-btn icon  @click="consoleLog">
                  <v-icon> mdi-pencil-outline</v-icon>
                </v-btn>
              </v-list-item-action>
            </v-list-item>
       </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
    <v-dialog v-model="createTypeDialog.isShow">
    <TypeCreateForm
      :group="createTypeDialog.group"
      @click:close="createTypeDialog.isShow = false"
      @click:create="achievementCreateHandler">
    </TypeCreateForm>
    </v-dialog>
    <group-create-dialog
      v-model="createGroupDialog"
      @group:create="groupCreateHandler"
    ></group-create-dialog>
  </v-card>
</template>

<script lang ="ts">

import { computed, defineComponent, onMounted, ref } from '@vue/composition-api';
import { Group, Type } from '@/api';
import { GroupWithTypes, useGroupData } from '@/components/groups/groupsComposable';
import GroupCreateDialog from '@/components/groups/GroupCreateDialog.vue';
import TypeCreateForm from '@/components/Types/TypeCreateForm.vue';
import { useAchievementTypeData } from '@/components/Types/AchievementTypeComposable';
import { Column } from '@/components/Types/ColumnOfType.vue';

interface TypeDialog {
  isShow: boolean;
  type: number | null;
  group: Group | null;
}
export default defineComponent({
  name: 'GroupsList',
  components: { TypeCreateForm, GroupCreateDialog },
  setup () {
    const { createGroup, getGroupsWithTypes, groupsWithTypes } = useGroupData();
    const { createAchievementType } = useAchievementTypeData();
    const createGroupDialog = ref<boolean>(false);
    const createTypeDialog = ref<TypeDialog>({ isShow: false, type: null, group: null });

    function createTypeClickHandler (group: Group, typeId?: number) {
      console.log(group);
      createTypeDialog.value.isShow = true;
      createTypeDialog.value.type = typeId ?? null;
      createTypeDialog.value.group = group;
    }

    async function achievementCreateHandler (event: any) {
      await createAchievementType(event.model, event.columns);
    }

    async function groupCreateHandler (group: Group) {
      await createGroup(group);
      createTypeDialog.value.isShow = false;
    }

    onMounted(getGroupsWithTypes);

    return {
      createGroup,
      groupCreateHandler,
      createGroupDialog,
      createTypeDialog,
      createTypeClickHandler,
      achievementCreateHandler,
      groupsWithTypes
    };
  },
  methods: {
    consoleLog () {
      console.log('action');
    }
  }
});
</script>
