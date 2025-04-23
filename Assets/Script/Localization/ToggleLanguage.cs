using UnityEngine;
using UnityEngine.UI;
public class ToggleLanguage : MonoBehaviour
{
    public RectTransform target;
    public Vector2 hiddenOffset = new Vector2(500f, 0f); 
    public float duration = 0.5f;
    private Vector2 shownPos;
    private Vector2 hiddenPos;
    private bool isShown = false;
    void Start()
    {
        shownPos = target.anchoredPosition;                       
        hiddenPos = shownPos + hiddenOffset;                      
        target.gameObject.SetActive(false);                   
    }

    public void TogglePanel()
    {
        if (!isShown)
        {
            target.anchoredPosition = hiddenPos;
            target.gameObject.SetActive(true);
            LeanTween.move(target, shownPos, duration)
                     .setEase(LeanTweenType.easeOutExpo);
            isShown = true;
        }
        else
        {
            LeanTween.move(target, hiddenPos, duration)
                     .setEase(LeanTweenType.easeInExpo)
                     .setOnComplete(() => target.gameObject.SetActive(false));
            isShown = false;
        }
    }
}
