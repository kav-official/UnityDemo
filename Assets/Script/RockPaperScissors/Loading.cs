using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Loading : MonoBehaviour
{
    public Slider slider;
    private float duration = 3f;
    public TextMeshProUGUI loaderPercent;
    void Start()
    {
        StartCoroutine(SliderProcess());
    }
    IEnumerator SliderProcess()
    {
        float elapsed = 0f;
        float startValue = slider.minValue;
        float endValue = slider.maxValue;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float currentValue = Mathf.Lerp(startValue, endValue, t);
            slider.value = currentValue;

            float percent = currentValue / endValue * 100f;
            loaderPercent.text = Mathf.RoundToInt(percent).ToString() + "%";
            yield return null;
        }
        slider.value = endValue;
        loaderPercent.text = "100%";
        SceneManager.LoadScene("main");
    }
}
