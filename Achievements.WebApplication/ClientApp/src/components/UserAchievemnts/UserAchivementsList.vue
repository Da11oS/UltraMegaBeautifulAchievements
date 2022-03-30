<template>
  <v-card>
    <v-expansion-panels>
      <v-spacer></v-spacer>
      <v-btn
        icon
        @click="createGroupDialog = true">
        <v-icon>mdi-playlist-plus</v-icon>
      </v-btn>
      <v-expansion-panel v-for="group in groupsList"
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
                  <v-btn icon @click="createTypeClickHandler(group.id)">
                    <v-icon> mdi-playlist-plus</v-icon>
                  </v-btn>
                </div>
              </template>
            </div>
          </div>
        </v-expansion-panel-header>
        <v-expansion-panel-content eager>
          <v-list-item v-for="type in group.items"
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
              <v-btn icon @click="consoleLog">
                <v-icon> mdi-trash-can</v-icon>
              </v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
  </v-card>
</template>

<script>
export default {
  name: 'UserAchivementsList'
};
</script>

<style scoped>

</style>
