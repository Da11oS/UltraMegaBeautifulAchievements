<template>
  <v-card>
    <v-card-title>
      <v-toolbar>
        <v-text-field
          label="Название типа достижения"
          v-model="name"
          hide-details="auto"
        >
        </v-text-field>
      </v-toolbar>
    </v-card-title>
    <v-card-text>
      <v-list>
        <ColumnOfType v-for="(col, idx) in columns"
                      :key="idx"
                      :model="col"
                      @column:remove="removeColumn(idx)">
          {{idx}}
        </ColumnOfType>
      </v-list>
    </v-card-text>
    <v-card-actions>
      <v-btn @click="$emit('click:close')">
        Отмена
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn color="primary" @click="addColumn(getNewColumn())">
        Добавить компонент
      </v-btn>
      <v-spacer>
      </v-spacer>
      <v-btn color="primary" @click="$emit('click:create', {model, columns})">
        Создать
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang = "ts">
import { computed, defineComponent, PropType, ref } from '@vue/composition-api';
import ColumnOfType, { Column } from '@/components/Types/ColumnOfType.vue';
import { Group, Type } from '@/api';

export default defineComponent({
  name: 'TypeCreateForm',
  components: { ColumnOfType },
  props: {
    group: { type: Object as PropType<Group>, required: true },
    type: { type: Object as PropType<Type> }
  },
  setup (props) {
    const columns = ref<Column[]>([]);

    const model = computed((): Type => {
      return {
        id: props.type?.id ?? 0,
        achievementGroup: props.group,
        name: name.value
      };
    });

    function getNewColumn ():Column {
      return {
        dataType: 0,
        id: 0,
        achievementType: props.type ?? null,
        label: ''
      };
    }

    const name = ref<string>('');
    function removeColumn (columnIndex: number) {
      columns.value.splice(columnIndex, 1);
    }

    function addColumn (column: Column) {
      columns.value.push(getNewColumn());
    }

    return {
      columns,
      removeColumn,
      addColumn,
      name,
      getNewColumn,
      model
    };
  }
});

</script>
