# Node.js

## require

- 원래 자바스크립트는 웹 브라우저에서 실행되어 외부 모듈을 읽어들이는 기능이 존재하지 않았음

- 그래서 Node.js는 CommonJS 사양을 기반으로 모듈기능을 추가함

- CommonJS란 자바스크립트로 서버 사이트 또는명령줄 도구를 개발하기 위해 만들어진

  자바스크립트의 표준적인 API 사양 정의임

- 예를들어 덧셈, 곱셈 모듈을 만들어보면

  ```javascript
  // node_module_test.js
  function add (a, b) => a + b
  function mul (a, b) => a * b
  module.exports = {
      'add': add,
      'mul': mul
  }
  
  // node_module_test_main.js
  const mdt = require('./node_module_test.js')
  console.log('3+5=', mdt.add(3, 5))
  console.log('3*5=', mdt.mul(3, 5))
  ```

  $ node node_module_test_main.js
  3+5= 8
  3*5= 15

