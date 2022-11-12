// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge Beta 0.25 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.25;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:2,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-2-RGB,spec-8-RGB,normal-14-RGB,emission-26-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33096,y:32638,ptlb:MainTex,tex:a2acd5db4b23dcc4d8e37abba17649af,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8,x:33131,y:32848,ptlb:SpecTex,tex:fa6721dc812dae74cbe3fbb47529c3f6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:14,x:33110,y:33047,ptlb:NormalTex,tex:587f00226871d634699b3ed679a02e36,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:20,x:33121,y:33240,ptlb:EmissionTex,tex:a014c1d3d536d744492f5f77ab827480,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:26,x:32845,y:33303|A-20-RGB,B-27-OUT;n:type:ShaderForge.SFN_Sin,id:27,x:33035,y:33429|IN-29-TTR;n:type:ShaderForge.SFN_Time,id:29,x:33273,y:33429;proporder:2-8-14-20;pass:END;sub:END;*/

Shader "Jelly Button Games/Road" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _SpecTex ("SpecTex", 2D) = "white" {}
        _NormalTex ("NormalTex", 2D) = "bump" {}
        _EmissionTex ("EmissionTex", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _SpecTex; uniform float4 _SpecTex_ST;
            uniform sampler2D _NormalTex; uniform float4 _NormalTex_ST;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_43 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalTex,TRANSFORM_TEX(node_43.rg, _NormalTex))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.xyz;
////// Emissive:
                float4 node_29 = _Time + _TimeEditor;
                float3 emissive = (tex2D(_EmissionTex,TRANSFORM_TEX(node_43.rg, _EmissionTex)).rgb*sin(node_29.a));
///////// Gloss:
                float gloss = exp2(0.5*10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = tex2D(_SpecTex,TRANSFORM_TEX(node_43.rg, _SpecTex)).rgb;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),gloss) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * tex2D(_MainTex,TRANSFORM_TEX(node_43.rg, _MainTex)).rgb;
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _SpecTex; uniform float4 _SpecTex_ST;
            uniform sampler2D _NormalTex; uniform float4 _NormalTex_ST;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_44 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_NormalTex,TRANSFORM_TEX(node_44.rg, _NormalTex))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = exp2(0.5*10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = tex2D(_SpecTex,TRANSFORM_TEX(node_44.rg, _SpecTex)).rgb;
                float3 specular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),gloss) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * tex2D(_MainTex,TRANSFORM_TEX(node_44.rg, _MainTex)).rgb;
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
