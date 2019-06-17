from django.urls import path
from . import views


app_name = 'posts'
urlpatterns = [
	path('', views.index, name="index")
	, path('<int:post_id>/', views.detail, name="detail")
	, path('create/', views.create, name="create")
	, path('<int:post_id>/update/', views.update, name="update")
	, path('<int:post_id>/delete/', views.delete, name="delete")
	# 댓글 작성
	, path('<int:post_id>/comment/create/', views.comment_create, name="comment_create")
	, path('<int:post_id>/comment/update/', views.comment_update, name="comment_update")
	, path('<int:post_id>/comment/delete/', views.comment_delete, name="comment_delete")
	# 좋아요
	, path('<int:post_id>/likes/', views.likes, name="likes")
]

