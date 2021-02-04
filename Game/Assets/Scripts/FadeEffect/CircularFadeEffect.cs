// code based on: http://forum.unity3d.com/threads/circular-fade-in-out-shader.344816/
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CircularFadeEffect : MonoBehaviour
{
    [SerializeField]
    private Shader shader;
    [SerializeField]
    private Color fadeColor;
    [SerializeField]
    [Range(0, 1.0f)]
    private float minFadeRadius;
    [SerializeField]
    [Range(0, 1.0f)]
    private float maxFadeRadius;

    [SerializeField]
    private Transform target;

    private const float fadeTimer = 5f;

    private bool toFadeOut = true;
    private Vector2 fadeCenter;
    private float fadeRadius = 0; // gos from 0 to 1
    private float clockTimer = 0;

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

        clockTimer = fadeTimer;
        fadeRadius = maxFadeRadius;

    }

    void Update()
    {
        Vector3 targetVPPos = cam.WorldToViewportPoint(target.transform.position);
        fadeCenter.x = targetVPPos.x;
        fadeCenter.y = targetVPPos.y;

        UpdateFadeAnim();
    }

    private void UpdateFadeAnim()
    {
        if (toFadeOut)
        {
            clockTimer -= Time.deltaTime;

            if (clockTimer <= 0)
            {
                clockTimer = 0;
                toFadeOut = false;
            }
            fadeRadius = NumberConvert(clockTimer, 0, fadeTimer, minFadeRadius, maxFadeRadius);
        }
        else
        {
            clockTimer += Time.deltaTime;
            if (clockTimer >= fadeTimer)
            {
                clockTimer = fadeTimer;
                toFadeOut = true;
            }
            fadeRadius = NumberConvert(clockTimer, 0, fadeTimer, minFadeRadius, maxFadeRadius);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!enabled)
        {
            Graphics.Blit(source, destination);
            return;
        }

        ShaderMaterial.SetTexture("_MainTex", source);
        ShaderMaterial.SetColor("_FadeColor", fadeColor);
        ShaderMaterial.SetVector("_FadeCenter", fadeCenter);
        ShaderMaterial.SetFloat("_FadeRadius", fadeRadius);

        Graphics.Blit(source, destination, ShaderMaterial);
    }

    void OnDisable()
    {
        if (ShaderMaterial)
        {
            DestroyImmediate(ShaderMaterial);
        }
    }

    private float NumberConvert(float toConvert,
        float minOldScale, float maxOldScale,
        float minNewScale, float maxNewScale)
    {
        return ((((toConvert - minOldScale) * (maxNewScale - minNewScale)) / 
            (maxOldScale - minOldScale)) + minNewScale);
    }
}
