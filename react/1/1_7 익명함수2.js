// 소문자를 대문자로 변환하는 예시
const s = 'Keep On Asking, and It Will Be Given You'
const r = s.replace(/[a-z]+/g, (m) => {
    return m.toUpperCase()
})
console.log(r)

// 배열의 숫자를 정렬하는 예
const ar = [100, 1, 5, 2, 20, 43, 30, 11]
ar.sort((a, b) => {
    console.log(a - b, a, b)
    return a - b
})
console.log(ar)
// 정렬이 되는 이유는
// sort 내부에 compareFunction이 포함되어 있어서
// 음수 양수를 비교해 index를 바꿈