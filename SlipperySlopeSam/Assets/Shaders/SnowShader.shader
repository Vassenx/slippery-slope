Shader "Custom/SnowShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_SnowDir("Snow Direction", Vector) = (0, 1, 0)
		_SnowDepth("Snow Depth", Range(1,-1)) = 0
		_SnowColor("Snow Color", Color) = (1,1,1,1)
		_Transparency("Transparency", Range(0.0,1)) = 0.25
	}
	SubShader {
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		LOD 200

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed _SnowDepth;
		half3 _SnowDir;
		half4 _SnowColor;
		float _Transparency;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			half4 tex = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = tex.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;

			tex.a = _Transparency;
			//o.Alpha = tex.a;
			

			if (dot(WorldNormalVector(IN, o.Normal), _SnowDir) >= _SnowDepth)
			{
				o.Albedo = _SnowColor.rgb;
				o.Alpha = 1;
			}
			//transparent
			else
			{}

		}
		ENDCG
	}
	FallBack "Diffuse"
}
