from django.shortcuts import render, HttpResponse


# Create your views here.
def index(request):
    # return HttpResponse('훠후허ㅝ')
    title = '인덱스 타이틀'
    return render(request,
                  'home/index.html',
                  {
                      'title': title,
                      'content': '깔깔깔'
                      ,
                  }
                  )


def contact(request, request_param):
    title = '컨텍트 타이틀'
    return render(request,
                  'home/contact.html',
                  {
                      'title': title,
                      'content': 'contact.html 입니다',
                      'request_param': request_param
                  }
                  )


def help_me(reqeust):
    title = '헬프미 타이틀'
    return render(reqeust, 'home/help_me.html')
