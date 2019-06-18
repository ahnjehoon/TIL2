from django.shortcuts import render, redirect
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth import login as auth_login, logout as auth_logout
from .forms import CustomUserCreationForm
from .models import User
from django.contrib.auth.decorators import login_required


# Create your views here.
def signup(request):
	if request.user.is_authenticated:
		return redirect('posts:index')
	if request.method == "GET":
		form = CustomUserCreationForm()
	else:
		form = CustomUserCreationForm(request.POST)
		if form.is_valid():
			user = form.save()
			auth_login(request, user)
			return redirect('posts:index')
	return render(request, 'accounts/signup.html', {
		'form': form
	})


def login(request):
	if request.user.is_authenticated:
		return redirect('posts:index')
	if request.method == "GET":
		form = AuthenticationForm()
	else:
		form = AuthenticationForm(request, request.POST)
		if form.is_valid():
			auth_login(request, form.get_user())
			return redirect('posts:index')
	return render(request, 'accounts/login.html', {
		'form': form
	})


def logout(request):
	auth_logout(request)
	return redirect('posts:index')


def user_page(request, user_id):
	user_info = User.objects.get(id=user_id)
	context = {
		'user_info': user_info
	}
	return render(request, 'accounts/user_page.html', context)

@login_required
def follow(request, user_id):
	user = request.user
	follow_user = User.objects.get(id=user_id)

	if user != follow_user:
		# 너를 팔로우 하는 사람들 목록에 내가 있으면
		if user in follow_user.follower.all():
			follow_user.follower.remove(user)
		else:
			follow_user.follower.add(user)
	# return redirect('accounts:user_page', user_id)
	return redirect('posts:index')
