# Penguin_Race
 
![image](https://github.com/shstcs/Penguin_Race/assets/73222781/77cb37f0-198e-4a1d-9e73-650ab6f4c6a5)

# 게임 소개
- 2D TopDown Racing

# 게임 주요 기능
## 캐릭터 선택
- 게임을 들어가기 전 캐릭터를 선택할 수 있다.
- 고른 캐릭터에 따라 애니메이션이 다르다.
  ![image](https://github.com/shstcs/Penguin_Race/assets/73222781/511de568-0c8d-4189-96b1-24fcd138c377)

## NPC와 대화
- NPC 근처에서 G를 눌러 대화가 가능하다.
- 랜덤하게 대화 출력하도록 하였다.
  ![image](https://github.com/shstcs/Penguin_Race/assets/73222781/713199fa-6d7f-491f-9f43-43f816bb307b)

## 타이머 기능
- 출발선을 지나가면 타이머 작동.
- 도착선을 통과하면 타이머가 종료되고, 기록이 출력됨.

# 트러블 슈팅
상속받은 함수 사이의 동기화
레이싱 출발선을 지나면 시간이 흐르고, 도착선을 지나면 시간이 멈춘다.
이런 기조로 구현하려고 했는데 어째서인지 시간이 멈추지 않았다.
또 도착한 후에 도착선을 지나면 또 결과창이 뜨는 버그도 있었다.

로그를 찍어가며 살펴보니 시작과 끝의 스크립트에서 동기화가 이루어지지 않고 있었다.

현재 구조로 Race를 상속받은 세 클래스가 있고, 각자 위치에서 Race에 존재하는 Event를 호출한다.

```
public event Action isRacingStart;
public event Action isRacingEnd;
public void CallRacingStart()
{
    isRacingStart?.Invoke();
}
public void CallRacingEnd()
{
    isRacingEnd?.Invoke();
}
```
그래서 함수를 넣을 때 현재 레이싱중인지 확인하는 bool값을 변경하고 있었다.
```
public bool isRacing { get; set; }
```
그런데 출발선을 지나면 RaceStart쪽의 isRacing만 바뀌고, 도착선을 지나면 반대 현상이 일어났다.

> 결과적으로 상속에 관한 문제였다.

상속받는 클래스에서 부모클래스의 변수를 호출하면 같은 위치에서 가져올 줄 알았는데 각각 객체가 생성되어 다른 변수로 동작한 것이다.

외부의 GameManager에서 Race 객체를 하나 만들어두고, 그 객체로 접근하니 해결되었다!

# 얻어간 것.
- 유니티 LifeCycle에 대한 전반적인 이해.
- 유니티 Action 사용법 학습.
