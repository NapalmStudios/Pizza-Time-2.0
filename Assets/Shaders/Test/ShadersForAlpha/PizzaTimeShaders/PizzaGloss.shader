// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-791-OUT,spec-8788-OUT,gloss-128-OUT,normal-5724-OUT,transm-9432-OUT,lwrap-9432-OUT,alpha-9837-OUT,refract-8046-OUT;n:type:ShaderForge.SFN_Color,id:7348,x:32117,y:32506,ptovrint:False,ptlb:color,ptin:_color,varname:node_7348,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:7314,x:32117,y:32648,varname:node_7314,prsc:2;n:type:ShaderForge.SFN_Multiply,id:791,x:32331,y:32565,varname:node_791,prsc:2|A-7348-RGB,B-7314-RGB;n:type:ShaderForge.SFN_Slider,id:128,x:32174,y:32784,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_128,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2393162,max:1;n:type:ShaderForge.SFN_Vector1,id:8788,x:32331,y:32707,varname:node_8788,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9432,x:32550,y:32841,varname:node_9432,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:6872,x:31572,y:32834,ptovrint:False,ptlb:Reflection,ptin:_Reflection,varname:node_6872,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4957265,max:1;n:type:ShaderForge.SFN_Slider,id:2344,x:31587,y:33117,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_2344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3931624,max:1;n:type:ShaderForge.SFN_Vector3,id:5944,x:31729,y:32741,varname:node_5944,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:2516,x:32004,y:32840,varname:node_2516,prsc:2|A-5944-OUT,B-6548-RGB,T-6872-OUT;n:type:ShaderForge.SFN_TexCoord,id:9955,x:31394,y:32938,varname:node_9955,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9382,x:31620,y:32938,varname:node_9382,prsc:2,spu:0.02,spv:0.02|UVIN-9955-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6548,x:31792,y:32938,ptovrint:False,ptlb:RefractionA,ptin:_RefractionA,varname:node_6548,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:3,isnm:True|UVIN-9382-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:4344,x:32004,y:33006,varname:node_4344,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6548-RGB;n:type:ShaderForge.SFN_Multiply,id:8046,x:32224,y:33034,varname:node_8046,prsc:2|A-4344-OUT,B-8960-OUT;n:type:ShaderForge.SFN_Vector1,id:7332,x:31744,y:33185,varname:node_7332,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:8960,x:32004,y:33144,varname:node_8960,prsc:2|A-2344-OUT,B-7332-OUT;n:type:ShaderForge.SFN_Normalize,id:5724,x:32198,y:32866,varname:node_5724,prsc:2|IN-2516-OUT;n:type:ShaderForge.SFN_Slider,id:9837,x:32355,y:32957,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_9837,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1282051,max:1;proporder:7348-128-2344-6548-6872-9837;pass:END;sub:END;*/

Shader "Shader Forge/PizzaGloss" {
    Properties {
        _color ("color", Color) = (1,1,1,1)
        _Gloss ("Gloss", Range(0, 1)) = 0.2393162
        _Distortion ("Distortion", Range(0, 1)) = 0.3931624
        _RefractionA ("RefractionA", 2D) = "bump" {}
        _Reflection ("Reflection", Range(0, 1)) = 0.4957265
        _Opacity ("Opacity", Range(0, 1)) = 0.1282051
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _color;
            uniform float _Gloss;
            uniform float _Reflection;
            uniform float _Distortion;
            uniform sampler2D _RefractionA; uniform float4 _RefractionA_ST;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_6981 = _Time;
                float2 node_9382 = (i.uv0+node_6981.g*float2(0.02,0.02));
                float3 _RefractionA_var = UnpackNormal(tex2D(_RefractionA,TRANSFORM_TEX(node_9382, _RefractionA)));
                float3 normalLocal = normalize(lerp(float3(0,0,1),_RefractionA_var.rgb,_Reflection));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (_RefractionA_var.rgb.rg*(_Distortion*0.2));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_8788 = 0.0;
                float3 specularColor = float3(node_8788,node_8788,node_8788);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float node_9432 = 1.0;
                float3 w = float3(node_9432,node_9432,node_9432)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_9432,node_9432,node_9432);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_color.rgb*i.vertexColor.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,_Opacity),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _color;
            uniform float _Gloss;
            uniform float _Reflection;
            uniform float _Distortion;
            uniform sampler2D _RefractionA; uniform float4 _RefractionA_ST;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9677 = _Time;
                float2 node_9382 = (i.uv0+node_9677.g*float2(0.02,0.02));
                float3 _RefractionA_var = UnpackNormal(tex2D(_RefractionA,TRANSFORM_TEX(node_9382, _RefractionA)));
                float3 normalLocal = normalize(lerp(float3(0,0,1),_RefractionA_var.rgb,_Reflection));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (_RefractionA_var.rgb.rg*(_Distortion*0.2));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_8788 = 0.0;
                float3 specularColor = float3(node_8788,node_8788,node_8788);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float node_9432 = 1.0;
                float3 w = float3(node_9432,node_9432,node_9432)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_9432,node_9432,node_9432);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 diffuseColor = (_color.rgb*i.vertexColor.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * _Opacity,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
