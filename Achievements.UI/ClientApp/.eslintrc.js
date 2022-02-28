module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    "plugin:vue/vue3-essential",
    "@vue/standard",
    "@vue/typescript/recommended",
  ],
  parserOptions: {
    ecmaVersion: 2020,
  },
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
    "comma-dangle": ["error", "always-multiline"], // запятые везде
    quotes: ["error", "double"], // везде двойные кавычки
    semi: ["error", "always"], // точка с запятой обязательна
    "space-before-function-paren": ["error", "never"], // нет отступа перед параметрами функции
    eqeqeq: ["error", "always", { null: "ignore" }], // строгое равенство
    curly: "error", // фигурные скобки для блочных операторов

    "brace-style": ["error", "1tbs", { allowSingleLine: false }],
    "no-unused-expressions": "off",
    "@typescript-eslint/camelcase": "off", //["warn", { properties: "never" }],
    "vue/require-default-prop": "off",
    "no-unused-vars": "off",
    "@typescript-eslint/no-unused-vars": "off",
  },
};
