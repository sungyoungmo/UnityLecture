using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;

    
    [Range(0,1)]
    public float colorAmount;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        // 모두가 동시에 똑같은 색을 사용하면 셰이더에서 바꿔도 상관없는데
        // 개체마다 다른 색을 가져야 하면 이렇게 바꿔야 함
        render.material.SetFloat("_colorAmount",colorAmount);

        // 셰이더 그래프의 텍스쳐 사용하려면
        //render.material.SetColor("_MainTex", Color.white);
    }
}
