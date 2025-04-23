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
    public TextMeshProUGUI titleText;
    private LocalizedString localizedTitle;
    // private LocalizedString localizedDescription;
    // private LocalizedString localizedPlayButton;
    void Start()
    {
        localizedTitle = new LocalizedString { TableReference = "Tables1", TableEntryReference = "content" };
        // localizedDescription = new LocalizedString { TableReference = "FirstLanguage", TableEntryReference = "description" };
        // localizedPlayButton = new LocalizedString { TableReference = "FirstLanguage", TableEntryReference = "play_button" };
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
        localizedTitle.GetLocalizedStringAsync().Completed += handle =>
        {
            titleText.text = handle.Result;
        };
        // localizedDescription.GetLocalizedStringAsync().Completed += handle =>
        // {
        //     descriptionText.text = handle.Result;
        // };
        // localizedPlayButton.GetLocalizedStringAsync().Completed += handle =>
        // {
        //     playButtonText.text = handle.Result;
        // };
    }
}
