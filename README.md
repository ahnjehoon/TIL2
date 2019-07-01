# GIT

## GIT IO? 만들기

1. 새로운 리파지토리 생성

2. [username].github.io

## GIT 초기 설정

### 설정

- 디렉토리 이동

  ```shell
  cd /c/GIT_TEST
  ```

- 첫 시작시 git config 과정 필요

  1. 계정정보 입력

     ```shell
     git config --global user.name "Jehoon_multi"
     git config --global user.email "ahnjehoon@naver.com"
     ```

  2. git init 작업 필요
     GITHub에서 클론을 받은경우 필요 없음

     ```shell
     git init
     ```

  3. git 리모트 설정
     git 리모트란 git을 원격저장소에 저장하는 앤드포인트를 의미

     ```shell
     git remote add origin https://github.com/ahnjehoon/GIT_TEST
     ```

  4. git 리모트 URL을 이용해 원격저장소에 저장된 파일을 복사해올 수 있음
     이때 git clone 명령어를 사용하여 복사 시작

     ```shell
     git clone https://github.com/ahnjehoon/GIT_TEST
     ```

### 소스 기록

- 소스를 업로드 하기 위해 git add 명령어를 이용

  ```shell
  git add .
  ```

- ignore 파일이나, 삭제한 파일 이력까지 커밋시 -f 옵션 이용

  ```shell
  git add . -f
  ```

### 소스 커밋

- 소스 커밋시 staged 상태의 파일이 히스토리로 기록되고 적재됨

- 파일 추적상태의 경우 git status 명령을 이용해서 확인

  ```shell
  git status
  ```

- Staged 상태의 파일 커밋

  ```shell
  git commit
  ```

- -m 옵션을 이용하여 커밋 메세지 작성

  ```shell
  git add *
  git commit -m "커밋 메세지"
  ```

- 커밋 실수 했을 때 덮어 씌우기 --amend 옵션

  ```shell
  git add *
  git commit -m "덮어씌운다" --amend
  ```

- 최종적으로 서버에 반영

  ```shell
  git remote add origin https://github.com/ahnjehoon/GIT_TEST.git
  # SSH 이용시
  git remote add origin git@github.com:ahnjehoon/GIT_TEST.git
  git push -u origin master
  ```

  

## 소스 업데이트

- 상대방이 커밋한 파일은 업데이트를 해야 동기화가 됨

- 이 때 사용하는 명령어는 git pull과 git fetch가 있음

- `pull` 과 `fetch` 의 차이점은 `merge` 작업 여부

- `pull` 은 `fetch` + `merge` 작업까지 함

  ```shell
  # master 브랜치를 pull하여 업데이트
  git pull origin master
    
  # master 브랜치를 fetch하여 업데이트
  git fetch origin master
  ```

### 소스 받기

#### 처음 받았을 때

- git clone [주소] [폴더이름]

#### 이후 업데이트 계속 받을 때

- 해당 폴더 들어가서

- git pull

## 소스 복원

- 예전 버전으로 롤백하여 적용하고 싶은 경우 git reset 명령어를 사용

- `git reset` 다음 인수로는 되돌리는 버전의 위치를 가리킴

- 현재위치(HEAD)를 기준하여 상대적인 위치를 설정하거나, 특정 버전 리비전 고유의 해시값을 지정
  HEAD를 확인하고 싶으면 `git reflog` 명령을 이용

- `git reset`의 옵션

  - --soft
    약한특성의 리셋. 되돌릴 때 기존의 인덱스와 워킹트리 보존
  - --hard
    강한특성의 리셋, 되돌릴 때 기존의 인덱스와 워킹트리를 버림
  - --mixed
    중간특성의 리셋, 되돌릴 때 기존의 인덱스는 버리고 워킹트리를 보존

  ```shell
  git reset HEAD^ --[option]
  ```

## 브랜치

- 가지를 펼치듯 하나의 근본에서 여러 갈래로 쪼개어 관리 가능
- 기본은 master 브랜치라고 불리며, 필수로 제공되는 브랜치
- `git branch [브랜치명]`으로 생성

## 병합

- 병합 방식에서는 크게 `git merge`와 `git rebase`가 존재함

## 충돌과 해결

- git으로 merge, rebase 수행시 충동(conflict)가 발생 할 수 있음

## SSH

- Git 서버들은 SSH 공개키로 인증함
- 사용자의 SSH 키들은 기본적으로 사용자의 ~/.ssh 디렉토리에 저장

1. 키 생성
   비밀번호 물어볼때 엔터 두번누르면 키 사용시 비밀번호 입력 안해도됨

   ```shell
   ssh-keygen -t rsa -b 4096 -C "ahnjehoon@naver.com"
   /c/Users/student/.ssh/id_rsa
   ssh-add ~/.ssh/id_rsa
   ```

2. <https://github.com/settings/keys> 이동

3. New SSH key 입력

4. TITLE은 암거나 쓰고 key에는 id_rsa.pub 내용 입력

5. git remote set-url origin [접속정보] 명령어를 이용해 SSH 접속정보 변경

### 히스토리 삭제(초기화)

1. 기존의 히스토리 삭제

   ```shell
   rm -rf .git
   ```

2. 파일정리 후 새로운 git 설정

   ```shell
   git init
   git add .
   git commit -m "first commit"
   ```

3. git 저장소 연결 후 강제 push

   ```shell
   git remote add origin git@github.com:<YOUR ACCOUNT>/<YOUR REPOS>.git
   git push -u --force origin master
   ```

### 특정 파일 제외하기 .gitignore

- `.gitignore`파일을 만들고 안에다가 적으면됨

- 만약 특정폴더의 하위폴더를 포함시키고 싶지 않다면

  







참고 : <https://github.com/KennethanCeyer/tutorial-git>

