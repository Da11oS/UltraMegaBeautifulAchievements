<template>
  <v-card>
    <v-card-title>
      <v-toolbar>
        <v-text-field
          label="Название типа достижения"
          v-model="name"
          :rules="rules"
          hide-details="auto"
        >
        </v-text-field>
        <v-btn icon @click="columns.push(getNewColumn)">
          <v-icon>
            mdi-plus
          </v-icon>
        </v-btn>
      </v-toolbar>
    </v-card-title>
    <v-card-text>
  <v-list>
    <ColumnOfType @column:remove="removeColumn">
    </ColumnOfType>
  </v-list>
    </v-card-text>
    <v-card-actions>
      <v-btn @click="$emit('click:close')">
        Отмена
      </v-btn>
      <v-spacer>
      </v-spacer>
      <v-btn color="primary" @click="$emit('type:create', model)">
        Создать
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang = "ts">
import { computed, defineComponent, ref } from '@vue/composition-api';
import ColumnOfType, { Column } from '@/components/Types/ColumnOfType.vue';

export default defineComponent({
  name: 'TypeCreateForm',
  components: { ColumnOfType },
  props: {
    groupId: { type: Number },
    typeId: { type: Number }

  },
  setup () {
    const columns = ref<Column[]>();
    const getNewColumn = computed(() :Column => {
      return {
        dataType: 0,
        id: null,
        typeId: 0,
        label: ''
      };
    });
    function removeColumn (column: Column) {
      const index = columns.value?.indexOf(column);
      if (index) {
        columns.value?.splice(index);
      }
    }
    return {
      columns,
      removeColumn
    };
  }
});
</script>
