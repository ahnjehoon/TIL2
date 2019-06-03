from django.urls import path
from . import views

urlpatterns = [
    path('', views.index),
    path('arti/<str:keyword>/', views.arti),
    path('stock/', views.stock),
]
