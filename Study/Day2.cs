// 형 변환
// (자료형)[변환할 데이터] 형태

class Casting {
    public static void Run() {
        double number = 150.6324;
        int casted = (int)number;

        Console.WriteLine(casted);

        // string notNumber = "숫자가 아님";
        // int notCasted = (int)notNumber; // 문자열 -> 정수 또는 정수 -> 문자열 의 경우 다른 방식으로 변환해야 함
        
        // 문자열 -> 정수
        string stringNumber = "123";
        int castedString = int.Parse(stringNumber); // 이런 방법 외에도 여러 방법이 있을 수 있음.

        Console.WriteLine(castedString);

        // 정수 -> 문자열
        int height = 178;
        int weight = 72;
        string message = string.Format("그 사람의 키는 {0}cm이고 몸무게는 {1}kg입니다.", height, weight); // 옛날 방식

        Console.WriteLine(message);
        Console.WriteLine($"새 방식으로는 이렇게 표현할 수 있습니다. 그 사람의 키는 {height}cm이고 몸무게는 {weight}kg입니다.");
    }
}

// 산술 연산이나 비교, 논리 연산 등은 크게 다르지 않음.

// var 라는 키워드를 사용해 변수를 선언하면, 타입 추론으로 자동적으로 타입이 지정됨.
// 값을 통해 타입을 명확히 유추할 수 있거나, 타입의 이름이 복잡하고 긴 경우에 var 를 활용하여 코드를 간결하게 유지할 수 있음.
// 데이터 타입 앞에 const 를 붙여서 상수를 선언할 수 있음.

// 조건문을 작성할 때에도 () 안에 조건이 들어간다는 점만 기억하면 될 듯
// if (조건) { } | switch (조건) {  }
// Swift 와 달리 switch 문을 사용할 때 조건을 탈출하기 위해 break; 를 넣어주어야 함.
// 삼항연산자를 활용할 때는 괄호를 붙이지 않아도 됨.

// 열거형, 선언 방식은 크게 다르지는 않은 듯

enum Choice {
    Rock = 1,
    Paper = 2,
    Scissors = 0
}

// ref 키워드를 통해 매개변수 자리에 참조값을 전달할 수 있음.
// 이때 매개변수 선언 시에도 ref 키워드를 적고, 메서드 호출 시에도 ref 를 적어주어야 함.
// out 이라는 키워드가 있음. ref 와 마찬가지로 참조값을 전달하는 형태
// 메서드로 여러 개의 값을 출력하고 싶을 때
// 마찬가지로 매개변수 선언 시, 메서드 호출 시 둘 다 out 키워드를 붙여주어야 한다.

class Division {
    public static void Divide(int a, int b, out int result1, out int result2) {
        result1 = a / b;
        result2 = a % b;
    }
}