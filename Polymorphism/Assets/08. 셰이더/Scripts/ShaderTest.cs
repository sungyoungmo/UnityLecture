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
        // ��ΰ� ���ÿ� �Ȱ��� ���� ����ϸ� ���̴����� �ٲ㵵 ������µ�
        // ��ü���� �ٸ� ���� ������ �ϸ� �̷��� �ٲ�� ��
        render.material.SetFloat("_colorAmount",colorAmount);

        // ���̴� �׷����� �ؽ��� ����Ϸ���
        //render.material.SetColor("_MainTex", Color.white);
    }
}
