from django.urls import path
from . import views

app_name = "articles"

urlpatterns = [
	path('', views.index, name="index"),

	# article
	path('<int:article_id>/', views.detail, name="detail"),
	# path('create_form/', views.create_form, name="create_form"),
	path('create/', views.create, name="create"),
	# path('<int:article_id>/update_form/', views.update_form, name="update_form"),
	path('<int:article_id>/update/', views.update, name="update"),
	path('<int:article_id>/delete/', views.delete, name="delete"),

	# comment
	path('<int:article_id>/comments/create/', views.create_comment, name='create_comment'),
	path('<int:article_id>/comments/<int:comment_id>/delete/', views.delete_comment, name='delete_comment'),

	path('get_comments/', views.get_comments, name="get_comments")
]
