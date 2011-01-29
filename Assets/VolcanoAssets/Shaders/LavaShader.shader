Shader "GUI/Reveal _Alpha"

{
Properties {
    _Color ("Main Color", Color) = (1,1,1,0.5)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    _Mask ("Mix Mask (A)", 2D) = "white" {}
}
SubShader {
//  ZWrite Off
//    Alphatest Greater 0
    Tags {Queue=Transparent}
    Lighting Off Cull Off ZTest Always ZWrite Off Fog { Mode Off }

    Blend SrcAlpha OneMinusSrcAlpha 
    Pass {
//    Lighting On
       
        Material {
            Diffuse [_Color]
//      Ambient [_Color]
//      Emission [_PPLAmbient]
        }
        SetTexture [_MainTex] {
            constantColor [_Color]
            combine texture * constant, texture * constant
        }
        SetTexture [_Mask] {
            combine previous, texture
        }
        SetTexture [_MainTex] {
            combine previous * texture
        }
    }
}

FallBack " VertexLit", 1

}
