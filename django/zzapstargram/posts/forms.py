from django import forms
from .models import *


class PostForm(forms.ModelForm):
	class Meta:
		model = Post
		# fields = '__all__'
		fields = ['content', 'image']

class CommentForm(forms.ModelForm):
	class Meta:
		model = Comment
		# fields = '__all__'
		fields = ['content']