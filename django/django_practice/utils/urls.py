from django.urls import path
from . import views

urlpatterns = [
    path('', views.index),
    path('arti/<str:keyword>/', views.arti),
    path('stock/', views.stock),
    path('stock_input/', views.stock_input),
    path('stock_output/', views.stock_output),
]
