using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    private bool active = false;
    public Image mainFlag;
    public Sprite English, Chiness, Spanish,Thai;
    public TextMeshProUGUI titleText,descriptionText,playButtonText,optionButtonText,ExitButtonText;
    private LocalizedString title;
    private LocalizedString description;
    private LocalizedString buttonPlay,buttonOption,buttonExit;
    void Start()
    {
        title        = new LocalizedString { TableReference = "Tables1", TableEntryReference = "content" };
        description  = new LocalizedString { TableReference = "Tables1", TableEntryReference = "description" };
        buttonPlay   = new LocalizedString { TableReference = "Tables1", TableEntryReference = "buttonPlay" };
        buttonOption = new LocalizedString { TableReference = "Tables1", TableEntryReference = "buttonOption" };
        buttonExit   = new LocalizedString { TableReference = "Tables1", TableEntryReference = "buttonExit" };
        UpdateLocalizedTexts();
    }
    public void ChangeLocale(int value)
    {
        if (active) return;
        StartCoroutine(SetLocale(value));

        if (value == 0)
        {
            mainFlag.sprite = Chiness;
        }
        else if (value == 1)
        {
            mainFlag.sprite = English;
        }
        else if (value == 3)
        {
            mainFlag.sprite = Spanish;
        }
        else if (value == 4)
        {
            mainFlag.sprite = Thai;
        }
    }
    IEnumerator SetLocale(int _localID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localID];
        UpdateLocalizedTexts();
        active = false;
    }
    void UpdateLocalizedTexts()
    {
        title.GetLocalizedStringAsync().Completed += handle =>
        {
            titleText.text = handle.Result;
        };
        description.GetLocalizedStringAsync().Completed += handle =>
        {
            descriptionText.text = handle.Result;
        };
        buttonPlay.GetLocalizedStringAsync().Completed += handle =>
        {
            playButtonText.text = handle.Result;
        };
        buttonOption.GetLocalizedStringAsync().Completed += handle =>
        {
            optionButtonText.text = handle.Result;
        };
        buttonExit.GetLocalizedStringAsync().Completed += handle =>
        {
            ExitButtonText.text = handle.Result;
        };
    }
}
