using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    //오늘 수업 내용 (컬렉션)
    // 데이터를 묶음 단위로 취급할 수 있는 클래스의 집합
    // 1. 배열
    // 2. 리스트(어레이 리스트)
    // 3. 딕셔너리(해쉬테이블)
    // 4. 스택 / 큐


    #region 배열

    // 정수형 배열을 선언한다.
    private int[] intArray = new int[5]; 
    // 기본적으로 배열은 레퍼런스 타입이기 때문에 초기화 할당을 하지 않으면 null 상태

    private int someInt; // int는 리터럴 타입이라 초기값 할당을 하지 않아다 기본값이 할당 됨


    // 이미 인스펙터에서 설정해놓은 값은 reset 버튼을 통해 다시 초기화 가능  
    public int[] publicIntArray = new int[10];

    // 이렇게 만들어 reset시에 놓으면 10이 아닌 15개가 생김
    private void Reset()
    {
        // 전역 변수의 초기값 할당 수행 후, 호출됨
        publicIntArray = new int[15];
    }
    #endregion



    #region 리스트

    // 배열과 비슷한 기능을 한다.
    // 유동적으로 크기 변경이 가능
    //요소 비교 등의 기능을 지원하는 함수가 포함되는 클래스

    private List<int> intList = new List<int>();

    public List<int> publicList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    #endregion

    #region 딕셔너리

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    // 리스트는 순차적으로 탐색해야하기 때문에 시간복잡도가 올라감
    // 딕셔너리는 키를 이용해 값과 키를 짝지어 놓아 탐색할 때 상대적으로 시간복잡도를 적게 씀
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();


    //                                  상대적으로
    // 배열 :                 공간복잡도 (낮음) 시간복잡도(높음)
    // 딕셔너리(해시 테이블) : 공간복잡도 (높다) 시간복잡도(낮다)
    // ㄴ 보통 배열보다 2배의 공간 복잡도 사용

    // 이걸 기반으로 딕셔너리가 만들어졌다.
    // 키의 자료형을 제한하지 않기 때문에 잘 쓰이지 않고 보통 딕셔너리를 많이 사용한다.
    private Hashtable hashtable = new Hashtable();

    // 인스펙터에서는 활용 불가능
    public Dictionary<string, GameObject> publicDictionary;

    #endregion

    // 프로퍼티
    private int a;

    int A { get { return a; } set { a = value; } }
    // 아래의 a_1을 간단하게 만들어 놓은 것

    // 캡슐화
    private int a_1;

    // setter 메서드
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("잘못된 값이 입력되었습니다.");
            a_1 = 100;
        }
        else
        {
            a_1 = value;
        }
    }
    // getter 메소드
    public int GetA_1()
    {
        return a_1;
    }


    #region 스택 / 큐

    // 스택
    private Stack<int> intStack = new Stack<int>();

    // 큐
    private Queue<int> intQueue = new Queue<int>();

    #endregion


    private void Start()
    {
        //intArray[0] = 1;
        //intArray[1] = 1;
        //intArray[2] = 1;
        //intArray[3] = 1;
        //intArray[4] = 1;

        //위와 같음
        //Array.Fill<int>(intArray, 1);


        //for (int i = 0; i < intArray.Length; i++)
        //{
        //    print(intArray[i]);
        //}



        // 위와 같음
        //foreach (int someInt in publicIntArray)
        //{
        //    print(someInt);
        //}


        //intList.Add(0);
        //intList.Add(1);
        //intList.Add(2);
        //intList.Add(3);
        //intList.Add(4);

        //foreach (int someInt in intList)
        //{
        //    print(someInt);
        //}

        //print(intList[4]);

        //foreach (GameObject obj in gameObjects)
        //{
        //    print(obj.name);
        //}

        // 얘는 인스펙터에서 사용하기 힘들기 때문에 유니티에선 활용성이 떨어져 잘 사용하지 않음
        // ArrayList는 List와 같은 형태로 활용할 수 있지만 데이터의 자료형으르 제한하지 않으며, 기본적으로 Boxing되어 할당됨
        //arrayList.Add(1);
        //arrayList.Add(1f);
        //arrayList.Add(new GameObject("내가 만든 객체"));
        //arrayList.Add(new ArrayList());

        //foreach (object element in arrayList)
        //{
        //    print(element);
        //}

        //print((arrayList[2] as GameObject).name);

        //dictionary.Add("cube", cube);
        //dictionary.Add("sphere", sphere);
        //dictionary.Add("cylinder", cylinder);
        //dictionary.Add("capsule", capsule);

        //// 리스트 참조
        //print(intList[0]);

        //// 딕셔너리 참조
        //dictionary["capsule"].GetComponent<Renderer>().material.color = Color.red;
        //dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        //dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.gray;
        //dictionary["cube"].GetComponent<Renderer>().material.color = Color.green;

        //hashtable.Add("a", 1);
        //hashtable.Add(3f, new GameObject());

        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        print(intStack.Pop());  //1
        print(intStack.Pop());  //2
        print(intStack.Pop());  //3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop());  //7
        print(intStack.Pop());  //6
        print(intStack.Pop());  //4
        print(intStack.Pop());  //5


        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
    }
}
