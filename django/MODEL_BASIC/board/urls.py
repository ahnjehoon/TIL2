from django.urls import path
from . import views

urlpatterns = [
    # path('', views.index),
    path('', views.article_list),
    # variable routing
    path('<int:article_id>/', views.article_detail),
    path('article_new/', views.article_new),
    path('article_create_process/', views.article_create_process),

    # UPDATE
    path('<int:article_id>/edit/', views.article_edit),
    path('update/', views.article_update),

    # DELETE
    path('<int:article_id>/delete/', views.article_delete)
]