from django.urls import path
from . import views as views
urlpatterns = [
    path('', views.index),
    path('contact/<str:request_param>/', views.contact),
    path('help_me/', views.help_me)
]