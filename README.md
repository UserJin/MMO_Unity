# MMO_Unity
## 1. 소개
 * Top-View 3D RPG 게임의 틀과 주로 사용되는 간단한 기능들을 구현하는 것을 목적으로 하는 프로젝트입니다.
 * "**[C#과 유니티로 만드는 MMORPG 게임 개발 시리즈] Part3: 유니티 엔진 - Rookis**" 강의 영상을 보고 따라 구현하는 방식으로 진행하였습니다.
 * 개발 기간: 2024-05-21 ~ 2024-06-20
![1](https://github.com/user-attachments/assets/89491631-ac34-4fd9-ba63-ef766cb5f032)
<br/><br/>

## 2. 개발 환경
 * Unity 2022.3.7f1 LTS
 * C#
 * Windows 10
<br/><br/>

## 3. 구현 기능
 * **조작 및 이동**
     * 기본적으로 마우스를 통해 사용자의 입력을 받으며 이동 및 공격을 할 수 있다. 해당 입력은 Input Manager 클래스에 의해 제어
     * Input Manager에서는 사용자의 마우스 입력을 클릭, 클릭 상태 유지, 클릭 중지 등으로 구분하여 그에 맞는 액션을 실행
     * 사용자가 클릭한 지점에 RayCast를 실행하여 이동 및 공격의 실행 여부를 판단
 * **카메라**
     * **Raycast**를 활용하여 카메라와 플레이어 캐릭터 사이에 오브젝트가 존재하여 캐릭터가 가려지는 경우, 카메라의 위치를 오브젝트에 가려지지 않는 위치로 변경하는 기능 구현
 * **UI**
     * UI의 공통적인 기능을 갖는 부모 클래스 UI_Base를 바탕으로 각각의 세부적인 UI 클래스를 구현
     * **딕셔너리**를 활용하여 각 UI 요소를 타입을 키로 갖는 딕셔너리에 오브젝트 배열로 저장하고 가져올 수 있다. 
     * 단순한 형태의 인벤토리 기능 구현(인벤토리 UI를 클릭할 경우, 해당 아이템에 대한 정보를 로그로 출력)
 * **데이터**
     * 플레이어의 레벨에 따른 스테이터스 데이터를 **Json**형식으로 보관
     * Data Manager 클래스를 통해 해당 **Json** 데이터를 클래스의 딕셔너리에 저장하여 활용
 * **오브젝트 풀링**
     * 오브젝트들을 실시간으로 인스턴스화하는 것은 성능적으로 문제가 생기기에, 이를 미리 생성하고 필요한 경우 재사용 가능하도록 하는 **Object Pool**을 구현하고 이를 **Pool Manager**를 통해 관리
     * 오브젝트 풀링이 가능한 오브젝트에는 **Poolable** 스크립트를 부착하는 것으로 간단하게 구현
 * **매니저**
     * 특정 기능을 담당하는 각각의 Manager 클래스들을 구현, 또한 해당 Manager들을 통합하여 관리하는 Manager 관리 클래스를 구현
 * **유틸리티**
     * 여러 클래스에서 공통적으로 활용이 가능한 일부 기능의 경우, Util 클래스에 모아 재사용이 가능하도록 구현
     * 일부 Enum형 자료들을 다른 클래스에서도 사용 가능하도록 이를 모아놓은 클래스를 구현
<br/><br/>

참고 영상 : **[[C#과 유니티로 만드는 MMORPG 게임 개발 시리즈] Part3: 유니티 엔진 - Rookis](https://www.inflearn.com/course/mmorpg-%EC%9C%A0%EB%8B%88%ED%8B%B0/dashboard)**
