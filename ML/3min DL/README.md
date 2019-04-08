# 골빈해커의 3분 딥러닝 텐서플로맛

- 책을 마친 후 추가 공부 자료들

  - 모두를 위한 머신러닝/딥러닝(<https://hunkim.github.io/ml/>)

    홍콩과기대 김성훈 교수님 강좌. 한국어뿐만아니라 영어강좌까지 통틀어 쉽게 설명한 강좌

  - 한양대 이상화교수님의 선형대수학 강의(<http://www.kocw.net/home/search/kemView.do?kemId=977757>)

    딥러닝을 깊게 공부하기 위한 선형대수학을 짜임새 있게 설명한 강좌

  - 앤드류 응 교수님의 머신러닝 강의(<https://www.coursera.org/learn/machine-learning>)

    머신러닝의 기초 강좌. 가장유명하고 한글자막있어서 영어 못해도됨

  - 제프리 힌튼 교수님의 딥러닝 강의도 있는데 이건 코세라에서 짤린듯..

  - 신경망 첫걸음(한빛미디어, 2017)

  - 밑바닥부터 시작하는 딥러닝

    이 책 다읽으면 시작할 책

  - 마스터 알고리즘(비지니스북스, 2016)

    주요 머신러닝 알고리즘의 기초 개념을 전문지식없이도 쉽게 

  - 파이썬 라이브러리를 활용한 머신러닝(한빛미디어, 2017)

----------------------------

## Anaconda, Jupyter notebook 기반으로 작성함

##### 일반적인 사용자

```python
pip install --upgrade tensorflow
```

##### NVIDIA GPU를 사용하는 사용자

1. 먼저 <https://developer.nvidia.com/cuda-downloads> CUDA 툴킷깔고

2. 텐서플로 설치(아마 CUDA하고 텐서플로하고 버전 맞춰야 할듯)

   ```python
   pip install --upgrade tensoflow-gpu
   ```

##### 라이브러리 설치

아마 Anaconda에 기본적으로 내장되어 있을것임

```python
pip install numpy matplotlib pillow
```

1. numpy - 수치계산 라이브러리
2. matplotlib - 그래프 출력 라이브러리
3. pillow - 이미지 출력 라이브러리

----------------------------

## 복잡한 계산시
- 구글이 제공하는Cloud ML에 올려서 활용



