# react

- 리액트/JSX에서는 자바스크립트 내부에 HTML 작성 가능

- 기본적으로 추가해야될 코드

  ```html
  <script src="https://unpkg.com/react@15/dist/react.min.js"></script>
  <script src="https://unpkg.com/react-dom@15/dist/react-dom.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/babel-core/5.8.38/browser.min.js"></script>
  ```

## JSX

- JSX는 바벨에 의해 자바스크립트로 변환되고 실행됨

  ```javascript
  // 아래코드가
  const e = (
  	<h1 id="greeting">
      	<p>하이</p>
      </h1>
  )
  // 이렇게 변경됨
  var e = React.createElement(
  	"h1",
      null,
      React.createElement(
          "p",
          { id: "greeting" },
          "하이"
      )
  )
  ```

  ### 작성시 주의점

  - 반드시 닫는 태그를 작성해야됨

  - 이와 같은 경우

    ```html
    <script>
        /*
        이렇게 사용하면 안되고
        function getDOM() {
            return <div><p>하이</p></div>
        }
        */
        // JSX범위를 소괄호로 감싸서 JSX의 범위를 명시적으로 지정해줘야함
        function getDOM() {
            return (<div><p>하이</p></div>)
        }
        /*
        이렇게 여러개 써도 안됨
        function getDOM() {
            return (
            	<div><p>하이</p></div>
            	<div><p>하이</p></div>
            )
        }
        */
    </script>
    ```

## 가상 DOM

- 리액트가 인기있는 이유가 가상 DOM 때문이라고 함

- 가상 DOM은 DOM의 상태를 메모리에 저장하고, 변경 전과 변경 후의 상태를 비교한 뒤 필요한 최소한의 내용만 반영하는 기능

- DOM을 변경할때는 ReactDOM.render() 메서드를 사용하면됨

- 리액트는 자동으로 가상 DOM을 구축하느모 가상 DOM을 사용하기 위해 별도의 코드를 작성할 필요가 없음

- 예를들어 시계를 화면에 띄운다고 하자

  그러면 보통은 코드 싹다 갈아엎고 새로 쓰는데

  react는 바뀌는 숫자부분만 업뎃이 된다.. 신기함..

## 컴포넌트(Component)

- 특정 기능을 가진 범용적인 "부품"을 나타내는 용어

- react 컴포넌트 예시

  ```javascript
  // props의 props.type을 h1태그로 감싸 출력하는 예제
  // 컴포넌트 정의
  function Greeting (props) {
  	return <h1>{props.type}</h1>
  }
  
  // 컴포넌트 사용
  const dom = <div>
  	<Greeting type="하이"/>
  	<Greeting type="반가워"/>
  	<Greeting type="근데 왜 인사안하니"/>
  </div>
  
  // react로 출력
  ReactDOM.render (dom, document.getElementById('root'))
  ```

- 클래스로 만드는 컴포넌트 예시

  ```javascript
  class PhotoText extends React.Component {
      getImageURL () {
          return this.props.image;
      }
      render () {
          const label = this.props.label
          const url = this.getImageURL()
          const boxStyle = {
              border: "1px solid silver",
              margin: "8px",
              padding: "4px"
          }
          return (<div style={boxStyle}>
              <img src={url} width="128"/>
                  <span> {label} </span>
      </div>)
      }
  }
  // 컴포넌트를 사용합니다. --- (※2)
  const dom = <div>
        <PhotoText image="https://picsum.photos/300/200" label="랜덤이미지"/>
        <PhotoText image="https://picsum.photos/300/200" label="랜덤이미지"/>
        <PhotoText image="https://picsum.photos/300/200" label="랜덤이미지"/>
  </div>
  // 리액트로 DOM의 내용을 변경합니다.
  ReactDOM.render(dom, document.getElementById('root'))
  ```

- 화살표 함수로 만드는 컴포넌트 예시

  ```html
  <div id="root"></div>
  <script type="text/babel">
  	const TitleParts = (props) => (
  		<div style={{backgroundColor: 'red', color: 'white'}}>
  		<h3>{props.title}</h3>
      </div>
  	)
  	const ContentParts = (props) => (
  		<div style={{border: '1px solid blue', margin: 15}}>
  		<div>줄거리: {props.body}</div>
      </div>
  	)
  	// 메인 컴포넌트
  	const Book = (props) => (
      <div>
  		<TitleParts title={props.title} />
  		<ContentParts body={props.body} />
      </div>
  	)
  	// 리액트로 DOM의 내용을 변경합니다.
  	ReactDOM.render(
  		(<div>
  		<Book title='삼국지' body='옛날 중국 이야기' />
  		<Book title='민수기' body='옛날 이스라엘 이야기' />
  		<Book title='서유기' body='원숭이가 활약하는 이야기' />
      </div>),
  		document.getElementById('root'))
  </script>
  ```

- 위의 컴포넌트 예제들은 특정한 상태를 가지지 않았음(stateless 컴포넌트)

  체크박스처럼 어떤 상태를 가지거나 외관상 크게 변화하는 컴포넌트의 경우 상태를 갖게 하고 관리해야함

  이때 state 객체를 사용하며 값을 변경 시에  setState() 메서드를 사용함

  ```react
  class [컴포넌트 이름] extends React.Component {
      constructor (props) {
          this.state = { [초기값] }
      }
      // 상태 참조시
      console.log( this.state.[이름] )
      // 상태 변경시
      this.setState( { [이름]: [새로운 값] } )
  }
  ```



# Node.js

## require

- 원래 자바스크립트는 웹 브라우저에서 실행되어 외부 모듈을 읽어들이는 기능이 존재하지 않았음

- 그래서 Node.js는 CommonJS 사양을 기반으로 모듈기능을 추가함

- CommonJS란 자바스크립트로 서버 사이트 또는명령줄 도구를 개발하기 위해 만들어진

  자바스크립트의 표준적인 API 사양 정의임

- 예를들어 덧셈, 곱셈 모듈을 만들어보면

  ```javascript
  // node_module_test.js
  function add (a, b) { return a + b }
  function mul (a, b) { return a * b }
  module.exports = {
      'add': add,
      'mul': mul
  }
  
  // node_module_test_main.js
  const mdt = require('./node_module_test.js')
  console.log('3+5=', mdt.add(3, 5))
  console.log('3*5=', mdt.mul(3, 5))
  ```

- 결과값은 아래와 같이 나온다

  ```shell
  $ node node_module_test_main.js
  3+5= 8
  3*5= 15
  ```

## export/import

- 이걸 쓰려면 바벨을 사용해서 변환해야된다

  그냥 실행은 안된다고 그럼

- 이렇게도 사용이 가능하다

  ```javascript
  // node_module_test2.js
  export function add (a, b){ return a + b }
  export function mul (a, b){ return a * b }
  
  // node_module_test_main2.js
  console.log('3+5=', mdt.add(3, 5))
  console.log('3*5=', mdt.mul(3, 5))
  ```

- 이후 콘솔창에

  ```shell
  babel node_module_test_main2.js -d node_module_test_main2_result.js
  ```

  