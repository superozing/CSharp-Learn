using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class AbstractLearn
    {
        // abstract 키워드를 붙여서 추상 클래스를 만들 수 있다.
        // 추상 클래스는 객체를 생성할 수 없다.
        abstract class Monster
        {
            public abstract void Shout(); // abstract 함수는 선언만.
        }

        // 추상 클래스를 상속받은 파생 클래스는 순수 가상 함수를 모두 정의해야 한다.
        class Orc : Monster 
        {
            public override void Shout() { } // 정의해주어야 한다.

        }


        // =================
        // interface
        // 인터페이스는 필요한 기능의 구현을 강제함.

        interface IFlyAble
        { 
            void Fly(); 
        }

        // IFlyAble 인터페이스를 가지는 FlyOrc는 반드시 Fly()를 정의해야 함.
        class FlyOrc : Orc, IFlyAble
        {
            public void Fly() { }
        }

        static void CanFly(IFlyAble _flyAble)
        {
            // 해당 인터페이스를 사용한 클래스는 반드시 인터페이스에서 선언한 함수를 정의했기 떄문에, 이런 식의 사용이 가능하다.
            _flyAble.Fly();
        }
        
        public static void Main(string[] args)
        {
            // 인터페이스는 포인터 변수와 같이 해당 인터페이스를 사용한 클래스의 참조를 저장할 수 있다.
            IFlyAble flyAble = new FlyOrc();

        }
    }
}
