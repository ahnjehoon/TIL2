// http 모듈 읽어들임
const http = require('http')

// 웹서버 실행
const svr = http.createServer(handler)
// 80 포트 설정
svr.listen(80)

// 서버에 접근이 있을 때의 처리
function handler (req, res){
    console.log('url:', req.url)
    console.log('method:', req.method)
    // HTTP 헤더 출력
    res.writeHead(200, {'Content-Type': 'text/html; charset=utf-8'})
    // 응답본문 출력
    res.end('<h1>하이</h1>\n')
}