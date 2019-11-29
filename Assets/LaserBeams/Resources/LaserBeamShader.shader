Shader "TrickStorm/LaserBeamShader" 
{
	Properties
	{
		[PerRendererData]_Color("Color", Color) = (1,1,1,1)
	}

		SubShader
	{

		Tags
	{
		"RenderType" = "Transparent"
		"Queue" = "Transparent"
	}
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert alpha

		fixed4 _Color;

	struct Input {
		float4 color : COLOR;
	};

	void surf(Input IN, inout SurfaceOutput o)
	{
		o.Albedo = _Color.rgb;
		o.Emission = _Color.rgb;
		o.Alpha = _Color.a;
	}
	ENDCG
	}
}
