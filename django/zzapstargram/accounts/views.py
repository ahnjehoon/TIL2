from django.shortcuts import render, redirect
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth import login as auth_login, logout as auth_logout


# Create your views here.
def signup(request):
	if request.method == "GET":
		form = UserCreationForm()
	else:
		form = UserCreationForm(request.POST)
		if form.is_valid():
			form.save()
			return redirect('posts:index')
	return render(request, 'accounts/signup.html', {
		'form': form
	})


def login(request):
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
