from django.shortcuts import render
import art
# Create your views here.
def index(request):
    title = 'index'
    return render(request,
                  'utils/index.html',
                  {
                      'title': title
                  })

def arti(request, keyword):
    title = 'arti'
    result = art.text2art(keyword, font='random')
    return render(request,
                  'utils/art.html',
                  {
                      'title': title,
                      'keyword': keyword,
                      'result': result,
                  })

def stock(request):
    pass  # TODO 해야된다
    title = 'stock'
    return render(request,
                  'utils/stock.html',
                  {
                      'title': title
                  })