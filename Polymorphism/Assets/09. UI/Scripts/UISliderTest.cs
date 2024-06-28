using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UISliderTest : MonoBehaviour
{
    // 슬라이더의 value 값 참조
    public void OnSliderValueChange(float value)
    {

        transform.localScale = Vector3.one * value;
    }
}
