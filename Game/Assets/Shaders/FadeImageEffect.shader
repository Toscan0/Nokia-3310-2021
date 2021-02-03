// code based on: http://forum.unity3d.com/threads/circular-fade-in-out-shader.344816/

Shader "Hidden/FadeImageEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture", 2D) = "white" {}
		_FadeRadius("Fade Radius", Range(0,1)) = 0.1
		_FadeSoftness("_Fade Softness", Range(0,1)) = 0
		_FadeCenter("Fade Center", vector) = (1, 1, 0, 0)
		_MaskColor ("Mask Color", Color) = (0,0,0,1)
		[Toggle(INVERT_MASK)] _INVERT_MASK ("Mask Invert", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag		
			#include "UnityCG.cginc"

			#pragma shader_feature INVERT_MASK

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv     : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv     : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

			#if UNITY_UV_STARTS_AT_TOP
				o.uv.y = 1 - o.uv.y;
			#endif

				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _MaskTex;
			float4 _MaskColor;
			float2 _FadeCenter;
			float _FadeRadius;
			float _FadeSoftness;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				//    Calculate the pixel coordinates of the current point relative to the mask center.
				fixed2 relative = (i.uv - _FadeCenter.xy) * _ScreenParams.xy;
				//  Normalize to the longest screen dimension.
				relative /= max(_ScreenParams.x, _ScreenParams.y);

				//    The mask is opaque if further than _FadeRadius from the center.
				fixed transparency = clamp((_FadeRadius - length(relative)) / _FadeSoftness, 0, 1);
				col.rgb = lerp(_MaskColor.rgb, col.rgb, smoothstep(0, 1, transparency));

				return col;
			}
			ENDCG
		}
	}
}
