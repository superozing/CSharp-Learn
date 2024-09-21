namespace CSharp
{
    class Program
    {
        // 주석.

        static void initOut(out int a)
        {
            // a의 레퍼런스를 받아오는 것은 ref와 같다.
            // out으로 받아온 매개변수는 값을 할당하기 전까지 읽는 것을 할 수 없다.
            // 인자로 넣어줄 때, out 키워드를 붙여주어야 한다.
            a = 0;
        }


        static void AddRef(ref int a)
        {
            // a는 주소를 가져옴.
            a++;
        }

        static void AddCopy(int a)
        {
            // a는 복사본을 가져옴.
            a++;
        }

        static void Main(string[] args)
        {
            // int - 정수형
            // float - 실수형
            // string - 문자열 (이런게 기본 자료형이라고?)
            // bool - 참/거짓

            // C#의 cout
            Console.WriteLine("Hello, World!");

            int i = 100;
            // int i = 0x01; // 2진수
            // int i = 0x1F; // 16진수

            // unsigned가 아닌 첫 비트는 음수, 양수를 나타내는 데에 쓰임.
            // 2의 보수법
            Console.WriteLine(i);

            float f = 3.14159f; // 4byte
            double d = 3.14159; // 8byte
            Console.WriteLine(f);
            Console.WriteLine(d);

            string str = "아니 이런게 가능하다고...?";
            char c = 'a';                               // 2byte
            Console.WriteLine(str);
            Console.WriteLine(c);


            // bool b = 1; // 이런 문법이 허용되지 않는다고...? 불편하네요.


            // cast
            // 더 큰 데이터에서 작은 데이터 타입으로 대입할 경우 형변환을 해주어야 함.
            short s = (short)i;


            // string format
            string strInput = Console.ReadLine();
            Console.WriteLine(strInput);

            // str to int
            int iInput = int.Parse(strInput);

            // int to string
            int hp = 200;
            int maxHp = 200;

            // {} 가 C string의 %d 같은 느낌인가봐요.
            string msg = string.Format("당신의 HP는 {0} {1} 입니다.", hp, maxHp);
            Console.WriteLine(msg);

            // 문자열 보간 (string interpolation)
            string interpolationMsg = $"당신의 HP는 {hp} {maxHp} 입니다."; // 아니 이런게 가능하다고????
            Console.WriteLine(msg);


            // var (자동 추론 자료형), 하지만 자료형 명시하는게 더 가독성 좋아서 별로 안씀.
            // C++의 auto와 비슷해보여요.
            var va = 10;
            var vb = 1.234f;
            var vc = "이런게 된다고?";
            var vd = true;

            // 랜덤: 무작위 값을 뽑아올 수 있어요.
            Random rand = new Random();
            rand.Next(0, 3);



            /// 함수
            int iRef = 0;

            // 참조 값을 넘겨주려면 ref를 사용해야 한다.
            AddRef(ref iRef);

            // 참조 값을 넘겨주지 않는 함수의 경우 ref를 사용하지 않아도 된다(새로 생성된 복사된 매개변수)
            AddCopy(iRef);

            // out은 보통 메서드 안에서 값을 할당해야만 하는 상황에 쓰임(여러 개의 반환이 필요하다거나..)
            // out 키워드를 명시적으로 붙여주어야 함.
            initOut(out iRef);
        }
    }
}
