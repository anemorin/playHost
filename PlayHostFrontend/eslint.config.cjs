module.exports = {
  env: {
    browser: true,
    es2021: true,
  },
  extends: [
    'airbnb',
    'eslint:recommended',
    'plugin:react/recommended',
    'plugin:import/recommended',
    'plugin:prettier/recommended',
    'prettier'
  ],
  overrides: [
    {
      env: {
        node: true,
      },
      files: ['.eslintrc.{js,cjs}'],
      parserOptions: {
        sourceType: 'script',
      },
    },
  ],
  // parser: '@typescript-eslint/parser',
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module',
  },
  plugins: ['@eslint/js', 'react'],
  rules: {
    'no-unused-vars': 'off',

    'no-use-before-define': 'off',

    'no-undef': 'off',
    'react/jsx-no-undef': 'error',

    'no-shadow': 'off',

    indent: 'off',

    'brace-style': 'off',

    'no-restricted-syntax': 1,
    'spaced-comment': ['error', 'always'],
    'no-underscore-dangle': 'off',

    'jsx-a11y/click-events-have-key-events': 'off',
    'jsx-a11y/no-static-element-interactions': 'off',

    'import/extensions': 'off',
    'import/prefer-default-export': 'off',

    'react-hooks/exhaustive-deps': 'off',

    'react/destructuring-assignment': ['error', 'always'],
    'react/function-component-definition': [
      'error',
      {
        namedComponents: 'arrow-function',
        unnamedComponents: 'arrow-function',
      },
    ],
    'react/no-array-index-key': 'error',
    'react/jsx-closing-bracket-location': 'error',
    'react/jsx-closing-tag-location': 'error',
    'react/jsx-first-prop-new-line': ['error', 'multiline-multiprop'],
    'react/jsx-indent': [2, 2, { indentLogicalExpressions: true }],
    'react/jsx-indent-props': [2, 2],
    'react/jsx-max-props-per-line': [1, { when: 'always' }],
    'react/jsx-one-expression-per-line': ['error', { allow: 'single-child' }],
    'react/jsx-pascal-case': ['error', { allowNamespace: true }],
    'react/jsx-props-no-multi-spaces': 'error',
    'react/jsx-sort-props': [
      'warn',
      { shorthandLast: true, reservedFirst: true },
    ],
    'react/jsx-filename-extension': [1, { extensions: ['.jsx', '.tsx'] }],
    'react/require-default-props': 0,
    'react/jsx-props-no-spreading': 'off',
  },
};