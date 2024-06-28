Shader "Custom/TestSurfaceShader"
{
    Properties // 이 셰이더에서 사용할 변수 선언
    {   //_변수명 ([Inspector 에서 표시될 이름], 자료형) = [초기값 할당] 라인의 끝에선 ; 대신 줄바꿈으로 구분
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Main Texture", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
        _colorAmount ("Color Amount" , Range(0,1)) = 1
        OverlabTex("Overlab Texture", 2D) = "gray" {}


    }
    SubShader
    {
        // materail에 있는 렌더링 모드의 값을 지정해주는 코드
        Tags { "RenderType"= "Opaque" }
        LOD 200 // Level Of Detail. 묘사 단계 뒤에 있는 숫자는 ID임. 유니티 매뉴얼 보면 나옴. 200은 Diffuse Level
        // 위는 유니티에서만 쓰이는 규격

        CGPROGRAM
        // C for graphics 문법이 사용된 영역
        // Physically based Standard lighting model, and enable shadows on all light types
        
        #pragma surface surf Lambert
        //#pragma surface surf Standard fullforwardshadows
        // surface인 surf를 선언할거고 아규먼트로 fullforwardshadows를 사용하겠다는 뜻 아래에도 surf로 써야함
        //#pragma vertex vert     // 정점 셰이딩 라이브러리 함수를 사용하겠다.
        //#pragma fragment frag   // 픽셀 셰이딩 라이브러리 함수를 사용하겠다.




        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex; // 위에서 선언한 그대로 사용해야 함
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            float2 uv_MainTex;  //uv 매핑을 적용한 _MainTex 색 정보
            float2 uvOverlabTex;
            float4 screenPos;
        };

        //half _Glossiness;
        //half _Metallic;
        //fixed4 _Color;

        //_Time : float4, 즉 4차원의 값으로 제공이 되는데.
        // x : t/20 , y: t  z: t*2 w: t*3

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;    //uv_MainTex도 _MainTex가 바뀌면 바꾸어줘야 함
            //o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c.a;

            //  표면 셰이더에 텍스쳐 색을 적용
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;

            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb; 

            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10,5);
            o.Albedo *= tex2D(OverlabTex, screenUV + _Time.y).rgb;
        }
        ENDCG
    }
    // subshader에서 오류가 발생하면 무조건 Fallback으로 이동
    // 위에부터 실행하는데 하나가 실행되면 그 밑에는 실행 안함
    FallBack "Standard"
}
