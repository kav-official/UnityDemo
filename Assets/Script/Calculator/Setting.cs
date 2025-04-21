using UnityEngine;
using UnityEngine.UI;
public class SlideToggleActive : MonoBehaviour
{
    public RectTransform target;
    public Vector2 hiddenOffset = new Vector2(-200f, 0f);  // ขยับซ้ายเท่านี้ตอนซ่อน
    public float duration = 0.5f;
    private Vector2 shownPos;
    private Vector2 hiddenPos;
    private bool isShown = false;
    void Start()
    {
        shownPos = target.anchoredPosition;                         // เก็บตำแหน่งปัจจุบันเป็นจุดโชว์
        hiddenPos = shownPos + hiddenOffset;                        // ซ่อนไปทางซ้ายจากตำแหน่งปัจจุบัน
        target.gameObject.SetActive(false);                         // เริ่มต้นซ่อน
    }

    public void TogglePanel()
    {
        if (!isShown)
        {
            target.anchoredPosition = hiddenPos;                    // เริ่มจากตำแหน่งซ่อน
            target.gameObject.SetActive(true);                      // เปิดก่อน
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
