using System.Reflection.Metadata;
using System.Security.Cryptography;

class ArrayStudy
{ 
    // 배열이 담을 수 있는 데이터의 갯수는 초기화시 정하게 되면 바꿀 수 없음.
    private int[] _scores = new int[5] { 0, 10, 20, 30, 40 }; 
    // 길이를 정하지 않고 초기화할 순 있지만, 그렇다 해도 한 번 초기화되면 그 길이가 고정됨.
    private int[] _numbers = new int[] {0, 1, 2, 3};
    // 배열 = {} -> 단축된 버전
    private string[] _names = { "eensungkim", "gildonghong" };

    public void Test()
    {    
        // 이런 방식으로 foreach 를 활용할 수 있음.
        foreach (int score in _scores)
        {
            Console.WriteLine($"점수는 {score}점 입니다.");
        }
    }

    // 2차원 배열
    int[,] tiles = {
        { 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1 }
    };

    // C#에서 어떠한 다차원배열.Length() 를 호출하면 배열 내 아이템의 전체 갯수를 반환함.
    // 아마도 배열을 연속된 메모리 블록에 저장하기 때문인 것으로 추측..
    // 그래서 배열의 배열로 동작하는 Swift 와는 다르게 내부 배열의 길이를 구하려면 별도의 GetLength 메서드를 활용해야 함.
    public void Render()
    {
        for (int y = 0; y < tiles.GetLength(1); y++) // GetLength 에 차원-1 값을 전달하여 길이를 추출.
        {
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                // 무언가의 작업
            }
        }
    }    
}

// 동적 배열로 이루어진 리스트
// 길이가 제한된 Array 와 달리 유동적인 활용이 가능
// 배열과 달리 리스트는 초기화된 상태 자체로는 서브스크립트 접근이 어려움.
// 값이 들어있어야 비로소 동작
// _list[0] = 1 을 바로 할 수 없단 의미임.
class ListStudy
{
    List<int> _list = new List<int>();
    
    public void Test()
    {
        for (int i = 0; i < 5; i++)
        {
            _list.Add(i);
        }

        Console.WriteLine($"길이는 Count 로 가져올 수 있다. _list 의 길이는 : {_list.Count}");
        // 제일 뒤로 삽입하는 것은 Add()
        // 중간에 삽입하는 것은 Insert(), 이때 특정 index 에 삽입하면 해당 index 부터는 값들이 뒤로 밀려남.
        // 삭제는 Remove() 전달받은 값과 비교하여 제일 처음 일치된 값을 삭제
        // RemoveAt() 인덱스로 접근해서 삭제
        // Clear() 를 실행하면 단번에 전체 삭제
        // List 는 중간에 삽입하는 경우 효율적이지 않음, 값들을 뒤로 밀어내야 하기 때문. 삭제도 마찬가지
    }
}

// 딕셔너리는 해시테이블로 구현되어 있다?!
// 메모리를 내주고 성능을 취한다고 볼 수도 있다고 함.
class DictionaryStudy
{
    Dictionary<int, string> _dictionary = new Dictionary<int, string>();

    public void Test()
    {
        for (int i = 0; i < 10000; i++)
        {
            _dictionary.Add(i, i.ToString()); // Add 를 호출하고 key, value 를 전달하여 추가 가능
        }

        string? numberString;
        // key 가 없는 경우 크래시가 나기 때문에, 마치 옵셔널을 쓰듯이 TryGetValue 와 out 을 조합하여 안전하게 가져올 수 있음.
        bool isNumber = _dictionary.TryGetValue(20000, out numberString);

        _dictionary.Remove(5000);
        _dictionary.Clear();
    }
}