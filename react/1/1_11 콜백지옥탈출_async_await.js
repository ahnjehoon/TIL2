const fs = require('fs')

console.log("@@@ async/await @@@")
// ES2017에서는 프로미스와 제너레이터를 이용한 프로그램보다 쉽게 코드를 작성할수 있게 async/await가 추가됨
// node7 이상부터 지원함
function readFileEx (fname) {
    return new Promise((resolve, reject) => {
        fs.readFile(fname, 'utf-8', (err, data) => {
            resolve(data)
        })
    })
}

async function readAll() {
    const a = await readFileEx('test.txt')
    console.log(a)
    const b = await readFileEx('test2.txt')
    console.log(b)
    const c = await readFileEx('test3.txt')
    console.log(c)
}
readAll()