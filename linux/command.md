# 기본 명령어

----

## process 관련

- 현재 작업 상태 보기 - jobs
- Background에서 작업 실행하기 - [명령어] &
  명령어 뒤에 & 붙여주면 됨
- Foreground 작업을 BackGround로 - Ctrl + Z
  작업이 멈췄다면 bg %[작업ID값(jobs치면 나옴)]
- BackGround 작업을 Foreground로 - fg%[작업ID값(jobs치면 나옴)]
- 작업 끝내기 - kill %[작업ID값]
- Backgound 작업 중지 - 이건 fg로 가져와서 백그라운드로 돌리래요

---

# HISTORY

- 리눅스 HISTROY 확인

  ```shell
  history
  ```

- 히스토리 전체 삭제

  ```shell
  history -c
  ```

- 특정 행 삭제

  ```shell
  history -d 행번호
  ```

  



추가예정..