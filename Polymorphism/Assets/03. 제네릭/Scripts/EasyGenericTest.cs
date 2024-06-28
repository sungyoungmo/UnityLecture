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
        // CubeFrom�� colors, xPositions, scales �迭�� ���� �����ϰ� ����

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
    ���׸� Ȱ���� ũ�� 2����
1. ���׸��� ����Ͽ� ���ǵ� Ŭ������ �ڷ������� ��� �Ǵ� �Լ��� ȣ��
����  ) List<int> : List��� Ŭ������ ����ϴµ�, �ȿ��� ��޵� �ڷ����� int
����2 ) GetComponent<T>() : ���� ������Ʈ�� ������ ������Ʈ�� ã�µ�, T Ŭ������ ������Ʈ�� ã�´�.

2. ���� ���׸��� ����� Ŭ���� �Ǵ� �Լ��� ����

 
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
        //ParentT<Parent> d;  // Parent�� Child Ŭ���� ����ؾ� ��
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



// Ŭ�������� ����ϴ� ���׸� �ڷ����� ��������� ����� �� �ִ�.

class StructT<T> where T : struct { }   // 1. ����ü�� �����ϰ� �Ϸ� �� ���

class ClassT<T> where T : class { }     // 2. Ŭ������ �����ϰ� 

class NewT<T> where T : new() { }       // 3. �Ķ���Ͱ� ���� �⺻ �����ڸ� ������ Ŭ������ �����ϰ�
                                        // �߻� Ŭ������ �ȵǱ� ������ �߻� Ŭ������ �����Ѵ�

class ParentT<T> where T : Parent { }   // 4. Parent Ŭ������ ����� Ŭ������ �����ϰ�

class InterFaceT<T> where T : IComparable { }   // 5. IComparable �������̽��� ������ Ŭ������ �����ϰ�

class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { } // 6. ������ �����ϰ� �ʹٸ� �̷��� ����ϸ� �ȴ�.