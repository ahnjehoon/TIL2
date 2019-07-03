const fs = require('fs')

// 콜백지옥
fs.readFile('test.txt', 'utf-8', (err, data) => {
    console.log('test를 1번 읽었다', data)
    fs.readFile('test.txt', 'utf-8', (err, data) => {
        console.log('test를 2번 읽었다', data)
        fs.readFile('test.txt', 'utf-8', (err, data) => {
            console.log('test를 3번 읽었다', data)
        })
    })
})
