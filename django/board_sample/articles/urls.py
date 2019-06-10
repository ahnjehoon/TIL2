from django.urls import path
from . import views

app_name = "articles"

urlpatterns = [
	path('', views.index, name="index"),

	path('<int:article_id>/', views.detail, name="detail"),

	# path('create_form/', views.create_form, name="create_form"),
	path('create/', views.create, name="create"),

	# path('<int:article_id>/update_form/', views.update_form, name="update_form"),
	path('<int:article_id>/update/', views.update, name="update"),

	path('<int:article_id>/delete/', views.delete, name="delete"),
]
