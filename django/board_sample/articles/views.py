from django.shortcuts import render, redirect
from .models import Article


# Create your views here.
def index(request):
	return render(request, 'articles/index.html', {
		'title': '인덱스입니다',
		'articles': Article.objects.all(),
	})


def detail(request, article_id):
	article = Article.objects.get(id=article_id)
	return render(request, 'articles/detail.html', {
		'title': '디테일 페이지 입니다',
		'article': article,
	})


def create_form(request):
	return render(request, 'articles/create_form.html')


def create(request):
	title = request.POST.get('title')
	content = request.POST.get('content')

	article = Article()
	article.title = title
	article.content = content
	article.save()

	return redirect('articles:index')


def update_form(request, article_id):
	article = Article.objects.get(id=article_id)
	return render(request, 'articles/update_form.html', {
		'title': '업데이트폼',
		'article': article,
	})


def update(request):
	article = Article.objects.get(id=request.POST.get('id'))
	article.title = request.POST.get('title')
	article.content = request.POST.get('content')
	article.save()
	return redirect('/articles/')


def delete(request, article_id):
	Article.objects.get(id=article_id).delete()
	return redirect('articles:index')
