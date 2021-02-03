// code based on: http://forum.unity3d.com/threads/circular-fade-in-out-shader.344816/
using UnityEngine;

//[RequireComponent(typeof(Camera))]
public class ScreenTransitionImageEffect : MonoBehaviour
{
    [SerializeField]
    private Shader shader;
    [SerializeField]
    private Texture2D maskTexture;
    [SerializeField]
    private Color maskColor;
    [SerializeField]
    private bool maskInvert;
    [SerializeField]
    [Range(0,1.0f)]
    private float maskValue;

    private Material shaderMaterial;

    private Material ShaderMaterial
    {
        get
        {
            if (shaderMaterial == null)
            {
                shaderMaterial = new Material(shader);
                shaderMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return shaderMaterial;
        }
    }

    void Start()
    {
        if (shader == null || !shader.isSupported)
        {
            enabled = false;
        }
    }

    
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!enabled)
        {
            Graphics.Blit(source, destination);
            return;
        }

        ShaderMaterial.SetColor("_MaskColor", maskColor);
        ShaderMaterial.SetFloat("_MaskValue", maskValue);
        ShaderMaterial.SetTexture("_MainTex", source);
        ShaderMaterial.SetTexture("_MaskTex", maskTexture);

        if (ShaderMaterial.IsKeywordEnabled("INVERT_MASK") != maskInvert)
        {
            if (maskInvert)
                ShaderMaterial.EnableKeyword("INVERT_MASK");
            else
                ShaderMaterial.DisableKeyword("INVERT_MASK");
        }

        Graphics.Blit(source, destination, ShaderMaterial);
    }

    void OnDisable()
    {
        if (ShaderMaterial)
        {
            DestroyImmediate(ShaderMaterial);
        }
    }
}
