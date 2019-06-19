from django.shortcuts import render, redirect
from .models import Post
from .forms import *
from django.contrib.auth.decorators import login_required
from itertools import chain


# Create your views here.
def index(request):
	# posts = Post.objects.all().order_by('-id')
	user = request.user
	if user.is_authenticated:
		user_follow = user.follow.all()
		follow_list = chain(user_follow, [request.user])
		posts = Post.objects.order_by('-id').filter(user__in=follow_list)
	else:
		posts = Post.objects.all().order_by('-id')
	return render(request, 'posts/index.html', {
		'posts': posts
		, 'comment_form': CommentForm()
	})


def all(request):
	posts = Post.objects.all().order_by('-id')
	return render(request, 'posts/index.html', {
		'posts': posts
		, 'comment_form': CommentForm()
	})


def detail(request, post_id):
	return render(request, 'posts/detail.html', {
		'post': Post.objects.get(id=post_id)
	})


@login_required
def create(request):
	# 1. GET 방식으로 데이터를 입력할 수 있는 form 요청
	# 4. 사용자가 데이터를 입력해서 post 요청을 보냄
	# 9. 사용자가 적절한 데이터를 입력해서 post요청을 보낸다.
	if request.method == "GET":
		# 2. PostForm을 인스턴스화 해서 form 변수에 저장
		form = PostForm()
	else:
		# 5. post방식으로 저장요청을 받고, 데이터를 받아서 PostForm을 인스턴스화 함
		# 10. 데이터를 받아서 postform을 인스턴스화 한다.
		form = PostForm(request.POST, request.FILES)
		# 6. 데이터 검증을 함
		# 11. 데이터 검증을 한다
		if form.is_valid():
			# 12. valid 하면 저장
			post = form.save(commit=False)
			post.user = request.user
			post.save()
			return redirect('posts:index')
		else:
			# 7. 적절하지 않은 데이터가 들어옴
			pass
	# 3. 만들어진 form을 create.html에 담아서 전송
	# 8. 사용자가 정확하게 입력한 데이터를 유지한 상태의 form을 전송
	return render(request, 'posts/form.html', {
		'form': form
	})


@login_required
def update(request, post_id):
	post = Post.objects.get(id=post_id)
	if request.user == post.user or request.user.username == 'admin':
		# 내가 작성한 글일 때
		if request.method == "GET":
			form = PostForm(instance=post)
		else:
			form = PostForm(request.POST, request.FILES, instance=post)
			if form.is_valid():
				form.save()
				return redirect('posts:index')
		return render(request, 'posts/form.html', {
			'form': form
		})
	else:
		# 내가 작성하지 않은 글일 때
		return redirect('posts:index')


@login_required
def delete(request, post_id):
	post = Post.objects.get(id=post_id)
	post.delete()
	return redirect('posts:index')


# 댓글다는곳
@login_required
def comment_create(request, post_id):
	post = Post.objects.get(id=post_id)
	if request.method == 'POST':
		comment_form = CommentForm(request.POST)
		if comment_form.is_valid():
			comment = comment_form.save(commit=False)
			comment.post = post
			comment.user = request.user
			comment.save()
		return redirect('posts:index')
	return render(request, 'posts/index.html', {
		'comment_form': CommentForm()
	})


def comment_update(request, post_id):
	return


def comment_delete(request, post_id):
	return


@login_required
def likes(request, post_id):
	user = request.user
	post = Post.objects.get(id=post_id)

	# 이미 좋아요가 눌러졌으면
	if user in post.like_users.all():
		# 좋아요 취소
		post.like_users.remove(user)
	# 좋아요 안했으면
	else:
		# 좋아요
		post.like_users.add(user)
	return redirect('posts:index')
