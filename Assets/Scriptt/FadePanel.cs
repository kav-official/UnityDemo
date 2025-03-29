using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FadePanel : MonoBehaviour
{
    public CanvasGroup panelCanvasGroup;
    public float fadeDuration = 0.5f;
    private bool isVisible = false;
  
    public void TogglePanels()
    {
        StopAllCoroutines();
        StartCoroutine(FadePanelCoroutine(isVisible ? 0 : 1));
        isVisible = !isVisible;
    }

     IEnumerator FadePanelCoroutine(float targetAlpha)
    {
        float startAlpha = panelCanvasGroup.alpha;
        float time = 0;

        panelCanvasGroup.interactable = true;
        panelCanvasGroup.blocksRaycasts = true;

        while (time < fadeDuration)
        {
            panelCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        panelCanvasGroup.alpha = targetAlpha;
        if (targetAlpha == 0)
        {
            panelCanvasGroup.interactable = false;
            panelCanvasGroup.blocksRaycasts = false;
        }
    }
}
