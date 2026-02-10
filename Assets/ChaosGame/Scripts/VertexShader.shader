Shader "Custom/VertexShader"
{
    Properties
    {

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Cull Off
        ZWrite On

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct meshdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float size : PSIZE;
            };
            
            StructuredBuffer<float4> AttractorPointsBufferShader;

            v2f vert (meshdata v, uint instanceID : SV_VertexID)
            {
                v2f o;
                float3 localpos = v.vertex.xyz;
                float4 worldpos = float4(AttractorPointsBufferShader[instanceID].xyz + localpos,1.0f);
                o.vertex = UnityObjectToClipPos(worldpos);
                o.uv = v.uv;
                o.size = 100;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                return fixed4(1,0,0,1);
            }
            ENDCG
        }
    }
}
