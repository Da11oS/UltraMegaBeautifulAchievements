<script lang="ts">
import { defineComponent, VNode } from "vue";
import { VForm } from "vuetify/lib/components";
import { Vue } from "vue-class-component";

interface SubmitEvent extends Event {
  submitter: HTMLElement;
}
export interface AFormValidationMsg {
  valid: string | true;
  prefix: string;
}

export interface InputInstance {
  reset(): void;
  resetValidation(): void;
  validate(): boolean;
  hasError: boolean;
  shouldValidate: boolean;
  _uid?: number;
  _props?: {label?: string};
  _data?: {
    errorBucket?: string[];
  };
}

export interface FormInstance {
  validate(): boolean;
  reset(): void;
  getFieldsErrors(): AFormValidationMsg[];
}

export interface VuetifyForms extends Vue {
  readonly: boolean;
  disabled: boolean;
  register(input: InputInstance): void;
  unregister(input: InputInstance): void;
  registerForm?: (from: FormInstance) => void;
  unregisterForm?: (from: FormInstance) => void;
  validate(): boolean;
  reset(): void;
  getFieldsErrors(): AFormValidationMsg[];
  errorBag: Record<string, boolean | null>;
  inputs: InputInstance[];
}

const validateVForm = Reflect.get(VForm, "options")?.methods?.validate;
const resetVForm = Reflect.get(VForm, "options")?.methods?.reset;

export default defineComponent({
  name: "CustomForm",
  props: {
    loading: { type: Boolean, default: false },
    byEnter: { type: Boolean, default: false },
  },
  inject: { form: { default: undefined } },
  data() {
    return {
      ...{} as VuetifyForms,
      ...{} as { form?: VuetifyForms },
      internalForms: [] as FormInstance[],
    };
  },
  emits: {
    submit: (ev: SubmitEvent) => true,
  },
  mixins: [VForm],
  created() {
    const { form } = this;

    if (form != null && form.registerForm != null) {
      form.registerForm(this);
    }
  },
  beforeUnmount() {
    const { form } = this;
    if (form != null && form.unregisterForm != null) {
      form.unregisterForm(this);
    }
  },
  methods: {
    validateBase(...arg: unknown[]) {
      return validateVForm.apply(this, arg);
    },
    resetBase(...arg: unknown[]) {
      return resetVForm.apply(this, arg);
    },
    validate() {
      let result = true;
      const { internalForms } = this;
      for (const form of internalForms) {
        result = result && form.validate();
      }
      result = result && this.validateBase();
      return result;
    },
    reset() {
      const { internalForms } = this;
      for (const form of internalForms) {
        form.reset();
      }
      this.resetBase();
    },
    getFieldsErrors(): AFormValidationMsg[] {
      const errors = [] as AFormValidationMsg[];
      const errorUids = [] as number[];
      const { errorBag, internalForms } = this;
      for (const key in errorBag) {
        if (errorBag[key] === true) errorUids.push(Number(key));
      }
      this.inputs.forEach(input => {
        const _uid = input?._uid;
        if (_uid != null && errorUids.includes(_uid)) {
          const errorBucket = input?._data?.errorBucket ?? [];
          const prefix = input?._props?.label ?? "";
          errors.push({ prefix, valid: errorBucket.join() });
        }
      });
      const internalErrors = internalForms
        .map(el => el.getFieldsErrors())
        .flat();
      if (internalErrors.length >= 0) {
        errors.push(...internalErrors);
      }
      return errors;
    },
    registerForm(from: FormInstance) {
      if (!this.internalForms.includes(from)) {
        this.internalForms.push(from);
      }
    },
    unregisterForm(from: FormInstance) {
      const ind = this.internalForms.indexOf(from);
      if (ind >= 0) this.internalForms.splice(ind, 1);
    },
  },

  render(this: VuetifyForms & {byEnter: boolean}, h: any): VNode {
    return h("form", {
      staticClass: "v-form",
      attrs: {
        novalidate: true,
        ...(this as any).attrs$,
      },
      on: {
        keypress: (ev: KeyboardEvent) => {
          if (ev.key === "Enter" && !this.byEnter) {
            ev.preventDefault();
          }
        },
        submit: (e: SubmitEvent) => {
          e.preventDefault();
          if (this.validate()) {
            this.$emit("submit", e);
          } else {
            e.stopPropagation();
          }
        },
      },
    }, this.$slots.default);
  },
});
</script>
