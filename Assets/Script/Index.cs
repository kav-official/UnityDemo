using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Index : MonoBehaviour
{
    public Button ButtonCaculator;
    public Button ButtonLocalization;
    public Button ButtonMathQuiz;
    public Button ButtonWestHunterBingo;
    public Button ButtonRockPaperScissors;
    void Start()
    {
        ButtonCaculator.onClick.AddListener(()=>SceneLoader("Calculator"));
        ButtonLocalization.onClick.AddListener(()=>SceneLoader("Localization"));
        ButtonMathQuiz.onClick.AddListener(()=>SceneLoader("MathMain"));
        ButtonWestHunterBingo.onClick.AddListener(()=>SceneLoader("MainWesthunter"));
        ButtonRockPaperScissors.onClick.AddListener(()=>SceneLoader("Login"));
    }
    void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
