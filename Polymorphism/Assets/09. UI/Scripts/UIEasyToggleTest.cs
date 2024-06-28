using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEasyToggleTest : MonoBehaviour
{
    public Color changeColor;

    public Image targetImage;


    // �� �Լ��� toggle�� on Value Change �̺�Ʈ�� ȣ���� �̴ϴ�.
    public void OnToggleValueChange(bool isOn)
    {
        if (isOn)
        {
            targetImage.color = changeColor;

            print($"{name} toggle is on");
        }
        else
        {
            print($"{name} toggle is off");
        }
    }
}
