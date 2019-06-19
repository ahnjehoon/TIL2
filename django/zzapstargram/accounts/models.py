from django.db import models
from django.contrib.auth.models import AbstractUser
from django.conf import settings
from imagekit.models import ProcessedImageField
from imagekit.processors import ResizeToFill


# Create your models here.
class User(AbstractUser, models.Model):
	# 클래스가 완성되지 않은 상태에서 User클래스를 만드려면 오류가 뜸
	# 그래서 꼼수로 settings.AUTH_USER_MODEL 쓰면 됨
	follow = models.ManyToManyField(settings.AUTH_USER_MODEL, related_name="follower")
	introduce = models.TextField(blank=True)
	image = ProcessedImageField(upload_to='posts/images',
	                            processors=[ResizeToFill(300, 200)],
	                            format='JPEG',
	                            options={'quality': 90},
	                            blank=True)
