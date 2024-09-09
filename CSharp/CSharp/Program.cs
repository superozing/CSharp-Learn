namespace CSharp
{
    class Program
    {
        // 주석.
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
            var va = 10;
            var vb = 1.234f;
            var vc = "이런게 된다고?";
            var vd = true;

        }
    }
}
