# Django
## 처음 생성
1. 장고 폴더 생성

2. 장고 인스톨

   pip install  django
   
3. 장고 폴더로 이동

    cd [생성한 장고 폴더명]
    
4. 장고 프로젝트 생성

    django-admin startproject [프로젝트명]




## 장고 앱 생성

- django-admin startapp [앱이름]

- 프로젝트 매니저에 앱 등록

  settings.py 내부 INSTALLED_APPS에 [앱이름] 추가

- 프로젝트 매니저에 URL 처리 등록

  urls.py 내부 urlpatterns에

  ```python
  from django.urls import include
  ```

  추가 후

  ```python
  path('[앱이름]/', include('[앱이름].urls'))
  ```

  등록
  
- 실행

  python manage.py runserver



## 프로젝트 폴더

### settings.py

- INSTALLED_APPS

  장고 패키지들

- ROOT_URLCONF

  메인 URL 바인딩? 표시

- WSGI_APPLICATION

  웹서버 게이트웨이 인터페이스

- LANGUAGE_CODE

  'ko-kr'로 변경

- TIME_ZONE

  'Asia/Seoul




## app폴더 template 안에 또다시 app폴더를 넣는 이유

- 장고 시작시 각 app에 분산되어있는 template를 합쳐서 실행함

- 장고 공식 문서에서도 이렇게 하라고 권장되어 있다고 함

- 설치된 앱들의 template를 뒤져서 기본 디렉토리를 설정 안해도 되지만 루트에 박을경우

  TEMPLATES의 DIRS에 os.path.join(BASE_DIR, 'templates') 이거 추가해줘야됨



## DTL

- Django Template Language



## 데이터 보내고 받을 때

### GET

- method="get"
- 서버에서 받을 때는 request.GET['변수명'] 또는 request.GET.get('변수명')

### POST

- method="POST"
- 서버에서 받을 때는 request.POST['변수명'] 또는 request.POST.get('변수명')
- form태그 안에 `{% csrf_token %}` 추가해야 됨



## Django extensions

- pip install django_extenstions
- settings.py > INSTALLED_APPS > django_extensions 추가
- pip install jupyter notebook?이였던가 (명령어 확인 필요) 쥬피터 노트북 확인 가능



### django extentions

- layout 가져갈 곳에다가

  `{% block [변수명] %}{% endblcok %}`

  layout을 사용할 곳에서는

  `{% extends '[앱이름]/[파일이름]' %}`



## CRUD Basic

### CRUD Operation

- Create => 데이터 생성
- Read
- Update
- Delete

### Example Article Table

| Field Name | Data type                 |
| ---------- | ------------------------- |
| id         | Integer, Primary Key      |
| title      | CharField(max_length=200) |
| content    | TextField()               |

#### Create (데이터 생성)

1. `Article` 객체를 생성한다
2. 필드를 채운다
3. 저장한다

- 넣는 방법 1

```python
article = Article()
article.title = 'TEST1'
article.content = 'This is test article1'
article.save()
```

- 넣는 방법 2

```python
article = Article(title="TEST2", content="This is test article2")
article.save()
```

- 넣는 방법 3

```python
(Article.objects).create(title="TEST3", content="This is test article3")
```





#### Read (데이터 조회)

- 좀 이쁘게 출력해 주고 싶다면 클래스안에 `__str__`을 정의해준다

  ```python
  # 예시
  def __str__(self):
      return f'{self.id}:{self.title} | {self.content}'
  ```

1. 여러개 조회

   - 전체 조회

     ```python
     (Article.objects).all()
     ```

   - 특정 조건을 만족하는 레코드들 조회
2. 정확히 한개 조회

   - id(pk)로 조회

     ```python
     (Article.objects).get(id=1)
     ```

   - 특정 조건을 만족하는 첫 번째 레코드 조회

#### Update (데이터 수정)

1. Article 객체를 하나 고른다
2. 필드를 알맞게 수정한다
3. 저장한다

```python
print(Article.objects.get(id=1))
# 1:6pm | Time to go home

article = Article.objects.get(id=1)
article.title = '6pm'
article.content = "Time to go home"
article.save()

print(Article.objects.get(id=1))
# 1:6pm | Time to go home
```

#### Delete (데이터 삭제)

1. Article 객체를 하나 고른다
2. 삭제한다

```python
# 처음 상태
(Article.objects).all()
# <QuerySet [<Article: 1:TEST1 | This is test article>, <Article: 2:TEST2 | This is test article>, <Article: 3:TEST3 | This is test article>]>
```

```python
# 3을 삭제 해봄
article = Article.objects.get(id=3)
# 전체삭제 할때는 아래 코드로
# (Article.objects).all().delete()
article.delete()
```

```python
# 결과물
(Article.objects).all()
# <QuerySet [<Article: 1:TEST1 | This is test article>, <Article: 2:TEST2 | This is test article>]>
```



## ORM

### 생성방법

- python manage.py makemigrations [앱이름]

  결제서류 만들기
- python manage.py migrate [앱이름]

  결제 하기

### 간단 테스트

- python manage.py shell_plus

  python manage.py shell_plus --notebook 치면 노트북나옴

```python
from [앱이름].models  import [클래스이름]
[클래스이름].objects.first()			# 첫 번째 행 조회
[변수명] = [클래스이름]()			# 새롭게 인스턴스 생성
[변수명].[DB요소] = [값]				# DB요소에 값 대임
[변수명].save()					# DB에 값 삽입
```



## 관리자(ADMIN) 페이지

1. python manage.py makemigrations

   전체 체크

2. python manage.py migrate

   모든 숨겨진 결재를 실행

3. python manage.py createsuperuser

   절대관리자를 생성

4. [DOMAIN]/admin 에 접속

5. 로그인

### 관리자 페이지에 등록

- admin.py에 등록

  admin.site.register([클래스])



## Django 관련 팁

### URL name

- URL사용시 하나 바꾸면 여러군데 싹다 바꿔야 되는 경우가 많음

  urls.py 하나 바꾸면 엮여있는 html파일들 많이 바꿔야됨

- urls.py

  ```python
  app_name = "[앱이름(꼭 앱이름 아니여도됨)]"
  urlpatterns = [
      path("[경로]", views[함수명], name="[이 경로를 어떤것으로 부를건지]")
  ]
  ```

- sample.html

  ```html
  <form action="url '{% 앱이름:지정했던 name %}'">
      ... 코드 들어갈 자리
  </form>
  ```




### 내용 + 파일을 넘겨주고 싶을 때

- form 에다 enctype="multipart/"
- views.py에



### 강제로 에러 발생시키고 싶을 때

- raise()



## Forms

- 추후 작업



## ETC

### TODO

```
# TODO 할일
```

하면 보임



### PYCHARM 단축키

#### html 기본 폼 만들때

- `! + TAB`

#### 정렬

- `CTRL + SHIFT + ALT + L`



### 샘플 이미지 랜덤하게 뽑아주는곳

- https://picsum.photos/1024/150



### 127.0.0.1 / localhost

- 서로 도메인이 다르면 쿠키에 저장된게 다르기 때문에 맞춰야함





## 좋은 참고 자료

- <https://wikidocs.net/book/837>