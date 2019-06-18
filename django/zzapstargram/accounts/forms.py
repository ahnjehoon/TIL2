from django.contrib.auth.forms import UserCreationForm
from .models import User


class CustomUserCreationForm(UserCreationForm):
	class Meta:
		model = User
		# fields = '__all__'
		# 대괄호 소괄호 차이 없는거??
		fields = ['username', 'email']
