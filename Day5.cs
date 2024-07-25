// object 라는 키워드도 있음.
// C# 에서 모든 타입은 object 를 상속받아 구현되어 있다고 함.

// object obj = 3;
// object obj2 = "hello world";

// int num = (int)obj; // 이런 식으로 캐스팅을 해줘야 함.

// var 는 타입을 직접적으로 명시하지 않더라도 컴파일러가 추론해서 타입을 정하는 것을 의미함
// object 는 타입 그 자체가 object 타입이 되는 것

// object -> 기본 데이터 타입 으로 변환하는 과정은 내부적으로 복잡한 연산 과정이 걸려 무거운 작업이 됨.

// Generic
// T 자리에 어떠한 타입이든 넣을 수 있게 됨.
// where 뒤는 T가 어떠한 형식을 따라야 한다는 것을 강제하는 조건절
class MyList<T> where T : struct
{   
    T[] arr = new T[5];
    public T GetItem(int i)
    {
        return arr[i];
    }
}

// 함수도 제네릭을 적용할 수 있다. 함수명 바로 뒤에 <>를 붙여 넣을 수 있음.
// void Test<T>() 
// {
//     // T를 활용한 무언가
// }

// 추상 클래스
abstract class Parent // abstract 를 붙여 추상 클래스를 만들 수 있음. 이 추상클래스는 new 로 생성할 수 없음.
{
    public abstract void DoSomething(); // 파생 클래스가 구현해야 할 메서드를 다음과 같이 지정해줄 수 있다. 실제 구현이 아니기 때문에 중괄호 없이 선언.
}

class Child : Parent
{
    public override void DoSomething() // 추상 클래스의 추상 메소드는 파생 클래스가 반드시 구현해야 한다.
    {
        // DoSomething
    }
}

// Interface
// Swift 의 Protocol 과 유사
// C# 은 다중상속을 허용하지 않기 때문에 추상 클래스 보다는 Interface 를 활용하는 것이 유리.

interface ITestable // C#에서는 보통 I 를 붙여서 인터페이스임을 나타낸다고 함.
{
    void Test();
}

class GrandChild : Child, ITestable
{
    public void Test()
    {
        // 실제 구현은 여기에서
    }
}

// Property
// 프로퍼티를 은닉화해서 외부 노출을 최소화하고, 변경이 필요한 작업을 세터로 분리할 때의 장점은
// 외부에서 직접적으로 프로퍼티를 조작하지 않고, 변경 작업은 해당 프로퍼티의 세터로만 가능하기 때문에
// 변경에 필요한 모든 로직이 하나로 모여 관리가 쉬워진다는 데에 있다.
// 내부 메서드에서 해당 프로퍼티를 변경한다 하더라도, 최소한 하나의 클래스 안으로 모아둘 수 있는 셈.

class Property
{
    public string name
    {
        get { return name; }
        private set { name = value; } // private 을 붙여 외부 접근을 막고 내부에서만 활용할 수도 있음.
    }
    public int Age { get; set; } = 36; // 게터와 세터를 단축화해서 이런 식으로도 선언 가능. C# 7.0부터 가능
}

// Delegate
// Delegate 는 타입처럼 활용도 가능함. 단 꼭 타입명으로 활용되지 않아도 함수의 모양(인자의 개수, 리턴값)이 같으면 활용 가능

delegate int Operation();

class MyDelegate
{
    static int TestDelegate() // Operation 이라는 타입으로 선언하지 않았지만 입력과 출력이 같으므로 활용 가능
    {
        System.Console.WriteLine("TestDelegate 실행");
        return 0;
    }
    static int TestDelegate2()
    {
        System.Console.WriteLine("TestDelegate2 실행");
        return 0;
    }

    public static void Test()
    {
        Operation operation = new Operation(TestDelegate);
        operation += TestDelegate2; // 요 지점이 특이한데, 타입명으로 활용했을 때 합연산이 되고 2개가 순차적으로 실행됨.
        operation();
    }
}

// Event
// Delegate 는 외부에서 Delegate로 선언된 객체에 접근할 수 있으면 어디에서든 호출될 수 있다는 문제점이 있음.
// Event 로 다시 묶어주게 되면 외부에서 호출되지 않는다?
// Event 를 활용하여 옵저버 패턴의 구현이 가능함.
class InputManager
{
    public delegate void OnInputKey();
    public event OnInputKey InputKey; // 외부에서 InputKey 에 += 함수명, -= 함수명 으로 구독하거나 취소할 수 있음.
    public void Update()
    {
        if (Console.KeyAvailable == false)
            return;
        ConsoleKeyInfo info = Console.ReadKey();
        if (info.Key == ConsoleKey.A)
        {
            InputKey();
        }
    }
}

// Lambda
// 일회용 함수를 만드는데 사용하는 문법이라고 설명
// delegate 를 붙여 익명함수로 전달하는 방법도 있지만 C#이 발전하며 람다식이 나오게 되었음
// 자바스크립트의 화살표 문법과 유사한 모양.
// 함수가 들어갈 자리에 ( [매개변수] ) => { [리턴값] } 를 넣어 만든다.

// delegate 를 만들 때
// 반환타입이 있는 경우 Func<> 를 활용해 만들 수 있음
// 반환타입이 없으면 Action<> 를 사용
