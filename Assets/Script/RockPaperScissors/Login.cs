using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class Login : MonoBehaviour
{
    public GameObject _loginObject, _loadingObject;
    public TMP_InputField playerName;
    public TMP_InputField playerAge;
    public Button buttonLogin;
    public Slider slider;
    private float duration = 3f;
    public TextMeshProUGUI loaderPercent;
    void Start()
    {
        // playerAge.contentType = TMP_InputField.ContentType.IntegerNumber;
        // playerAge.ForceLabelUpdate();
        playerAge.onValueChanged.AddListener(validateNumberInput);

        _loadingObject.SetActive(false);
        buttonLogin.onClick.AddListener(onClickLogin);
    }

    void validateNumberInput(string number)
    {
        string filtered = new string(number.Where(char.IsDigit).ToArray());
        if (filtered.Length > 2)
        {
            filtered = filtered.Substring(0, 2);
        }
        if (filtered != number)
        {
            playerAge.text = filtered;
            playerAge.caretPosition = filtered.Length;
        }
    }

    void onClickLogin()
    {
        string name = playerName.text;
        string age  = playerAge.text;

        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(age))
        {
            PlayerPrefs.SetString("player", name);
            PlayerPrefs.SetString("age", age);
            PlayerPrefs.Save();
            _loadingObject.SetActive(true);
            _loginObject.SetActive(false);
            StartCoroutine(SliderProcess());
        }
        else
        {
            Debug.Log("Pease enter name age");
        }
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
        SceneManager.LoadScene("MainRockPaperScissors");
    }
}
