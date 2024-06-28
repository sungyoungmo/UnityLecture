Shader "Custom/TestSurfaceShader"
{
    Properties // �� ���̴����� ����� ���� ����
    {   //_������ ([Inspector ���� ǥ�õ� �̸�], �ڷ���) = [�ʱⰪ �Ҵ�] ������ ������ ; ��� �ٹٲ����� ����
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Main Texture", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
        _colorAmount ("Color Amount" , Range(0,1)) = 1
        OverlabTex("Overlab Texture", 2D) = "gray" {}


    }
    SubShader
    {
        // materail�� �ִ� ������ ����� ���� �������ִ� �ڵ�
        Tags { "RenderType"= "Opaque" }
        LOD 200 // Level Of Detail. ���� �ܰ� �ڿ� �ִ� ���ڴ� ID��. ����Ƽ �Ŵ��� ���� ����. 200�� Diffuse Level
        // ���� ����Ƽ������ ���̴� �԰�

        CGPROGRAM
        // C for graphics ������ ���� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        
        #pragma surface surf Lambert
        //#pragma surface surf Standard fullforwardshadows
        // surface�� surf�� �����ҰŰ� �ƱԸ�Ʈ�� fullforwardshadows�� ����ϰڴٴ� �� �Ʒ����� surf�� �����
        //#pragma vertex vert     // ���� ���̵� ���̺귯�� �Լ��� ����ϰڴ�.
        //#pragma fragment frag   // �ȼ� ���̵� ���̺귯�� �Լ��� ����ϰڴ�.




        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex; // ������ ������ �״�� ����ؾ� ��
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            float2 uv_MainTex;  //uv ������ ������ _MainTex �� ����
            float2 uvOverlabTex;
            float4 screenPos;
        };

        //half _Glossiness;
        //half _Metallic;
        //fixed4 _Color;

        //_Time : float4, �� 4������ ������ ������ �Ǵµ�.
        // x : t/20 , y: t  z: t*2 w: t*3

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;    //uv_MainTex�� _MainTex�� �ٲ�� �ٲپ���� ��
            //o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;

            //  ǥ�� ���̴��� �ؽ��� ���� ����
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;

            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb; 

            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10,5);
            o.Albedo *= tex2D(OverlabTex, screenUV + _Time.y).rgb;
        }
        ENDCG
    }
    // subshader���� ������ �߻��ϸ� ������ Fallback���� �̵�
    // �������� �����ϴµ� �ϳ��� ����Ǹ� �� �ؿ��� ���� ����
    FallBack "Standard"
}
