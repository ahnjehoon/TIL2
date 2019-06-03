from django.contrib import admin
from django.urls import path, include
from . import views
from home import views as home_views

urlpatterns = [
    path('admin/', admin.site.urls),
    # path('', views.index),
    # path('hello/<str:name>/', views.hello),
    # 홈
    # url에 include를 추가시켜주면!
    # path('home/', home_views.index),
    # path('home/contact/<str:request_param>', home_views.contact),
    # path('home/help_me', home_views.help_me)
    # 위에꺼 안쓰고 아래것처럼
    # 고럼 이게 이제 home.urls로 가게된다
    path('home/', include('home.urls')),
    path('utils/', include('utils.urls')),
]
