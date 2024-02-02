Shader "Custom/SparkleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" { }
        _Color ("Color", Color) = (1,1,1,1)
        _Speed ("Speed", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // vị trí của shader code
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            uniform float _Speed;
            uniform float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : COLOR
            {
                fixed4 col = tex2D(_MainTex, i.pos.xy / i.pos.w);
                col.rgb *= _Color.rgb;
                
                // Tính toán giá trị lấp lánh dựa trên thời gian
                float sparkle = frac(_Time.y * _Speed);

                // Áp dụng lấp lánh lên mỗi pixel
                col.rgb += sparkle;

                return col;
            }
            ENDCG
        }
    }
}
