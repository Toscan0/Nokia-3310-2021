using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField]
    private ScreenTransitionByMaskEffect transitionEffect;
    [SerializeField]
    private Animator canvasAnimator;

    private float animDuration = 1f;
    private int indexToLoad;

    private Animator transitinEffectAnimator;

    private void Awake()
    {
        transitinEffectAnimator = transitionEffect.gameObject.GetComponent<Animator>();

        PlayerCollisionManager.OnFlyPickedUp += LoadNextScene;
    }

    internal void LoadNextScene()
    {
        indexToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        transitinEffectAnimator.SetTrigger("FadeOut");
        if (canvasAnimator != null)
        {
            canvasAnimator.SetTrigger("FadeOut");
        }

        StartCoroutine(LoadSceneByIndex(indexToLoad, animDuration));
    }

    private IEnumerator LoadSceneByIndex(int i, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(i);
    }

    private void OnDestroy()
    {
        PlayerCollisionManager.OnFlyPickedUp -= LoadNextScene;
    }
}
