// code based on: http://forum.unity3d.com/threads/circular-fade-in-out-shader.344816/
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Screen Transition")]
public class ScreenTransitionImageEffect : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Shader shader;
    [SerializeField]
    private Texture2D maskTexture;
    [SerializeField]
    private Color maskColor;
    [SerializeField]
    private bool maskInvert;
    [SerializeField] [Range(0, 1.0f)]
    private float fadeRadius;

    private Vector2 fadeCenter;
    private Camera cam;
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
        cam = GetComponent<Camera>();

        if (shader == null || !shader.isSupported)
        {
            enabled = false;
        }
    }

    void Update()
    {

        Vector3 targetVPPos = cam.WorldToViewportPoint(target.position);
        fadeCenter.x = targetVPPos.x;
        fadeCenter.y = targetVPPos.y;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!enabled)
        {
            Graphics.Blit(source, destination);
            return;
        }

        ShaderMaterial.SetColor("_MaskColor", maskColor);
        ShaderMaterial.SetTexture("_MainTex", source);
        ShaderMaterial.SetTexture("_MaskTex", maskTexture);
        ShaderMaterial.SetVector("_FadeCenter", fadeCenter);
        ShaderMaterial.SetFloat("_FadeRadius", fadeRadius);

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
