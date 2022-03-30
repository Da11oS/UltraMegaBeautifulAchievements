<template>
  <v-dialog v-model="dialogComp">
    <v-card>
      <v-card-title>
        Создание группы достижений
      </v-card-title>
      <v-card-text>
        <v-text-field
          label="Название"
          v-model="name"
          :rules="rules"
          hide-details="auto"
        ></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-btn @click="dialogComp = false">
          Отмена
        </v-btn>
        <v-spacer>
        </v-spacer>
        <v-btn color="primary" @click="$emit('group:create', model)">
          Создать
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Group } from '@/api';
import { computed, ref, set, toRef, watch } from '@vue/composition-api';

export default {
  name: 'GroupCreateDialog',
  props: {
    dialog: { type: Boolean, require: true, default: false }
  },
  emits: {
    'group:create': (value: Group) => true
  },
  model: {
    prop: 'dialog',
    event: 'dialog:update'
  },
  setup (props: any, { emit }: any) {
    const name = ref('');
    const dialog = toRef(props, 'dialog');
    const dialogComp = computed({
      get: () => dialog.value,
      set: (value) => {
        dialog.value = value;
        emit('dialog:update', value);
      }
    });
    const model = computed(() => {
      return { id: null, name: name.value } as Group;
    });

    const rules = ref<((value: string) => void)[]>([
      (value: string) => !!value || 'Required.',
      (value: string) => (value && value.length >= 3) || 'Min 3 characters'
    ]);
    return {
      name,
      rules,
      dialogComp,
      model
    };
  }
};
</script>
