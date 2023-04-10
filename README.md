# perfectEngineer


#### 사용 기술: Unity(2020.2.2f1)
#### 제작 기간: 2020.10.22~2021.2021.02.01

<p align="center">
<img width="30%" src="https://user-images.githubusercontent.com/33209821/230907583-468ab1bd-2d5a-44c8-909a-9105b2878028.png"/>
<img width="30%" src="https://user-images.githubusercontent.com/33209821/230907584-3487105c-29ca-465f-af3f-a05259a988f3.png"/>
<br/>
<img width="30%" src="https://user-images.githubusercontent.com/33209821/230907589-a98061c3-097b-42d7-8e7b-ab894feea74c.png"/>
<img width="30%" src="https://user-images.githubusercontent.com/33209821/230909286-f242ff5c-f2c8-4a11-9c2f-ae79666451b9.png"/>
</p>

#### 설명
  - 맵에 빛 효과를 주기위해 Light2D 사용
  - 3개의 타일맵을 사용하여 구성(바닥 타일, 벽 타일, 맵 중간에 설치되는 벽 타일)
   - 벽의 종류에 따라 충돌판정 범위가 다르기에 분리시킴
  - 플레이어가 벽에 의해 가려졌을 시 벽 투명도 조절
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230911525-92e60b17-d12e-4fdb-a61f-8fadcb84b2c4.gif"/>
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230911515-f015e911-ed25-435d-aac3-94753a0328c9.gif"/>
  - 특정 오브젝트가 캐릭터에 의해 가려졌을 시 캐릭터 투명도 조절
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230912529-3900f642-fb80-43c8-947a-a3f371510233.gif"/>
  ```C#
  protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&isOnWall) { collision.gameObject.GetComponent<SpriteRenderer>().color= new Color(255 / 255f, 255 / 255f, 255 / 255f, 0.5f); }
        // 상호작용 오브젝트가 벽에 붙어있을 시 플레이어 투명도를 낮춤
    }
  
  ```
  
  - 캐릭터와 상호작용 가능한 오브젝트는 외각선 효과를 부여한다.
   - 캐릭터의 인식 범위내 존재하는 상호작용 가능 오브젝트들을 리스트에 넣음
   - 리스트를 캐릭터와의 거리에 따라 정렬한다.
   - 리스트의 첫번째 오브젝트를 focusedObject로 선정(외각선 효과는 쉐이더 사용)
 <img width="30%" src="https://user-images.githubusercontent.com/33209821/230912529-3900f642-fb80-43c8-947a-a3f371510233.gif"/>
   
   
  ```C#
  focusedObject.GetComponent<Renderer>().material.SetFloat("_OutlineThickness", 2f);
  ```
  - 움직임에 따라 출력 이미지가 다르기에 블렌더 트리 사용
  
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230907577-90beb52b-d911-45ab-8648-0ae68969b26a.png"/>
  
  - 벽 충돌 판정은 레이캐스트 사용
  - 각 방에는 룸 컨트롤러가 있어서 방의 밝기 등 요소들 조정 가능
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230911507-19a14458-c0cd-46dd-adb2-efe356fd7af8.gif"/>
  - 미니맵 기능 구현
    - 미니맵 레이어를 추가한 후 메인 카메라에 마스크에 미니맵 레이어를 제외시킨다.
    - 카메라를 추가하여 미니맵 레이어만 인식하게 설정한다. 
    - 플레이어는 빨간 점으로 대체한다.
    - M키를 눌러서 미니맵 크게보기가 가능하다(mapPointPosition에 구현)
  <img width="30%" src="https://user-images.githubusercontent.com/33209821/230912537-0ad69419-9d3f-49b3-a0a4-59674e6f0277.gif"/>
  
  - 열려있는 문은 플레이어와 일정 거리 이상 멀어질 시 자동으로 닫힘
  
  ```C#
  if (Vector2.Distance(player.Player.transform.position, door.transform.position) >= 5.2f)
   {
       door.GetComponent<Animator>().SetBool("isOpen", false); isOpen = false;
   }
  
  ```

#### 피드백
- 미니맵 확장 시 해상도가 깨져서 보기 불편함
- 미완성인 상태로 둠
- 빛 효과가 방 안에서만 적용되야 하는데 원 범위로 적용됨
