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
            // i 변수만 참조할 경우, 모둔 루프가 종료될 때까지 값이 바뀌기 때문에
            // 해당 루프에서의 i값을 Stack에 별도로 캡쳐하기 위해 변수 1개를 사용함

            // 이렇게 스택에 값을 뺴두지 않으면
            // 참조 시에 루프문의 마지막 i 값을 참조해 온다
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
        //toggles의 동작을 동적으로 할당하기 위해
        //toggles.Addlistener 호출

    }

    public void OnToggleValueChange(int index)
    {
        print($"Toggle {index} is ON");
    }

}
