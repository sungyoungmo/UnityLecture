using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UISliderTest : MonoBehaviour
{
    // �����̴��� value �� ����
    public void OnSliderValueChange(float value)
    {

        transform.localScale = Vector3.one * value;
    }
}
