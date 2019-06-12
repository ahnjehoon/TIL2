from django.shortcuts import render, redirect
from .models import Post
from .forms import PostForm


# Create your views here.
def index(request):
	return render(request, 'posts/index.html', {
		'posts': Post.objects.all()
	})


def detail(request, post_id):
	return render(request, 'posts/detail.html', {
		'post': Post.objects.get(id=post_id)
	})


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
		form = PostForm(request.POST)
		# 6. 데이터 검증을 함
		# 11. 데이터 검증을 한다
		if form.is_valid():
			# 12. valid 하면 저장
			form.save()
			return redirect('posts:index')
		else:
			# 7. 적절하지 않은 데이터가 들어옴
			pass
	# 3. 만들어진 form을 create.html에 담아서 전송
	# 8. 사용자가 정확하게 입력한 데이터를 유지한 상태의 form을 전송
	return render(request, 'posts/form.html', {
		'form': form
	})


def update(request, post_id):
	post = Post.objects.get(id=post_id)
	if request.method == "GET":
		form = PostForm(instance=post)
	else:
		form = PostForm(request.POST, instance=post)
		if form.is_valid():
			form.save()
			return redirect('posts:index')
		pass
	return render(request, 'posts/form.html', {
		'form': form
	})


def delete(request, post_id):
	post = Post.objects.get(id=post_id)
	post.delete()
	return redirect('posts:index')
