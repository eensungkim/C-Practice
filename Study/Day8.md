# C# 프로그래밍(2판) 이어서
오버로딩과 오버라이딩
오버로딩은 이름이 같지만 매개변수를 달리하여 메서드를 관리하는 것
오버라이딩은 부모로부터 상속받은 메서드를 자식 클래스에서 새롭게 재정의하는 것

## readonly 키워드
클래스 변수 또는 변수 앞에 readonly 키워드를 붙여서 사용
변수를 선언하는 시점과 생성자 메서드에서만 값을 변경할 수 있음.
기본적으로 상수 선언인 const 와 유사하지만, 컴파일 타임에 값이 결정되는 상수와 달리 readonly 의 경우 런타임에 값을 설정할 수 있다고 함.
챗지피티의 도움을 받아 예시를 확인해보니, 클래스 프로퍼티를 상수로 선언하고 싶지만, 이를 생성자를 통해 지정해주고 싶을 때 유용할 것으로 보임.

```C#
using System;

public class Example
{
    public const int ConstValue = 10; // 컴파일 타임 상수
    public readonly int ReadonlyValue; // 런타임 상수

    public Example(int value)
    {
        ReadonlyValue = value; // 생성자에서 값 설정
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("ConstValue: " + Example.ConstValue);

        Example example1 = new Example(20);
        Console.WriteLine("ReadonlyValue (example1): " + example1.ReadonlyValue);

        Example example2 = new Example(30);
        Console.WriteLine("ReadonlyValue (example2): " + example2.ReadonlyValue);
    }
}
```

코드를 보면 ReadonlyValue 는 생성자를 통해 값을 설정해줄 수 있기 때문에 경우에 따라서는 인스턴스마다 다른 값을 지정해 활용이 가능하다. 그러나 인스턴스를 한 번 생성하고 난 뒤부터는 상수처럼 동작하고 변경이 불가능하기 때문에 상수로 선언했을 때와 동일하게 변경 가능성이 사라진 채로 활용 가능.

그 외에 유지/보수 시에 이점이 있다고 하는데 이 부분은 아직 완전히 이해되지 않음.

## 클래스 내에서의 변수와 속성
스위프트를 공부할 때는 딱히 변수와 속성을 구분하지는 않았던 것 같음.
C# 에서는 클래스의 변수와 속성을 구분하고 있다고 함.
일반적으로 클래스의 변수는 private 접근 제한자로 관리되며 소문자로 시작.
클래스의 속성은 public 접근 제한자로 관리되며 대문자로 시작. Getter 와 (필요한 경우)Setter 를 가진다.
