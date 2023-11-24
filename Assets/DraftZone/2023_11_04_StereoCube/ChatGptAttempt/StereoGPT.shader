Shader "Custom/StereoEyeImage" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}
        _XRTexture0 ("Left Eye Texture", 2D) = "white"
        _XRTexture1 ("Right Eye Texture", 2D) = "white"
    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float2 texcoord : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _XRTexture0;
            sampler2D _XRTexture1;

            v2f vert(appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                if (unity_StereoEyeIndex == 0) {
                    // Left Eye
                    return tex2D(_XRTexture0, i.texcoord);
                } else {
                    // Right Eye
                    return tex2D(_XRTexture1, i.texcoord);
                }
            }
            ENDCG
        }
    }
}
