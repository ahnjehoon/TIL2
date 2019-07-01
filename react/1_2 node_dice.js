// URL에 따라 값이 다르게 나오게 하는 코드


// http 모듈 읽어들임
const http = require('http')
// 글자 깨짐 방지
const ctype = {'Content-Type': 'text/html; charset=utf-8'}


// 웹서버 실행
const svr = http.createServer(handler)
// 80 포트 설정
svr.listen(80)

// 서버에 접근이 있을 때의 처리
function handler (req, res){
    // URL 구분
    const url = req.url
    // 최상위 페이지 일 때
    if (url === '/' || url === '/index.html'){
        showIndexPage(req, res)
        return
    }
    // 주사위 페이지 일 때
    if (url.substr(0, 6) === '/dice/'){
        showDicePage(req, res)
        return
    }
    // 그 이외
    res.writeHead(404, ctype)
    res.end('404 not found')
}

// 인덱스 페이지에 접근했을 경우
function showIndexPage (req, res){
    // HTTP 헤더 출력
    res.writeHead(200, ctype)
    // 응답 본문 출력
    const html = '<h1>주사위 페이지 안내</h1>\n' +
    '<p><a href="/dice/6">6면체 주사위</a></p>' + 
    '<p><a href="/dice/12">12면체 주사위</a></p>'
    res.end(html)
}

// 주사위 페이지에 접근했을 때
function showDicePage (req, res){
    // HTTP 헤더 출력
    res.writeHead(200, ctype)
    console.log(req.url)
    const a = req.url.split('/')
    const diceNum = parseInt(a[2])
    // 임의 숫자 생성
    const rnd = Math.floor(Math.random() * diceNum) + 1
    // 응답 본문 출력
    res.end('<p style="font-size:72px;">' + rnd + '</p>')
}