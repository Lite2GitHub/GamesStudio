Shader "Custom/Diffuse Emissive"
{
	Properties{
	_Color("Main Color", Color) = (1,1,1,1)
	_MainTex("Base (RGB)", 2D) = "white" {}
	_EmissionStrength("Emission Strength", float) = 0
	_EmissionColor("Emission Color", Color) = (0,0,0)
	_EmissionMap("Emission Mask", 2D) = "white" {}
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

		CGPROGRAM
		#pragma surface surf Lambert

		float _EmissionStrength;

		sampler2D _MainTex;
		fixed4 _Color;

		sampler2D _EmissionMap;
		fixed4 _EmissionColor;

		struct Input {
			float2 uv_MainTex;
			float2 uv_EmissionMap;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Emission = c.rgb * tex2D(_EmissionMap, IN.uv_EmissionMap).a * (_EmissionStrength * _EmissionColor);
		}
		ENDCG
	}

		Fallback "Legacy Shaders/VertexLit"
}
