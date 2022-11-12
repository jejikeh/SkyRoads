Shader "Game/Planet (Lower Quality)"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_Color1 ("Second Color", Color) = (1,1,1,0)
		_Color2 ("Third Color", Color) = (1,1,1,0)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader
	{
		LOD 100
		Tags { "RenderType" = "Opaque" }

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;
fixed4 _Color1;
fixed4 _Color2;

struct Input
{
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o)
{
	fixed4 mask = tex2D(_MainTex, IN.uv_MainTex);
	
	fixed4 c = _Color;
	c.rgb = lerp(c.rgb, _Color1.rgb, mask.g * _Color1.a);
	c.rgb = lerp(c.rgb, _Color2.rgb, mask.b * _Color2.a);
	c.rgb *= mask.r;

	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
	}
	Fallback Off
}