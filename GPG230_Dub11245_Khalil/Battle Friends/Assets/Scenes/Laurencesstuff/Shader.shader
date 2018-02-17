Shader "New/Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	    _SecondTex("Texture2", 2D) = "white" {}
		//_LerpVal("Transition float", Range(0,1)) = 0.5
		_ColorTint("Tint", Color) = (1,0.5,1,1) 
	    _CharicterPosition("Object pos" , Vector) = (0,0,0,0)
	}
	SubShader
	{ //tags = dictionary to set some values rendertype = which order the shader will render
		Tags { "RenderType"="Opaque" }
		//afer a 100 meters it will not render
		LOD 100
       
		Pass
		{ //cg language
			CGPROGRAM
			//functions
			#pragma vertex vert
			#pragma fragment frag
			
			//pre-computes (method) e.g 3d coordinate to screen coordinate
			#include "UnityCG.cginc"

			struct appdata
			{
			//basically a vector 4
			//stores the position of the vertex
				float4 vertex : POSITION;
		    //the normal of the vertex
				float3 normal : NORMAL;
		    //the UV coords for the vertex
				float2 uv : TEXCOORD0;
			//used to blend up more than 1 texture
				float4 colour : COLOR;
			};

		//vert to frag (vertex to pixel)
		//runs first
			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			//reflection of propities
			sampler2D _MainTex;
			sampler2D _SecondTex;
			//contains the texture scale
			float4 _MainTex_ST;
			sampler2D _SecondTex_ST;
			//float _LerpVal;
			float4 _Tint;
			
			//takes care of all the vertex. 
			// this will be called 8 times per frame 
			//position the vertex in the 3d world
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}

			
			// pixel shader
			//for every single pixel in screen that will be rendered
			//light pixel in the correct colour
			// runs second takes the return from above for lighing 
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = lerp(tex2D (_MainTex, i.uv), tex2D(_SecondTex, i.uv), /*_LerpVal*/ _SinTime.w);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
