# 개발 관련

## DevExpress

- 영문, 숫자, 특수기호만 입력 가능
  
	- ```c#
	    [컨트롤이름].MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
	    [컨트롤이름].EditMask = @"[a-zA-Z0-9~!@\#$%^&*\()\=+|\\/:;?""<>']{0,15}";
	    ```
	
	- 한글 입력이 가능하지만 한글은 processKey임으로 maskType에서 걸러지지는 않고
	
	    폼에서 포커스 아웃됬을때 처리


# MySQL

## 버전확인

- SELECT VERSION();

## sysdate(), now()의 차이

- sysdate()는 실행시점마다 실행하므로 한 쿼리내에서도 시간이 오래걸리면 시간이 다름
- now()는 한쿼리내에서 한번만 동작함
- 그러니깐 앵간하면 now()를 사용하자

## SEQ 생성

- 두가지 방법이 존재함
- 하나는 Sequence Master Table을 생성해서  + 1이 되게 만들기
- 또하나는 테이블의 최신값을 가져와서 + 1 하기

### 테이블 생성

```mysql
DROP TABLE IF EXISTS SEQ_MASTER;
-- SEQ 테이블 생성
CREATE TABLE SEQ_MASTER(
	 SEQ_NAME	VARCHAR(45) PRIMARY KEY
    ,SEQ		INT NOT NULL DEFAULT 0 
);
-- 함수생성
DROP FUNCTION IF EXISTS GET_SEQ;
DELIMITER $$
CREATE FUNCTION GET_SEQ (p_seq_name VARCHAR(45))
RETURNS INT READS SQL DATA
BEGIN
	DECLARE RESULT_ID INT;
	UPDATE SEQ_MASTER
	SET SEQ = LAST_INSERT_ID(SEQ+1) 
	WHERE seq_name = p_seq_name;
	SET RESULT_ID = (SELECT LAST_INSERT_ID());
	RETURN RESULT_ID;
END $$
DELIMITER ;
-- 예시
-- SEQ 데이터 삽입
INSERT INTO SEQ_MASTER VALUES ('EquipmentPartExchange', 0);
-- SEQ 조회시
SELECT CONCAT('EP',LPAD(GET_SEQ('EQUIPMENTPARTEXCHANGE'),8,0));

-- 숫자 초기화
UPDATE SEQ_MASTER
SET SEQ = 0
WHERE SEQ_NAME = 'EQUIPMENTPARTEXCHANGE';
```



### 최신값 가져와서 더하기

- ```mysql
  /*
  총 SEQ 길이 20
  2	CODE
  8	DATE
  10	SEQ 100억
  */
  set @order_date = substring(sysdate(), 1, 10);
  set @order_date = replace(@test, '-', '');
  set @order_seq = (select max(order_seq) from order_info where  order_date = @order_date);
  set @order_seq = (select if(@order_seq, lpad(@order_seq+1,8,'0'), '00000000'));
  set @uniq = concat('문자', @order_date, @order_seq);
  select @order_date, @order_seq, @uniq;
  ```



## 날짜 비교

- ```>= and <=``` 이렇게 사용하지말고 ```between```을 사용하자

### unix_timestamp를 사용할때

- 현재 날짜를 int형으로 변환해서 좀 더 빠르다고함

- unix_timestamp([인자값])을 기본 형태로하며 인자값이 없으면 현재 시간

  - unix_timestamp(yyyy-MM-dd)와 unix_timestamp(yyyyMMdd)를 동일하게 처리함
  - unix_timestamp()와 unix_timestamp(now())가 동일함

- from_unixtime([인자값])으로 date형태로 변환함

- ```mysql
  select * from [테이블명]
  where 
  	-- reg_date가 now()형식으로 되어있을 때 어제부터 오늘거를 조회한다하면
  	-- reg_date between substring(now(), 1, 10) and 'substring(now()+INTERVAL 1 DAY, 1, 10)'
  	-- reg_date가 unixtimestamp로 되어있을때 어제부터 오늘거를 조회한다면
  	-- INTERVAL 1 DAY 대신 60*60*24한 86400을 더해줘도된다
  	reg_date between unix_timestamp(substring(now(), 1, 10)) and unix_timestamp(substring(now()+INTERVAL 1 DAY, 1, 10))
  ```


#### 변환값

- ```SELECT UNIX_TIMESTAMP()``` 기본 UNIX_TIMESTAMP 10자리
- ```SELECT ROUND(UNIX_TIMESTAMP(now(4)) * 1000)``` 10자리 + 소수점 3자리

## 날짜 일부 추출

- 년 YEAR([기준날짜])

- 월 MONTH([기준날짜])

- 일 DAY([기준날짜])
  
  - 앞에 0채우고 싶다면 `SELECT LPAD(MONTH('2019-10-01'),'2','0')`
  
- ```mysql
  select date_format(now(), '%Y%m%d%H%i%s')
  ```

- 

# 유효성 체크

- 아직 유효성 관련해서는 따로 나오지 않음

- 예시

  ```c#
  // 유효성검사 샘플
  for (int i = 0; i < dtSave.Rows.Count; i++)
  {
      if (dtSave.Rows[i]["CRUD"].ToString() == "C"
          || dtSave.Rows[i]["CRUD"].ToString() == "U")
      {
          if (dtSave.Rows[i]["PART_NAME"].ToString() == "")
          {
              _gdFIRST_VIEW.FocusedRowHandle = i;
              _gdFIRST_VIEW.FocusedColumn = _gdFIRST_VIEW.Columns["PART_NAME"];
              _gdFIRST_VIEW.SetColumnError(_gdFIRST_VIEW.Columns["PART_NAME"], "한글나옴?");
              CoFAS_DevExpressManager.ShowInformationMessage("빈공백으로 남겨두면 안돼요(추후 언어설정 등록필요)\n숫자만 입력,소수만입력, 글자만입력, 글자길이 등등..");
              return;
          }
      }
  }
  ```

  

# GIT

## 버전관리

### master (pre-receive hook declined) gitlab

- Settings > Repository > Protected Branches
  - 현재 계정 권한이 maintainer 임에도 불구하고 master branch를 날리지 못함(버그로 예상)
  - 리스트중 master branch로 되어 있는 부분 Unprotect