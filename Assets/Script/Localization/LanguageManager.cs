using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    private bool active = false;

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
