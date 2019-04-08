### R 기본 데이터 구조

- 벡터(Vector)
  - 1차원 선형 자료구조
  - 벡터 생성 함수: c(), seq(), rep()
  - 동일한 자료형으로만 저장가능
  - c(1:20): 1부터 20까지 데이터 생성
  - seq(1, 10, 2):  1부터 20까지 2씩 증가하면서 데이터 생성
  - req(1:3, 3): 1부터 3까지 3번 반복해서 데이터 생성
- 행렬(Martix)
  - 행과 열로 구성된 2차원 배열 구조
  - 동일한 자료형으로만 저장
  - 행렬 생성 함수: rbind, cbind, matrix
  - df3 <- rbind(df1, df2): df1, df2를 합쳐서 df3 생성. 행결합
  - df3 <- cbind(df1, df2): df1, df2를 합쳐서 df3 생성. 열결합
- 리스트(List)
  - 성격이 다른 자료구조로 벡터, 행렬, 리스트, 데이터 프레임 등을 객체로 생성
  - 리스트 생성 함수: list()
  - 리스트 자료처리 함수:inlist(), lapply(), sapply()
- 데이터 프레임(Data Frame)
  - 가장 많이 쓰이는 데이터 구조
  - 리스트 자료보다 데이터 처리에 효과적
  - 컬럼 단위로 서로 다른 데이터의 저장 기능
  - 데이터 프레임 생성 함수: data.frame(), read.table(), read.csv()
  - 데이터 프레임 자료 처리 함수: str(), summary(), View()

---

### 라이브러리 설치, 삭제, 불러오기

- 라이브러리(패키지) 설치
  install.packages('패키지명')
- 라이브러리(패키지) 삭제
  remove.packages('패키지명')
- 다수의 라이브러리(패키지)를 한꺼번에 불러오기: pacman 패키지 이용
  install.packages('pacman')
  library(pacman)
  pacman ::p_load('패키지1', '패키지2', ...)

---

### 기본 함수

- library(): 설치된 패키지 확인
- data(): 내장된 데이터 프레임 확인
- head('df명'): 데이터 프레임의 처음 6개 확인
- tail('df명'): 데이터 프레임의 마지막 6개 확인
- View('df명'): 뷰어에서 데이터 프레임 보기
- dim('df명'): 데이터 차원 출력
- str('df명'): 데이터의 구조 및 속성 출력
- summary('df명'): 기술통계량(요약) 출력

---

### 외부 데이터 파일 불러오기

###### 엑셀파일 불러오기

```R
install.packages("readxl")	#엑셀파일 불러오는 패키지 설치
library(readxl)				#패키지 로딩
변수명 <- read_excel(path="경로/파일명.xlsx",sheet="시트명",col_names=TRUE)
```

###### CSV 파일 불러오기

```R
변수명 <- read.table("파일경로 및 파일명.csv", header=TRUE,sep=",")
변수명 <- read.csv("파일명.csv")
```

###### SPSS 파일 불러오기

```r
install.pacages("foreign")
library(foreign)
변수명 <- read.spss("경로/파일명.sav")
```

###### 텍스트 파일 불러오기

```R
변수명 <- read.table("파일경로/파일명.txt",header=FALSE)
```

---

### 데이터 저장 및 불러오기

```R
save(DataFrame명, file="저장할 파일명.rda")
load("읽을 파일명.rda")
```

---

### 대용량 데이터 빠르게 불러오기 data.table 패키지

```R
library(data.table)
변수명 <- fread('경로명/파일명')
```

---

#### 데이터 프레임의 변수명 바꾸기

```R
install.packages('dplyr')
library(dplyr)
df_new <- rename(df_old, 새로운변수명=이전변수명)
```

#### 필요한 변수열 추출

```R
df <- iris
df %>% select(Sepal.Length, Sepal.Width)
df %>% select(-Sepal.Length, -Sepal.Width)
```

#### 추출한 변수열 다른 데이터 프레임으로 저장

```R
df <- iris
df2 <- df %>% select(-Sepal.Length, -Sepal.Width)
```

#### 파생변수 추가

```R
df <- iris
df %>% mutate(total = Sepal.Length + Sepal.Width + Petal.Length + Petal.Width) %>% head
```

#### 결측치 찾기

- is.na(df): 결측치는 TRUE, 아니면 FALSE
- table(is.na(df)): 결측치를 테이블 형태로 출력해서 몇개가 있는지 파악
- table(is.na(df$col1)): col1 열에 있는 결측치가 몇개인지 출력

#### 결측치 제거

- is.na()함수에 filter()를 적용하면 결측치가 있는 행을 제거
- filter 함수를 쓰기 위해 dplyr 패키지 호출

```R
df %>% filter(is.na(col1))	 				# 결측치가 있는 행만 추출
df %>% filter(!is.na(col1))	 				# 결측치가 없는 행만 추출
df %>% filter(!is.na(col1) & !is.na(col2))	# 결측치가 없는 행만 추출
```

#### 결측치 평균값으로 대체

- na.rm(): 결측치가 있어도 평균을 정상적으로 출력
  ex) mean(df$col1, na.rm=T)
- summary() 함수를 이용해서 평균값을 도출해도 무방
- df$col<- ifelse(is.na(df$col), 임의값, df$col)
  결측치면 임의값으로 아니면 원래값 그대로 넣는다는 뜻

#### 데이터 분포 특성 확인

- summary(df): 기본 통계량 확인

#### 선형회귀식

- lm(종속변수 ~ 독립변수들)
  reg <- lm(df$Species ~ df$Sepal.Length + df$Sepal.Width + df$Petal.Length + df$Petal.Width)
- 선형회귀분석결과 통계량 산출
  summary(reg)

#### 독립변수별 상관관계 그래프 작성

```R
library(MASS)
df2 <- df[,c('x1','x2','x3','x4','x5')]
cor(df2)
plot(df2, main='CV 독립변수별 상관관계')
```

