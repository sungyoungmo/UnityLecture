using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    //���� ���� ���� (�÷���)
    // �����͸� ���� ������ ����� �� �ִ� Ŭ������ ����
    // 1. �迭
    // 2. ����Ʈ(��� ����Ʈ)
    // 3. ��ųʸ�(�ؽ����̺�)
    // 4. ���� / ť


    #region �迭

    // ������ �迭�� �����Ѵ�.
    private int[] intArray = new int[5]; 
    // �⺻������ �迭�� ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ null ����

    private int someInt; // int�� ���ͷ� Ÿ���̶� �ʱⰪ �Ҵ��� ���� �ʾƴ� �⺻���� �Ҵ� ��


    // �̹� �ν����Ϳ��� �����س��� ���� reset ��ư�� ���� �ٽ� �ʱ�ȭ ����  
    public int[] publicIntArray = new int[10];

    // �̷��� ����� reset�ÿ� ������ 10�� �ƴ� 15���� ����
    private void Reset()
    {
        // ���� ������ �ʱⰪ �Ҵ� ���� ��, ȣ���
        publicIntArray = new int[15];
    }
    #endregion



    #region ����Ʈ

    // �迭�� ����� ����� �Ѵ�.
    // ���������� ũ�� ������ ����
    //��� �� ���� ����� �����ϴ� �Լ��� ���ԵǴ� Ŭ����

    private List<int> intList = new List<int>();

    public List<int> publicList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    #endregion

    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    // ����Ʈ�� ���������� Ž���ؾ��ϱ� ������ �ð����⵵�� �ö�
    // ��ųʸ��� Ű�� �̿��� ���� Ű�� ¦���� ���� Ž���� �� ��������� �ð����⵵�� ���� ��
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();


    //                                  ���������
    // �迭 :                 �������⵵ (����) �ð����⵵(����)
    // ��ųʸ�(�ؽ� ���̺�) : �������⵵ (����) �ð����⵵(����)
    // �� ���� �迭���� 2���� ���� ���⵵ ���

    // �̰� ������� ��ųʸ��� ���������.
    // Ű�� �ڷ����� �������� �ʱ� ������ �� ������ �ʰ� ���� ��ųʸ��� ���� ����Ѵ�.
    private Hashtable hashtable = new Hashtable();

    // �ν����Ϳ����� Ȱ�� �Ұ���
    public Dictionary<string, GameObject> publicDictionary;

    #endregion

    // ������Ƽ
    private int a;

    int A { get { return a; } set { a = value; } }
    // �Ʒ��� a_1�� �����ϰ� ����� ���� ��

    // ĸ��ȭ
    private int a_1;

    // setter �޼���
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("�߸��� ���� �ԷµǾ����ϴ�.");
            a_1 = 100;
        }
        else
        {
            a_1 = value;
        }
    }
    // getter �޼ҵ�
    public int GetA_1()
    {
        return a_1;
    }


    #region ���� / ť

    // ����
    private Stack<int> intStack = new Stack<int>();

    // ť
    private Queue<int> intQueue = new Queue<int>();

    #endregion


    private void Start()
    {
        //intArray[0] = 1;
        //intArray[1] = 1;
        //intArray[2] = 1;
        //intArray[3] = 1;
        //intArray[4] = 1;

        //���� ����
        //Array.Fill<int>(intArray, 1);


        //for (int i = 0; i < intArray.Length; i++)
        //{
        //    print(intArray[i]);
        //}



        // ���� ����
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

        // ��� �ν����Ϳ��� ����ϱ� ����� ������ ����Ƽ���� Ȱ�뼺�� ������ �� ������� ����
        // ArrayList�� List�� ���� ���·� Ȱ���� �� ������ �������� �ڷ������� �������� ������, �⺻������ Boxing�Ǿ� �Ҵ��
        //arrayList.Add(1);
        //arrayList.Add(1f);
        //arrayList.Add(new GameObject("���� ���� ��ü"));
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

        //// ����Ʈ ����
        //print(intList[0]);

        //// ��ųʸ� ����
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
