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
                float4 vertex : SV_POSITION;
                float size : PSIZE;
            };
            
            StructuredBuffer<float3> AttractorPointsBufferShader;

            v2f vert (uint VertexID : SV_VertexID)
            {
                v2f o;
                float3 pos = AttractorPointsBufferShader[VertexID].xyz;
                
                float4 worldPos = float4(pos.xyz,1.0f);
                
                o.vertex = UnityObjectToClipPos(worldPos);
                
                
                o.size = 10;
                
                
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
