# 유니티 학습
## Position

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
```

Unity 상에서 월드 좌표계와 로컬 좌표계는 서로 다른 것을 나타냄. 마치 UIKit 에서 frame, bound 랑 비슷한 느낌이랄까.
만약 `transform.position += Vector3.forward * Time.deltaTime * _speed` 와 같은 식으로 이동을 구현한다면
월드좌표계를 바탕으로 움직이기 때문에 캐릭터가 바라보는 방향으로 움직이지 않아 의도와 다르게 동작함.
그래서 `tramsform.position += tramsform.TransformDirection(Vector3.forward * Time.deltaTime * _speed)` 으로 사용해야 일반적인 우리의 의도대로 동작하고, 더 간단한 버전이 위에 작성된 코드인 거임.


transform 은 한국어로 변환이라고 번역할 수 있고, 위치(position)와 회전(rotation), 크기(scale) 로 구성됨.
transform.Translate() 는 이동에 관련된 메서드이고, 설명을 보면 "Moves the transform in the direction and distance of translation." 라고 되어있음

내가 전달한 정보는 distance 에만 해당되는 것 같은데, direction을 얘는 어떻게 받아와서 자체 적용하고 있는걸까?
Translate 의 정의를 살펴보면 아래와 같은데

```C#
public void Translate(Vector3 translation)
{
    Translate(translation, Space.Self);
}
```

translation 하나만 전달받은 경우 다시 Transalte를 호출하고, 이때 Sapce.Self 라는 애를 함께 전달함.
오 그럼 Space.Self 라는 놈이 내가 원하는 걸 나타내는 걸까?
다시 한 번 더 정의를 타고 들어가보자.

```C#
public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo)
{
    if (relativeTo == Space.World)
    {
        position += translation;
    }
    else
    {
        position += TransformDirection(translation);
    }
}
```

음.. relativeTo 자리에 기본값이 오도록 되어있고, 만약 그것이 Space.World 와 동일하다면 translation 을 그냥 더해주고 그게 아니라면 다시 TransformDirection(translation) 으로 던지는 것으로 보임.
Space.World 가 뭔지는 아직 몰라도 아래 로직이 단순 합산인 거 보면 월드좌표의 무언가와 같을 경우로 해석되는 것 같음.
방향성이 다를 경우에 else 구문이 실행될 것으로 예상되는데 또 타고 들어가보자.

```C#
public Vector3 TransformDirection(Vector3 direction)
{
    TransformDirection_Injected(ref direction, out var ret);
    return ret;
}
```

타고 가 보면 이런 구조이고, out var ret 자리에 전달되는 데이터에 기반해서 뭔가가 실행되는 걸로 보임

```C#
private extern void TransformDirection_Injected(ref Vector3 direction, out Vector3 ret);
```

더 타고 들어가보려 했으나 이제 private 으로 막혀버림
out Vector3 ret 로 되어있는 것으로 봐서, ret 이 곧 position 인 것으로 추측할 수 있고, 이 정보를 바탕으로 뭔가를 진행하는 것이 아닐까 싶음.
디버깅으로 더 내부를 볼 수 있을까 했는데 들어가지지는 않더라..

---

## Vector3

벡터는 x, y, z 3개의 float 데이터를 가지고 있음.
게임에서 벡터는 위치 벡터와 방향 벡터, 크게 2가지로 나누어 사용할 수 있다.

2 개의 벡터가 있다고 가정하면, 어느 하나에서 다른 하나를 빼게 되면 둘 사이의 거리를 알 수 있을 뿐 아니라 방향성도 알 수 있게 된다.
그리고 거리는 피타고라스의 정리를 활용해 알 수 있음. 3차원인 경우 `거리의 제곱 = x*x + y*y + z*z` 가 됨.
방향 벡터가 거리와 방향 2가지 정보를 가지고 있다고 할 때, magnitude 는 거리 정보라고 할 수 있고, normalized 는 방향은 같지만 크기가 1인 벡터를 반환하여 활용하게 된다.

---

## Rotation

transform.rotation 을 확인해보면 `A Quaternion that stores the rotation of the Transform in world space.` 이라는 설명을 확인할 수 있음.
유니티 에디터를 보면 x, y, z 세가지 데이터만 조작 가능하니 벡터일 것 같은데 왜? 그럴 떈 transform.eulerAngles 라는 프로퍼티를 활용해야 함.

https://www.youtube.com/watch?v=zc8b2Jo7mno
x, y, z 세 축을 활용한 회전에서는 gimbal lock 이라는 문제에 봉착할 수 있게 됨.
특정한 상황에서 2개의 축이 하나의 방향으로 고정될 수 있는 문제임.

쿼터니온은 이 gimbal lock 이라는 문제를 해결하기 위한 방법

Quaternion.LookRotation() 을 활용해 방향을 바라보게 할 수 있음

```C#
if (Input.GetKey(KeyCode.W))
    transform.rotation = Quaternion.LookRotation(Vector3.forward);
```

이렇게 했을 때, 방향을 잘 바라보지만 뭔가 너무 뚝뚝 끊기게 바라보는 문제가 생기는데,
이는 Slerp, 또는 Lerp 를 활용해 해결할 수 있다고 함.

```C#
if (Input.GetKey(KeyCode.W))
{
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
}
```

메서드에 달린 주석을 확인해보면 두 점 사이를 선형 보간으로 부드럽게 전환한다고 되어있고, 제일 마지막 값은 0~1 사이의 값으로 제한된다고 되어있음.
당장 이해하기에는 좀 어려운 개념인지도. 아무튼 중요한 건 0~1 사이의 값을 넣어 부드러운 전환을 유도할 수 있다는 부분인 듯.

아무튼 이러한 전환에 더해 해당 방향으로 이동하도록 하기 위해서 최종적으로 작성한 코드는 아래와 같음

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
            
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
            
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
```

