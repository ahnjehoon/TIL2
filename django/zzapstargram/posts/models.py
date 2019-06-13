from django.db import models
from imagekit.models import ProcessedImageField
from imagekit.processors import ResizeToFill


# Create your models here.
class Post(models.Model):
	content = models.TextField()
	# image = models.ImageField(blank=True)
	# Django Imagekit
	image = ProcessedImageField(upload_to='posts/images',
								processors= [ResizeToFill(300, 200)],
								format='JPEG',
								options={'quality': 90})
