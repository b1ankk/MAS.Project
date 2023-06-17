module.exports = {
    printWidth: 100,
    tabWidth: 4,
    semi: true,
    trailingComma: 'es5',
    singleQuote: true,
    jsxSingleQuote: false,
    arrowParens: 'avoid',
    endOfLine: 'crlf',
    importOrder: [
        '^[^./]*[^.]*[.]css$',
        '^[.]{1,2}/.*(?<!.css)$',
        '^[.]{1,2}/.*[.]css$',
    ],
    importOrderSortSpecifiers: true,
};
