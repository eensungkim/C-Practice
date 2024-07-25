// Exception(예외처리)
// 기본적인 try catch 문의 생김새는 swift 와 다르지 않은 것 같음.
// catch 문의 경우 순서대로 동작. 만약 앞에서 에러를 처리했다면 다음 catch 문은 동작하지 않음.

using System.Reflection;

class MyException {
    public static void Example()
    {
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b;

            int c = 0; // 12번 줄에서 에러가 발생했기 때문에 그 이후는 실행되지 않음.
            Console.WriteLine($"{c}");
        }
        catch (DivideByZeroException e)
        {
            System.Console.WriteLine($"특수한 에러 사유는 {e}입니다.");
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"에러의 사유는 {e}입니다."); // 위에서 에러를 처리하기 때문에 실행되지 않음.
        }
        finally
        {
            // 예외가 발생해도 무조건 처리되어야 하는 코드는 여기에 작성한다.
        }
    }
}

// Exception 을 상속받도록 하여 커스텀으로 예외 처리를 만들 수 있다.
class CustomException : Exception
{

}

// 강사 왈, 게임에서는 예외 처리를 하는 경우가 많지는 않다고 함.
// 예외가 난다는 건 다른 사람들도 문제를 다 겪는다는 것이고, 
// 그런 경우에는 차라리 빠르게 크래시나는 상황을 처리하는 것이 중요.

// Reflection
// 이건 뭔가 처음 들어본 단어인 듯
// Reflection 을 활용하면 런타임에 어떠한 클래스의 내부 구조를 파악할 수 있다고 함.

class Tested
{
    public int age;
    protected string name = "eensungkim";
    public int id;

    static void Run() { }
}

class MyReflection
{
    public static void Run()
    {
        Tested tested = new();
        Type type = tested.GetType();

        var fields = type.GetFields(System.Reflection.BindingFlags.Public
        | System.Reflection.BindingFlags.NonPublic
        | System.Reflection.BindingFlags.Static
        | System.Reflection.BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            string access = "protected";
            if (field.IsPublic)
                access = "public";
            else if (field.IsPrivate)
                access = "private";

            System.Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
        }
    }
}

// Attribute?
// 컴퓨터가 런타임에 참고할 수 있는 힌트를 남긴다?

class Important : System.Attribute
{
    string message;
    public Important(string message) { this.message = message; }
}

class TestAttribute
{
    [Important("매우 중요함")]
    public int age;
}

// 추가 공부가 필요함

// Nullable

class MyNullable
{   
    public static void Run()
    {
        int? number = null;
        number = 5; // 만약 106번 줄이 없어서 null 인 상태로 Value 를 꺼내오려 하면 뻗어버림.
        int a = number.Value; 
        // 공식문서를 보면 Value 는 HasValue 가 true 기본 형식의 값을, false 라면 InvalidOperationException 을 throw 한다고 함.
        System.Console.WriteLine(a);

        // if (number != null)
        // if (number.HasValue)
        // 이런 식으로 null 인지를 체크해야 함.

        // 이걸 위해서 추가된 문법이 ??(null 병합 연산자)
        int b = number ?? 0; // null 인 경우에 기본값을 전달하도록 만드는 것.
        int? c = number!.Value; // ! 도 문법이 있는 것으로 보임.
        // 검색해보니 요 ! 연산자(null 허용 참고 연산자)는 8.0 부터 도입되었다고 함.
    }
}