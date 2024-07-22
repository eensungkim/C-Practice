// 객체지향
// 결국은 확장에 열려있고 유지보수가 용이한 것이 핵심이지 않을까..?
// 객체는 속성(property)과 기능(method)로 나눌 수 있다.

// 클래스
// 객체지향에서 가장 흔히 쓰이는 객체의 틀을 만들어내는 방식

class Object 
{
    // properties
    private string name = "eensungkim";
    
    // getter 와 setter 의 선언
    // setter 에서는 value 라는 변수명으로 값을 가져와 활용한다.
    public int age
    {
        get { return age; }
        set
        {
            if (value > 0) { age = value; }
            else { Console.WriteLine("나이는 자연수를 입력해 주세요."); }
        }
    }

    // 생성자는 public 으로 만들고 클래스 이름과 같게 만들도록 되어있음. 반환과 관련한 선언을 하지 않는다.
    // private 생성자는 기능이 다르다고 함.
    public Object(string name, int age) 
    {
        this.name = name;
        this.age = age;
    }

    // 소멸자는 ~를 클래스 이름 앞에 붙여서 만들게 된다.
    ~Object() 
    {

    }
    
    static void Run() 
    {
        // 이건 클래스 메서드
    }

    public int GetAge() 
    {
        return 36;
    }
}

// Unity 코드를 까보면서 느낀건데, 강의에서도 그랬고 C#은 코딩 컨벤션에 다른 부분이 좀 있는 것 같음.
// 일단 {} 요 중괄호는 다 아예 다른 줄로 작성하는 경향이 있어보임.
// 그리고 메서드를 선언할 때는 다 대문자로 만들더라.