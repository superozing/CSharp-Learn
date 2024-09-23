using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class NewClass
    {
        static void Sort(int[] scores)
        {
            bool IsSorted = false;

            while (!IsSorted)
            {
                IsSorted = true;
                for (int i = 0; i < scores.Length - 1; ++i)
                {
                    if (scores[i] > scores[i + 1])
                    {
                        IsSorted = false;

                        // swap
                        int temp = scores[i];
                        scores[i] = scores[i + 1]; 
                        scores[i + 1] = temp; 
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            // ========================
            // 배열
        
            // scores는 int 배열을 담는 참조.
            int[] scores = new int[5];
            scores[0] = 10;
            scores[2] = 20;
            scores[3] = 30;
            scores[4] = 40;
            scores[5] = 50;

            // 이런 식의 축약도 가능함.
            // int[] scores = new int[5] { 10, 20, 30, 40, 50 }; // initialize
            // int[] scores = new int[] { 10, 20, 30, 40, 50 }; // 자동으로 알맞은 크기의 배열 공간 할당
            // int[] scores = { 10, 20, 30, 40, 50 }; // new 키워드를 생략 가능

            // scores2 역시 scores와 같은 공간의 배열을 가리킨다.
            int[] scores2 = scores;

            // scores와 scores2 양 쪽에서 0번 인덱스가 같은 것을 확인할 수 있다.
            scores2[0] = 9999;


            // 일반적인 C 스타일의 for 순회
            for (int i = 0; i < scores.Length; ++i)
                Console.WriteLine(scores[i]);

            // foreach를 사용한 순회
            // for (int& i : scroes){}와 비슷하네요.
            foreach (int i in scores)
                Console.WriteLine(i);


        }


    }
}
