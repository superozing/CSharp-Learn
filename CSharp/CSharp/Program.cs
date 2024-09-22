﻿namespace CSharp
{
    // 클래스: 기본적으로 레퍼런스를 넘긴다.

    // 기반 클래스
    class Player
    {
        public static int counter; // static - 모든 객체가 공통으로 가짐.
        public int id;
        public int hp;
        public int attack;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출");
        }

        public Player(int a)
        {
            Console.WriteLine("Player 생성자(a) 호출");
        }
    }

    // 파생 클래스
    // 파생 클래스는 기반 클래스의 멤버와 멤버함수를 모두 상속받는다.
    class Archer : Player
    { 
        
    }


    // 파생 클래스
    // 파생 클래스는 기반 클래스의 멤버와 멤버함수를 모두 상속받는다.
    class Knight : Player
    {

        // 스태틱 함수는 멤버에 접근할 수 없다.
        public static void StaticFuncCantControlMember()
        {
        }
        
        // 객체를 새로 만들어 멤버에 접근하는 것은 가능
        public static Knight Instanciate()
        {
            var knight = new Knight();
            knight.hp = 100;
            return knight;
        }

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

        public Knight() : base(10) // 기반 클래스 생성자 중 인자를 받는 생성자를 호출하고 싶을 경우, base 키워드를 사용해 호출 가능.
        {
            base.id = counter++; // 기반 클래스 멤버로 접근하기 위해서 base 키워드를 사용할 수 있다.
            hp = 100;
            attack = 100;
            Console.WriteLine("기본생성자 호출");
        }

        // this()는 자신의 생성자(지금은 기본 생성자를 뜻함)를 먼저 호출시키고, 그 다음 이 생성자를 호출시키라는 뜻.
        public Knight(int hp) : this()
        {
            // this 키워드를 사용해서 멤버를 지칭할 수 있다.
            this.hp = hp;
            Console.WriteLine("hp생성자 호출");
        }
        
        public Knight(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
            Console.WriteLine("hp, attack생성자 호출");
        }

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

            // 또는 복사 생성 함수를 정의하는 방법이 있다. - 깊은 복사 (가장 보편적으로 보인다)
            Knight knight4 = knight.Clone();


            // 구조체 - 지역 변수로 선언됨. (스택에 할당)
            // 클래스 - 힙 메모리에 동적 할당. 객체 == 포인터 변수.
            // 힙 메모리를 가리키는 포인터 변수의 크기는 64비트이고,
            // 힙 공간에는 클래스 멤버 크기만큼 공간을 할당한다.

            // C#의 경우에는 C++과 다르게 프로그래머가 힙에 할당한 공간을 직접 삭제하지 않아도
            // VM(가상 머신)이 관리해준다. .Net
            // C++의 shared_ptr과 같이 참조 개수가 없을 경우 메모리에서 삭제를 해주는 방식이겠죠?

            // 구조체도 ref 키워드를 사용하면 매개 변수로 레퍼런스를 넘겨줄 수 있다.
            // (힙에 할당된 공간 뿐만 아니라 스택에 할당된 변수 역시 주소를 넘겨줄 수 있다.)



            //====================================
            // 생성자 사용한 객체 생성


            // 생성자 호출 순서: 기반 -> 파생
            // 소멸자 호출 순서: 파생 -> 기반

            Knight knight5 = new Knight(100, 101);


        }


    }
}
