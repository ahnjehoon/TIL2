// 화살표 함수는 this가 나타내는 대상이 다름
// function에서는 this가 함수 자신을 나타내며
// 화살표 함수는 this를 따로 변경하지 않음

const fs = require('fs')

fs.readFile('test.txt', 'utf-8', (err, data) => {
    console.log(data)
})