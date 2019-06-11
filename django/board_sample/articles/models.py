from django.db import models
from django.conf import settings
# setting.AUTH_USER.Model


# Create your models here.
class Article(models.Model):
	title = models.CharField(max_length=100)
	content = models.TextField()
	user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)


# CASCADE : 폭포
# on_delete : CASCADE 게시물이 삭제되면 폭포처럼 댓글도 다 지워버린다.
class Comment(models.Model):
	content = models.TextField()  # 댓글
	article = models.ForeignKey(Article, on_delete=models.CASCADE)  # Article Class Foreign Key
	user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
