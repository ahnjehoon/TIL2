const fs = require('fs')

console.log("@@@ 제너레이터 @@@")
// 제너레이터
// 반복 처리가 가능한 이터레이터(Iterator)를 쉽게 구현할 때 사용하는 기능

function read_gfn (g, fname) {
    fs.readFile(fname, 'utf-8', (err, data) => {
        if(err) console.log(err)
        g.next(data)
    })
}
// 제너레이터 함수 정의
const g = (function * () {
    const a = yield read_gfn(g, 'test.txt')
    console.log(a)
    const b = yield read_gfn(g, 'test2.txt')
    console.log(b)
    const c = yield read_gfn(g, 'test3.txt')
    console.log(c)
})()
// 책에서는 이 부분이 빠져있음..
g.next()