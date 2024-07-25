// C# 언어 학습 1일차
// 변수를 선언할 때는 [데이터타입] [변수명] = [저장할 데이터] 와 같은 형태
// 문장의 마무리에는 세미콜론 ; 를 반드시 찍어주어야 함.

class DataType {
    public static void Run() {
        int intNumber = 10; // 정수형 데이터
        double doubleNumber = 3.14; // 실수형 데이터
        string name = "eensungkim"; // 문자열 데이터
        bool isPracticing = true; // 불리언 데이터

        Console.WriteLine(intNumber);
        Console.WriteLine(doubleNumber);
        Console.WriteLine(name);
        Console.WriteLine(isPracticing);
    }
}

// 숫자 앞에 0b 를 붙이면 2진수를 변수에 할당할 수 있고, 0x 를 붙이면 16진수를 할당할 수 있다.
// 단 콘솔에서 확인할 때는 십진법으로 자동 변환되어 표기된다.
class NumberSystem {
    public static void Run() {
        int binaryNumber = 0b00001001;
        int hexadecimalNumber = 0x001B;

        Console.WriteLine($"0b00001001 는 십진법으로 {binaryNumber}");
        Console.WriteLine($"0x001B 는 십진법으로 {hexadecimalNumber}");
    }
}