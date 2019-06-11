# ORM

- Object Relation Mapper
- Django model(객체)을 DB table로 변환시켜 조작하게 해줌(SQL없이도 DB를 조작할 수있음)
- DBMS에 상관없이 사용 가능하고 객체지향의 관점에서 DB를 설계할 수 있음
- 단, 기계가 작성하는 것이기때문에 반드시 효율적인 SQL로 변환되는 것은 아님

## CREATE

```python
class Post(models.Model):
    title = models.CharField(max_length=100)
    content = models.TextField()
    like = models.IntegerField(default=0)
    created_at = models.DateTimeField(auto_now_add=True)


class Comment(models.Model):
    post = ForeignKey(Post, on_delete=models.CASCADE)
    content = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
```

## READ

```python
[모델 클래스].objects.all() # Post 테이블을 모두 호출, 쿼리셋을 반환

[모델 클래스].objects.get(id=1) # id값이 1인 Post 오브젝트를 반환

Comment.objects.filter(post=post) # id가 1인 Post에 달린 댓글들의 쿼리셋을 반환

Comment.objects.filter(post=post).order_by('-created_at') # 생성 시점으로 정렬
```

## UPDATE

## DELETE



1 models.py 기본값 세팅

2 models.py 



## 출처(아직 참고안한곳도 있음)

- <https://lee-seul.github.io/django/2017/08/26/Django-ORM.html>
- <https://2siwon.github.io/django/2017/10/11/django-007-Relations-tip.html>
- [http://recordingbetter.com/django/2017/06/01/Django-%EC%88%98%EC%97%85](http://recordingbetter.com/django/2017/06/01/Django-수업)