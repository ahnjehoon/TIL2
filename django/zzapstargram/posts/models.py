from django.db import models
from imagekit.models import ProcessedImageField
from imagekit.processors import ResizeToFill
from django.conf import settings


# Create your models here.
class HashTag(models.Model):
	content = models.CharField(max_length=50, unique=True)

	def __str__(self):
		return self.content

class Post(models.Model):
	# related_name
	# 유저모델과 포스트모델을 연결시키려함
	# 근데 아래에 똑같은 settings.AUTH_USER_MODEL 모델을 사용헀음
	# 그래서 다르게 해주기 위해 related_name을 지정해서 충돌 방지
	like_users = models.ManyToManyField(settings.AUTH_USER_MODEL, related_name="like_posts")
	user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
	content = models.TextField()
	# image = models.ImageField(blank=True)
	# Django Imagekit
	image = ProcessedImageField(upload_to='posts/images',
	                            processors=[ResizeToFill(300, 200)],
	                            format='JPEG',
	                            options={'quality': 90})
	hash_tags = models.ManyToManyField(HashTag, blank=True)


class Comment(models.Model):
	user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
	post = models.ForeignKey(Post, on_delete=models.CASCADE)
	content = models.CharField(max_length=100)
