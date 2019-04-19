# window 버전

- 리눅스버전은 하게된다면 추가하기로..

- <https://dev.mysql.com/downloads/windows/installer/8.0.html>
- 옵션중 server 하고 workbench만 설치 해도 됨



## 외부 접속 설정

- 1044 ERROR

  ```mysql
  GRANT ALL PRIVILEGES ON *.* TO 'test_user'@'%';
  ```

- 첫 설치시 root 계정도 만들어 줘야함

  ```mysql
  CREATE USER 'test_user'@'%' identified by '패스워드입력';
  ```



## 간단 사용법

##### DB 생성

```mysql
create database product_predict;
```

##### DB 사용

```mysql
use product_predict;
```

###### TABLE 생성

```mysql
CREATE TABLE test_table
(
    `col1`  INT            NOT NULL    AUTO_INCREMENT, 
    `col2`  VARCHAR(45)    NULL, 
    `col3`  VARCHAR(45)    NULL, 
    `col4`  VARCHAR(45)    NULL, 
    PRIMARY KEY (col1)
);
```

##### INSERT

```mysql
insert into test_table(
	 col2
    ,col3
    ,col4
) values(
	"test1", "test2", "test3"
);
```

##### SELECT

```mysql
select col1, col2, col3, col4
from test_table;
```

##### UPDATE

```mysql
UPDATE test_table
SET
	col2 = '수정됨1'
    ,col3 = '수정됨2'
WHERE col1 = 1;
```

##### DELETE

```mysql
DELETE FROM test_table
WHERE col1 = 1;
```



#### 실수 방지

- 실수로 UPDATE나 DELETE를 하면 대참사가 일어나니 코드실행전 아래 코드는 꼭 기입해두고 사용하자
  1. START TRANSACTION; 입력
  2. 코드 작성
  3. COMMIT 또는 ROLLBACK
- 추가적으로 전체 코드 실행시 COMMIT같은건 #붙여서 주석처리 해놓자.. 꼭..

# 잡다한 에러들

- Error Code: 1175. You are using safe update mode and you tried to update a table without a WHERE that uses a KEY column
  workbench에서 Edit > Preferences > SQL Editor > Safe Updates 체크 해제
  그리고 재시작
- 