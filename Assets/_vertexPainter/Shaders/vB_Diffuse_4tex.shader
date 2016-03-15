  Shader "vertexPainter/vB_Diffuse_4tex" {

	Properties {
		_Color 				("Main Color", Color) = (1,1,1,1)
		_MainTex1 			("Texture 1 (RGB)", 2D) = "white" {}
		_MainTex2 			("Texture 2 (RGB)", 2D) = "white" {}	
		_MainTex3 			("Texture 3 (RGB)", 2D) = "white" {}	 
		_MainTex4 			("Texture 4 (RGB)", 2D) = "white" {}
	}

	SubShader {
		
	  Tags { "RenderType" = "Opaque" }
	  LOD 150
	  CGPROGRAM
	  #pragma surface surf Lambert noforwardadd 
	  
		struct Input {
		  
			float2 uv_MainTex1 		: TEXCOORD0;
			float2 uv_MainTex2 		: TEXCOORD1;   
			float2 uv_MainTex3 		: TEXCOORD2;    
			float2 uv_MainTex4 		: TEXCOORD3;
			
			float4 color			: COLOR;
			
		};
	

		uniform sampler2D _MainTex1, _MainTex2, _MainTex3, _MainTex4;
	  
		fixed4 _Color;

	  
		void surf (Input IN, inout SurfaceOutput o) {
			
			fixed4 col  = tex2D( _MainTex1,		IN.uv_MainTex1)*IN.color.r;
			col 		+= tex2D( _MainTex2,	IN.uv_MainTex2)*IN.color.g;	   
			col 		+= tex2D( _MainTex3,	IN.uv_MainTex3)*IN.color.b;	     
			col 		+= tex2D( _MainTex4,	IN.uv_MainTex4)*IN.color.a;

			o.Albedo = col;

		}
	  
	  ENDCG

	} 

FallBack "Diffuse"
  }
