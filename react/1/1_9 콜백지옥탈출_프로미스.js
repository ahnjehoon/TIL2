const fs = require('fs')

console.log("@@@ 프로미스 @@@")
// 프로미스
// 비동기 처리로 구한 실제값을 반환하지 않고
// 일단 Promise 객체를 반환한 뒤 처리 완료되는 시점에서 실제 값을 사용할 수 있게 하는 기능
function readFile_pr (fname) {
    return new Promise((resolve) => {
        fs.readFile(fname, 'utf-8', (err, s) => {
            resolve(s)
        })
    })
}

readFile_pr('test.txt')
.then((text) => {
    console.log('1번째 test파일 읽음', text)
    return readFile_pr('test2.txt')
})
.then((text) => {
    console.log('2번째 test파일 읽음', text)
    return readFile_pr('test3.txt') 
})
.then((text) => {
    console.log('3번째 test파일 읽음', text)
})