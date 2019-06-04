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


# 사용자 입력 form 을 제공하는 액션
def stock_input(request):
    title = '데이터 입력창'
    return render(request,
                  'utils/stock_input.html',
                  {
                      'title':title
                  })


# 입력받은 data를 처리하여 결과를 제공하는 액션
def stock_output(request):
    from iexfinance.stocks import Stock

    company_code = request.GET.get('company_code')
    TOKEN = 'pk_34947d6f20564c52a9dcd62bf4d4ab5f'

    try:
        stock = Stock(company_code, token=TOKEN)
        data = stock.get_quote()
    except:
        return render(request, 'utils/stock_output.html', {
            'title': company_code,
            'is_ok': False,
            'message': '검색할 수 없습니다.'
        })
    return render(request,
                  'utils/stock_output.html',
                  {
                      'title': company_code,
                      'is_ok': True,
                      'data': data
                  })
