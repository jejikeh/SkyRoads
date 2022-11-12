// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Game/Planet"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_Color1 ("Second Color", Color) = (1,1,1,0)
		_Color2 ("Third Color", Color) = (1,1,1,0)
		_Color3 ("Emissive Color", Color) = (1,1,1,0)
		_RimColor ("Rim Color", Color) = (0.5, 0.5, 1.0, 1)
		_Falloff ("Rim Falloff", Range(0.1, 5.0)) = 3.0
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Detail ("Detail (RGB)", 2D) = "gray" {}
	}

	SubShader
	{
		LOD 200
		Tags { "RenderType" = "Opaque" }

CGPROGRAM
#pragma surface surf Lambert vertex:vert

sampler2D _MainTex;
sampler2D _Detail;
fixed4 _Color;
fixed4 _Color1;
fixed4 _Color2;
fixed4 _Color3;
fixed4 _RimColor;
float _Falloff;

struct Input
{
	float2 uv_MainTex;	// Automatically picked up by Unity based on "MainTex"
	float2 uv_Detail;	// Automatically picked up by Unity based on "Detail"
	float3 worldView;
	float3 worldNormal;	// Built-in, automatically written to if not overwritten
};

void vert (inout appdata_full v, out Input o)
{
	UNITY_INITIALIZE_OUTPUT(Input, o);
	float4 pos = mul( unity_ObjectToWorld, v.vertex );
	float3 worldPos = pos.xyz / pos.w;
	o.worldView = worldPos - _WorldSpaceCameraPos;
}

void surf (Input IN, inout SurfaceOutput o)
{
	fixed4 mask = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 detail = tex2D(_Detail, IN.uv_Detail);
	
	fixed4 c = _Color;
	c.rgb = lerp(c.rgb, _Color1.rgb, mask.g * _Color1.a);
	c.rgb = lerp(c.rgb, _Color2.rgb, mask.b * _Color2.a);
	c.rgb *= detail.rgb * (1.25 * mask.r);

	float3 worldNormal = normalize(IN.worldNormal);
	float3 worldView = normalize(IN.worldView);

	// The farther from the matching (inverse) dot product the more it should be affected by the rim color
	float tint = 1.0 + min(0.0, dot(worldNormal, worldView));
	tint = pow(tint, _Falloff) * _RimColor.a;

	o.Albedo = lerp(c.rgb, _RimColor.rgb, tint);
	o.Alpha = c.a;
	o.Emission = _Color3.rgb * (_Color3.a * mask.a * mask.r * 1.25);
}
ENDCG
	}
	Fallback "Game/Planet (Lower Quality)"
}