using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGenericTest : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    SafeArray<int> sa = new SafeArray<int>(3);
    SafeArray<string> saS = new SafeArray<string>(5);


    private void Awake()
    {
        // CubeFrom의 colors, xPositions, scales 배열을 각각 복사하고 싶음

        cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
        cubeTo.xPosition = ArrayCopy<int>(cubeFrom.xPosition);
        cubeTo.scales = ArrayCopy(cubeFrom.scales);

    }

    private void Start()
    {
        sa[1] = 2;
        saS[1] = "hel";
    }

    //Color[] ArrayCopy(Color[] from)
    //{
    //    Color[] to = new Color[from.Length];
    //    for (int i = 0; i < from.Length; i++)
    //    {
    //        to[i] = from[i];
    //    }
    //    return to;
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(sa[5]);

            //int a = sa[5];
            string a = saS[5];
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //sa[5] = 3;
            saS[5] = "hello";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(sa[1]);
            Debug.Log(saS[1]);
            
        }
    }


    T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];
        for (int i = 0; i < from.Length; i++)
        {
            to[i] = from[i];
        }
        return to;
    }

}

/*
    제네릭 활용은 크게 2가지
1. 제네릭을 사용하여 정의된 클래스를 자료형으로 사용 또는 함수를 호출
예시  ) List<int> : List라는 클래스를 사용하는데, 안에서 취급될 자료형은 int
에시2 ) GetComponent<T>() : 게임 오브젝트에 부착된 컴포넌트를 찾는데, T 클래스의 컴포넌트를 찾는다.

2. 직접 제네릭을 사용한 클래스 또는 함수를 정의

 
*/

public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>();
    public Dictionary<int, int> intDictionary = new Dictionary<int, int>();
    

    private void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

        //StructT<Vector3> a;
        //ClassT<GameObject> b;
        //NewT<object> c;
        //ParentT<Parent> d;  // Parent나 Child 클래스 사용해야 함
        //InterFaceT<string> e;
        //MultiT<Vector3, Parent, object> f;

        
    }

    
}


class NoneDefaultConstructorClass 
{
    public NoneDefaultConstructorClass(int a) { }
}


class Parent { }
class Child : Parent { }

class SafeArray<T>
{
    private T[] arr;


    public SafeArray(int length)
    {
        arr = new T[length];
    }
    
    public T this[int index]
    {
        get
        {
            if (index < arr.Length && index >= 0)
            {
                return arr[index];
            }
            else
            {
                Debug.LogWarning("return error");

                return default(T);
            }
        }
        set
        {
            if (index < arr.Length && index >= 0)
            {
                arr[index] = value;
            }
            else
            {
                Debug.LogWarning("set error");
            }
        }
    }

}



// 클래스에서 사용하는 제네릭 자료형의 제약사항을 명시할 수 있다.

class StructT<T> where T : struct { }   // 1. 구조체만 가능하게 하려 할 경우

class ClassT<T> where T : class { }     // 2. 클래스만 가능하게 

class NewT<T> where T : new() { }       // 3. 파라미터가 없는 기본 생성자를 정의한 클래스만 가능하게
                                        // 추상 클래스는 안되기 때문에 추상 클래스도 제약한다

class ParentT<T> where T : Parent { }   // 4. Parent 클래스를 상속한 클래스만 가능하게

class InterFaceT<T> where T : IComparable { }   // 5. IComparable 인터페이스를 구현한 클래스만 가능하게

class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { } // 6. 여러개 구현하고 싶다면 이렇게 사용하면 된다.