﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class GrammarLearn
    {

        // delegate
        // 마치 함수 포인터
        public delegate int OnClicked(int a, int b);
        public event OnClicked eventOnClicked;




        // 템플릿과 같이 자료형 설정 가능.
        class LearnGeneric<T1, T2, T3, T4> // 반드시 어떤 자료형이 들어와야 하는지 명시 가능. (C++에 없는 문법)
            where T1 : struct // T1은 값 형식이어야 한다. 
            where T2 : class  // T2는 참조 형식이어야 한다. 
            where T3 : new()  // T3는 인자를 받지 않는 기본 생성자가 정의되어야 한다.
            where T4 : Monster// T4는 Monster 클래스 또는 상속받은 클래스여야 한다.
        {
            private int hp;
            private int hp2;

            // 프로퍼티 - Get, Set 편하게
            public int Hp 
            { 
                get 
                {  
                    return hp; 
                }

                // 접근 지정자 사용 가능.
                protected set 
                { 
                    // value - 우항
                    hp = value;
                } 
            }


            // 자동 완성 프로퍼티
            public int Hp2 { get; set; } // 
        }

        public static int test1(int a, int b) { return 1; }
        public static int test2(int a, int b) { return 2; }

        public static void Main(string[] args)
        {
            // =============================
            // Generic (일반화)
            // =============================

            // object
            // 모든 자료형은 object를 상속하기에 이런 행위가 가능.
            // 단, object는 참조만 사용할 수 있기 때문에 속도가 느리다.(힙 할당 후 가져오기 같은 동작을 수행해야 하기 때문에.)
            // 일반 자료형이 더 빠른 이유.
            object obj1 = 1;
            object obj2 = "string";

            // 타입 캐스트 필요.
            int i1 = (int)obj1;
            string s1 = (string)obj2;


            // ==================================
            // delegate (대리자)
            // ==================================

            OnClicked onClicked = new OnClicked(test1);

            // 마치 함수 포인터 같이 실행 가능.
            onClicked(1, 2); // test1 실행

            onClicked += test2;// 함수를 연이어 실행 가능(chaining)

            onClicked(1, 2); // test1 실행 -> test2 실행


            // ==================================
            // 이벤트
            // ==================================

            // eventOnClicked();

            // lambda - (인자)=>(구현부, 반환)
            // reflection - gettype()로 type 가져와서 Type 사용해 필드 정보 가져오기. 클래스 내부 정보를 한 번에 볼 수 있다.
            // attribute - 컴파일 타임 주석
            // nullable - int? - int이지만, 예외 상황을 위해 null을 추가한 int? 자료형.
            //  int? a; 가 있을 때, a ?? 0 -> a가 null이 아닐 경우 a를, 아니면 0을 반환.
            //  a.HasValue를 사용해 값 있는지 확인 가능.
        }
    }
}
