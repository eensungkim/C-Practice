// C# 언어 학습 1일차
// 변수를 선언할 때는 [데이터타입] [변수명] = [저장할 데이터] 와 같은 형태


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

class NumberSystem {
    public static void Run() {
        int binaryNumber = 0b00001001;
        int hexadecimalNumber = 0x001B;

        Console.WriteLine($"0b00001001 는 십진법으로 {binaryNumber}");
        Console.WriteLine($"0x001B 는 십진법으로 {hexadecimalNumber}");
    }
}