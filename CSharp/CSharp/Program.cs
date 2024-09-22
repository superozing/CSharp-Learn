namespace CSharp
{

    // 클래스: 기본적으로 레퍼런스를 넘긴다.
    class Knight
    {
        public int hp;
        public int attack;

        public Knight Clone()
        {
            // 왜 지역 변수를 그대로 반환해도 문제가 없는가?
            // -> C#의 클래스는 기본적으로 레퍼런스를 반환한다.
            Knight clone = new Knight();
            clone.hp = hp;
            clone.attack = attack;

            // 이동 생성자가 호출되는 것 같은데... 그냥 넘겨준다 라고 이해해도 되겠죠?
            return clone;
        }
        public void Move() { }
        public void Attack() { }

    }

    // 구조체: 기본적으로 복사를 넘긴다.
    struct Mage
    {
        public int hp;
        public int attack;
    }


    class Program
    {
        // Mage는 struct이기 때문에 복사본이 들어오게 된다.
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }        
        
        // Knight는 class이기 때문에 참조로 들어오게 된다.
        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }

        public static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            knight.hp = 100;
            knight.attack = 100;
            mage.hp = 100;
            mage.attack = 100;
            
            // 구조체는 복사본을 넘기기 때문에, Main 스택에 있는 mage(원본)가 수정되지 않는다.
            KillMage(mage);

            // 클래스는 레퍼런스를 넘기기 때문에, Main 스택에 있는 knight(원본)가 수정된다.
            KillKnight(knight);

            //=================
            // 구조체와 클래스의 생성자 차이
            //=================

            // "클래스는 대부분의 경우 참조로 작업한다."
            // "구조체는 대부분의 경우 복사로 작업한다."
            
            
            // 구조체는 복사한다.
            Mage mage2 = mage; 
            
            // 클래스는 참조를 가져온다. (얕은 복사)
            // 따라서 knight와 knight2는 같은 객체를 가리킨다.
            // 포인터 마렵네...
            Knight knight2 = knight; 


            // 완전히 독립된 객체를 이런 식으로 만들 수 있다. 근데 복사 생성자를 정의할 수는 없는걸까요?
            Knight knight3 = new Knight();
            knight3.hp = knight.hp;
            knight3.attack = knight.attack;

            // 또는 복사 생성 함수를 정의하는 방법이 있다. (가장 보편적으로 보인다)
            Knight knight4 = knight.Clone();





        }


    }
}
