from django.shortcuts import render, HttpResponse

def index(request):
    return render(request, 'index.html')
    # return HttpResponse('훠훠훠')

def hello(request, name):
    greeting = f'Hello {name}'
    # return HttpResponse(greeting)
    return render(request, 'hello.html', {'greeting': greeting})