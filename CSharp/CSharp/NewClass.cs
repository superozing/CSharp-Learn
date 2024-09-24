using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Monster
    {
        uint m_id;

        public Monster() { }
        public Monster(uint _id) { m_id = _id; }
    }

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


            // ========================
            // 다차원 배열

            // 이차원 배열
            // int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] arr = { { 1, 2, 3 }, { 1, 2, 3 } }; // 이런 식의 초기화가 가능함.

            // 가변 배열
            int[][] a = new int[3][];   // 가변 배열은 이차원 배열과 다르게 열의 배열 요소 개수가 정해지지 않음.
            a[0] = new int[3];          // 이런 식으로 열마다 배열을 초기화 하고,
            a[1] = new int[6];          
            a[0][0] = 10;               // 행과 열을 사용해서 접근할 수 있다.

            // ========================
            // List <- C#의 동적 배열? (C++ stl 벡터)

            List<int> list = new List<int>();

            // add를 통해서 push_back 할 수 있다.
            for (int i = 0; i < 5; ++i)
                list.Add(i);

            // list.Count를 이용해서 list 요소 개수를 알 수 있다.
            for (int i = 0; i < list.Count; ++i)
            {
            }

            // foreach를 사용해서 순회 가능
            foreach (int i in list)
            {
            }

            // list.Insert를 사용해서 원하는 인덱스 자리에 삽입을 할 수 있다.
            list.Insert(2, 10);

            // Remove를 사용해서 원하는 값의 요소를 삭제할 수 있다.
            list.Remove(2);

            // RemoveAt을 사용해서 원하는 인덱스의 요소를 삭제할 수 있다.
            list.RemoveAt(2);

            // Clear()
            list.Clear();

            // 선형적 구조이기 때문에 탐색에 O(N)의 시간복잡도가 걸린다.
            // 예를 들어, 몬스터 객체 10000개가 리스트 안에 있을 때
            // 원하는 ID 값을 찾기 위해 최악의 경우에는 10000번 검사를 해야 한다.
            //


            // ======================
            // Dictionary - C++의 unordered_map과 비슷하다.
            // 해시 맵. - 해시 테이블을 사용해서 빠른 탐색

            // key, value.
            Dictionary<int, Monster> dictionary = new Dictionary<int, Monster>();

            // 요소 추가
            dictionary.Add(1, new Monster(1)); // add 함수를 사용
            dictionary[2] = new Monster(2);    // [] operator 사용

            // 값 가져오기

            // dictionary[찾으려는 키 값]; 으로 value 참조 가능.
            // "위험한 접근". 키 값이 없을 경우 문제를 일으킴.
            Monster mon1 = dictionary[1];

            // TryGetValue()함수를 사용해서 out으로 값 가져올 수 있다.
            // 반환으로 성공 여부 확인 가능.
            // out - 함수 내부에서 반드시 값을 세팅함
            bool suc = dictionary.TryGetValue(1, out mon1);

            dictionary.Remove(1);

            dictionary.Clear();

        }


    }
}
