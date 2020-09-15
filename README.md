# SmartHome_IoT

아두이노와 MYSQL를 이용한 스마트홈 프로그램입니다.

1. 아두이노에서 온습도, 자외선, 미세먼지 값을 읽어 온뒤 StateView에서 3초간격으로 실시간 시각화
2. ControlView에서 임의로 만든 집 내부 환경을 아두이노 시리얼 통신으로 조작
3. FunctionView에선 사용자가 원하는 기능만 저장하고 간편하게 사용할 수 있게 제작
4. 3초 동안 받은 실시간 센서값은 MY SQL DB에  

# 프로젝트 정보
+ 설치
  + Visual Studio
  + Arduino IDE
  + MY SQL
  
+ 사용 방법
  + 각 센서값에 맞는 라이브러리 다운로드
  + 아두이노 각 센서 연결
  + TempHumid.ino 업로드
  + VisualStudio 이용하여 FINAL.sln 실행
  + MY SQL에 센서 값 저장 필요 시 DB생성 및 Table 생성
  + FINAL.sln MainView에서 사용자 아두이노 포트에 맞게 코드 변경
  + Ctrl + F5 
  
# 실행 화면
## 1. MainView
![main](https://user-images.githubusercontent.com/71310919/93178741-9e732c00-f76f-11ea-8d08-320ed8fb6577.png)

## 2. StateView
![state](https://user-images.githubusercontent.com/71310919/93179028-10e40c00-f770-11ea-8671-1b4958f90dc9.png)

## 3. ControlView
![control](https://user-images.githubusercontent.com/71310919/93179140-3a9d3300-f770-11ea-853b-62d235f17d5d.png)

## 4. FunctionView
![function](https://user-images.githubusercontent.com/71310919/93179150-3d982380-f770-11ea-8071-7fd8d607f30e.png)

## 5. FunctionView 간편기능
![function1](https://user-images.githubusercontent.com/71310919/93179159-3f61e700-f770-11ea-96ec-a879ef54bdc6.png)

## 6. MY SQL
![mysql](https://user-images.githubusercontent.com/71310919/93179380-910a7180-f770-11ea-877e-99c55948fd19.png)


