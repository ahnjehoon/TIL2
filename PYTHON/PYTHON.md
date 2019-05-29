# PYTHON

## 기타 잡다한 사항

### 패키지 업데이트 할때

- 패키지들 확인

  !pip freeze

- 업데이트

  !pip install [패키지명 입력] --upgrade --user

### method와 function의 차이

- 쉽게 클래스 안에 있으면 method

- 밖에 있으면 function


#### function

- 함수는 메소드 보다 큰 의미
- 쉽게 말해서 [함수]인 애

#### method

- 쉽게 말해서 클래스.[함수]인 애 (.[함수].[함수].[함수]도 됨)

## 기초 사항

### 파일 읽기

```python
with open("C:/open_data_key.txt", 'r', encoding='utf-8') as f:
    ServiceKey = f.read()
# 여러줄일 때
with open("C:/content.txt", 'r', encoding='utf-8') as f:
    content = f.readlines()
```

### 디렉토리 생성

```python
import os
dir_path = "폴더를 생성하고 싶은 경로"
dir_name = "폴더 이름
os.mkdir(dir_path + "/" + dir_name + "/")
```

# 



## 코드 관련

### yyyymm만들기

```python
import datetime as dt
from dateutil.relativedelta import relativedelta
yyyymm_1 = '200801'
yyyymm_2 = '201812'

MONTH = relativedelta(months=+1)

fmt = '%Y%m'
date_1 = dt.datetime.strptime(yyyymm_1, fmt).date()
date_2 = dt.datetime.strptime(yyyymm_2, fmt).date()

yyyymm = []
while date_1 <= date_2:
    yyyymm.append(date_1.strftime('%Y')+date_1.strftime('%m'))
    date_1 += MONTH
```

### 리스트 하나로 만들기

```python
"".join(aaa)
```

### 특수문자 제거

```python
content = [x.strip() for x in content]
# space로 구분되있는거 배열로 만들기
content = [x.split(' ') for x in content]
```

### print 시 공백없이 출력하는 방법

- sep='' 를 뒤에 추가해주면 됨

```python
for x in content:
    print("test",x[0],"'ㅇㅇ'", x[1], sep='')
```

### 문자열 합치기

```python
output = []
for x in content:
    temp = "data.find_all('"+x[0]+"')[0]      #"+x[1]
    output.append(temp)
```

### for문에서 key, value 값으로 나누기

- enumerate를 사용하면 됨

```python
for k, v in enumerate(output):
    print(k, v)
```

# 