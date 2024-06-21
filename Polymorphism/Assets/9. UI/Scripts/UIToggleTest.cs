using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTest : MonoBehaviour
{
    public Toggle[] toggles;

    private void Awake()
    {
        toggles = GetComponentsInChildren<Toggle>();

        for (int i = 0; i < toggles.Length; i++)
        {
            // i ������ ������ ���, ��� ������ ����� ������ ���� �ٲ�� ������
            // �ش� ���������� i���� Stack�� ������ ĸ���ϱ� ���� ���� 1���� �����

            // �̷��� ���ÿ� ���� ������ ������
            // ���� �ÿ� �������� ������ i ���� ������ �´�
            int index = i + 1;

            toggles[i].onValueChanged.AddListener
                (
                    delegate (bool isOn) 
                    { 
                        if (isOn)
                        {
                            OnToggleValueChange(index);
                        }
                    }
                );

        }
    }

    private void Start()
    {
        //toggles�� ������ �������� �Ҵ��ϱ� ����
        //toggles.Addlistener ȣ��

    }

    public void OnToggleValueChange(int index)
    {
        print($"Toggle {index} is ON");
    }

}
