function * genFibonacci (){
    let a = 0
    let b = 1
    while (true){
        [a, b] = [b, a+b]
        yield a
    }
}

// 제너레이터 객체 추출
const fib = genFibonacci()
for (const num of fib){
    // 무한 반복하게 되므로 100을 넘으면 탈출
    if (num > 100) break
    console.log(num)
}