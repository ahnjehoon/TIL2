from django.shortcuts import render, redirect
from .models import Board


# Create your views here.
def index(request):
	boards = Board.objects.all()
	return render(request, 'board/index.html', {
		'title': '인덱스 페이지',
		'boards': boards,
	})


def detail(request, board_id):
	board = Board.objects.get(id=board_id)
	return render(request, 'board/detail.html', {
		'title': '디테일 페이지',
		'board': board
	})


def create(request):
	if request.method == "GET":
		return render(request, 'board/form.html', {
			'title': '입력폼',
		})
	else:
		board = Board()
		board.title = request.POST.get('title')
		board.content = request.POST.get('content')
		board.save()
		return redirect('/board/')


def update(request, board_id):
	board = Board.objects.get(id=board_id)
	if request.method == "GET":
		return render(request, 'board/form.html', {
			'title': '수정폼',
			'board': board
		})
	else:
		board.title = request.POST.get('title')
		board.content = request.POST.get('content')
		board.save()
		return redirect('/board/')


def delete(reqeust, board_id):
	Board.objects.get(id=board_id).delete()
	return redirect('/board/')
