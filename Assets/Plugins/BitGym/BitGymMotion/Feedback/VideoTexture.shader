Shader "VideoTexture" {
	Properties {
		_MainTex ("Base (RGB)", 2D) =  "white" {}
	}
	
	SubShader {
		Tags { "RenderType" = "Opaque" }
		Pass {
			Lighting Off
			SeparateSpecular Off
			SetTexture [_MainTex] { combine texture }
		}
	}
	
	Fallback "VertexLit", 1
}
