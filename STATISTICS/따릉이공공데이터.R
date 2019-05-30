setwd('C:/Users/PC/Downloads/')
# https://www.java.com/en/download/manual.jsp
# ctrl + l #콘솔 초기화
# rm(list=ls()) #변수 초기화

install.packages("xlsx")
install.packages("ggplot2")
install.packages("dplyr")
install.packages("stringr")
library(xlsx)
library(ggplot2)
library(dplyr)
library(stringr)

# 파일 다운로드 관련
# 서울특별시 공공자전거 대여소 정보(4번째)
# https://data.seoul.go.kr/dataList/datasetView.do?infId=OA-13252&srvType=S&serviceKind=1&currentPageNo=1
# 공공자건거 이용현황(7번째)
# https://data.seoul.go.kr/dataList/datasetView.do?infId=OA-14994&srvType=S&serviceKind=1&currentPageNo=1
# 서울특별시 공공자전거 대여소별 이용정보(월별) 전부
# https://data.seoul.go.kr/dataList/datasetView.do?infId=OA-15249&srvType=F&serviceKind=1&currentPageNo=1

## 데이터 로딩 ##
bike_170112 <- read.csv("서울특별시 공공자전거 대여소별 이용정보(월간)_2017_1_12.csv", header = F, stringsAsFactors = F, skip = 1)
bike_180106 <- read.csv("서울특별시 공공자전거 대여소별 이용정보(월간)_2018_1_6.csv", header = F, stringsAsFactors = F, skip = 1)
bike_180711 <- read.xlsx2("대여소별 대여정보_201807_11.xlsx", sheetIndex = 1, stringsAsFactors = F, header = F, colClasses = NA, startRow = 2)
bike_info <- read.csv("서울시 공공자전거 대여소 정보_20181129.csv", header = T, stringsAsFactors = F)

## 데이터 탐색 ##
str(bike_170112)
str(bike_180106)
str(bike_180711)
str(bike_info)

## 데이터 전처리, 사용자 함수 및 기본 함수 활용 ##
## 데이터 전처리용 사용자 함수 만들기 ##
cleansing <- function(a) {
  as.data.frame(lapply(a, function(x) {
    temp <- gsub("^'(\\s)?", "", x)
    temp2 <- gsub("'(\\s)?$", "", temp)
    temp3 <- gsub("[0-9]+\\.(\\s)?", "", temp2)
    sapply(temp3, function(x)
      ifelse(is.na(tryCatch(
        as.numeric(x),
        error = function(e)
          NA
      )),
      x, as.numeric(x)))
  }), stringsAsFactors = F)
}


## 사용자 함수 적용 및 기타 데이터 전처리 수행 ##
bike_17 <- cleansing(bike_170112)
bike_18_1 <- cleansing(bike_180106)
bike_18_2 <- cleansing(bike_180711)
bike_info_temp <- cleansing(bike_info)
bike_17_temp <- bike_17[-grep(pattern = "[가-힣]",x = bike_17$V2), ]
bike_17_temp$V2 = as.numeric(bike_17_temp$V2)
bike_18_1_temp <- bike_18_1[-grep(pattern = "[가-힣]",x = bike_18_1$V2), ]
bike_18_1_temp$V2 = as.numeric(bike_18_1_temp$V2)
colnames(bike_18_2) <- colnames(bike_17_temp)
bike_data <- rbind(bike_17_temp, bike_18_1_temp, bike_18_2)

## 데이터 변수명 변경 ##
colnames(bike_data) <- c("ym", "office_num", "office_add", "borrow", "return")
colnames(bike_info_temp) <-c("no", "office_dis", "office_id", "office_num", "office_add", "holder", "lat", "lon")
## 데이터 합치기(merge) ##
bike_data2 <- merge(x = bike_data[, c("ym", "office_num","office_add", "borrow", "return")], y = bike_info_temp[, c("office_dis", "office_num", "holder", "lat", "lon")], by = "office_num")
## 연도와 월이 합쳐진 데이터에서 연도, 월 데이터 분리 ##
bike_data2$year <- substr(bike_data2$ym, 1, 4)
bike_data2$month <- substr(bike_data2$ym, 5, 6)
bike_data3 <- bike_data2[c(10,11, 1, 6, 3, 4, 5, 7, 8, 9)] ## 변수 정렬


#### 데이터 집계 및 요약 ##
## 연도별 자전거 대여 합계 ##
bike_data3 %>% group_by(year) %>% summarise(sum(borrow))
ggplot(aes(x = year, y = borrow, fill = year), data = bike_data3) +
  geom_bar(stat = "identity")
## 월별 자전거 대여 합계 ##
bike_data3 %>% group_by(month) %>% summarise(sum(borrow))
ggplot(aes(x = month, y = borrow, fill = month), data = bike_data3) +
  geom_bar(stat = "identity")

# 14

## 구별, 연도별 대여 합계/평균 ##
bike_data3 %>% group_by(office_dis, year) %>% summarise(sum_borrow =
                                                          sum(borrow), sum_return = sum(return))
bike_data3 %>% group_by(office_dis, year) %>% summarise(mean_borrow =
                                                          mean(borrow), mean_return = mean(return))
### 2018년, 가장 대여가 높은 구 5곳을 찾은 뒤, 월별 추세선 그리기 ###
bike_dis <- bike_data3 %>% subset(year == 2018) %>%
  group_by(office_dis) %>% summarise(sum = sum(borrow)) %>%
  select(office_dis)


# 15

bike_dis2 <- bike_data3 %>% filter(office_dis %in% bike_dis[1:5, , drop = T]) %>% group_by(office_dis, month) %>% summarise(sum = sum(borrow))

ggplot(aes(x = month, y = sum, group = office_dis), data = bike_dis2) +
  geom_line(aes(color = office_dis)) + geom_point(aes(color = office_dis))


# 16
## 반납되지 않은 자전거 대수 도출 ##
bike_data4 <- bike_data3 %>% group_by(office_dis) %>%
  mutate(not_returned = borrow - return)
bike_data4 %>% group_by(office_dis) %>% summarise(mean =
                                                    mean(not_returned)) %>% arrange(desc(mean))
## 반납되지 않은 자전거 수에 대해 구별로 통계적으로 유의한지 검정 ##
## 등분산 검정 ##
bartlett.test(not_returned ~ office_dis, data = bike_data4)
## 등분산을 따르지 않으므로 Welch’s anova 수행 ##
oneway.test(not_returned ~ office_dis, data = bike_data4) ## 통계적으로 유의
