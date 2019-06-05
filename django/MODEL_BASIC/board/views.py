from django.shortcuts import render, redirect
from .models import Article


# Create your views here.
def index(request):
    return render(request,
                  'board/index.html'
                  )


# 전체 article 조회하기
def article_list(request):
    title = '리스트'
    articles = Article.objects.all()
    return render(request,
                  'board/article_list.html',
                  {
                      'title': title,
                      'articles': articles,
                  })


# 특정 article 조회하기
def article_detail(request, article_id):
    article = Article.objects.get(id=article_id)
    return render(request,
                  'board/article_detail.html',
                  {
                      'article': article
                  })


def article_new(request):
    title = '입력폼'
    return render(request,
                  'board/article_new.html',
                  {
                      'title': title
                  })


def article_create_process(request):
    # request.POST['title'] 이것도 되긴하는데 값없으면 뻑남
    title = request.POST.get('title')
    content = request.POST.get('content')
    article = Article()
    article.title = title
    article.content = content
    article.save()
    # return redirect('/board/')
    return redirect(f'/board/{article.id}')


# UPDATE
def article_edit(request, article_id):
    article = Article.objects.get(id=article_id)
    title = article.title + ' 수정'
    return render(request,
                  'board/article_edit.html',
                  {
                      'title': title,
                      'article': article,
                  })

def article_update(request):
    article = Article.objects.get(id=request.POST.get('id'))
    article.title = request.POST.get('title')
    article.content = request.POST.get('content')
    article.save()
    return redirect(f'/board/{article.id}')


# DELETE
def article_delete(request, article_id):
    article = Article.objects.get(id=article_id)
    article.delete()
    return redirect(f'/board/')