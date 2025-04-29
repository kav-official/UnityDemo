using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI textTimeCountDown, resultCorrect, resultMiss;
    public TMP_InputField playerAnswer;
    public Transform _itemContent;
    public GameObject _itemPrefab;
    public CanvasGroup canvasAlert, canvasResult,canvasLoadResult;
    public TextMeshProUGUI textQuizs, textQuizCounter, textplayerScore, textAlert;
    public Button nextButton, buttonExitResult;
    private Coroutine countDownCoroutine;
    private float timeRemaining;
    public int currentIndex = 0;
    public int quizCounter = 0;
    public int playerAnswerInput;
    public int playerScore = 0;
    int correctScore = 0;
    int missScore = 0;

    [SerializeField]
    private List<string> quizs = new List<string> {"1 + 1", "2 + 3", "5 - 2", "3 + 6", "7 - 4",
    "10 - 1", "2 * 3", "6 / 2", "8 + 2", "9 - 3"};
    public void onFocuse()
    {
        playerAnswer.Select();
        playerAnswer.ActivateInputField();
    }
    void Start()
    {
        onFocuse();

        canvasAlert.alpha = 0;

        playerAnswer.contentType = TMP_InputField.ContentType.IntegerNumber;
        playerAnswer.ForceLabelUpdate();

        buttonExitResult.onClick.AddListener(() => canvasResult.alpha = 0);

        nextButton.onClick.AddListener(onClickNextQuiz);
        showQuiz();

        countDownCoroutine = StartCoroutine(StartCountDown());
    }
    void Update()
    {
        if (currentIndex == 10 || timeRemaining <= 0)
        { return; }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                onClickNextQuiz();
                onFocuse();
                playerAnswer.text = "";
            }
        }
    }
    IEnumerator StartCountDown()
    {
        timeRemaining = 15f;
        while (timeRemaining > 0)
        {
            textTimeCountDown.text = Mathf.Ceil(timeRemaining).ToString();
            timeRemaining -= Time.deltaTime;
            yield return null;
        }
        nextButton.interactable = false;
        StartCoroutine(showAlertMessage());
        StartCoroutine(showResullt());
        textAlert.text = "Time's Over";
    }
    void showQuiz()
    {
        if (currentIndex < quizs.Count)
        {
            textQuizs.text = quizs[currentIndex];
        }
        else
        {
            textQuizs.text = "Game Over";
            nextButton.interactable = false;
        }
    }
    void onClickNextQuiz()
    {


        if (currentIndex < quizs.Count - 1)
        {
            if (countDownCoroutine != null)
            {
                StopCoroutine(countDownCoroutine);
            }
            countDownCoroutine = StartCoroutine(StartCountDown());

            if (int.TryParse(playerAnswer.text, out playerAnswerInput))
            {
                playerAnswerInput = playerAnswerInput;
            }

            if (currentIndex == 0)
            {
                if (playerAnswerInput == 2)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("1 + 1", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("1 + 1", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 1)
            {
                if (playerAnswerInput == 5)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("2 + 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("2 + 3", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 2)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("5 - 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("5 - 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }

            else if (currentIndex == 3)
            {
                if (playerAnswerInput == 9)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("3 + 6", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("3 + 6", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 4)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("7 - 4", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("7 - 4", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 5)
            {
                if (playerAnswerInput == 9)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("10 - 1", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("10 - 1", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 6)
            {
                if (playerAnswerInput == 6)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("2 * 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("2 * 3", playerAnswerInput, currentIndex + 1, "red");
                }
            }
            else if (currentIndex == 7)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("6 / 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("6 / 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 8)
            {
                if (playerAnswerInput == 10)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("8 + 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("8 + 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 9)
            {
                if (playerAnswerInput == 7)
                {
                    playerScore += 1;
                    correctScore += 1;
                    createPrefabList("9 - 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore += 1;
                    createPrefabList("9 - 3", playerAnswerInput, currentIndex + 1, "red");
                }
            }

            currentIndex++;
            quizCounter++;
            showQuiz();
            textQuizCounter.text = quizCounter.ToString();
            textplayerScore.text = playerScore.ToString();

            resultCorrect.text = correctScore.ToString();
            resultMiss.text = missScore.ToString();
        }
        else
        {
            // StartCoroutine(showAlertMessage());
            StartCoroutine(showResullt());
            textAlert.text = "Game Over";
            textQuizs.text = "Game Over";
            playerAnswer.text = "";
            nextButton.interactable = false;
        }
    }


    public void createPrefabList(string quiz, int answer, int index, string colors)
    {
        GameObject newItem = Instantiate(_itemPrefab, _itemContent);

        Image _background = newItem.transform.Find("Background").GetComponent<Image>();
        TextMeshProUGUI _alertQuiz = newItem.transform.Find("LabelQuiz/textQuiz").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _alertAnswer = newItem.transform.Find("LabelAnswer/textAswer").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _alertIndex = newItem.transform.Find("textList").GetComponent<TextMeshProUGUI>();

        _alertQuiz.text = quiz;
        _alertAnswer.text = answer.ToString();
        _alertIndex.text = index.ToString();

        Color color = Color.green;
        if (ColorUtility.TryParseHtmlString(colors, out color))
        {
            _background.color = color;
        }
    }
    IEnumerator showAlertMessage()
    {
        canvasAlert.alpha = 1;
        yield return new WaitForSeconds(1);
        canvasAlert.alpha = 0;
    }

    IEnumerator showResullt()
    {
        canvasLoadResult.alpha = 1;
        yield return new WaitForSeconds(2);
        canvasLoadResult.alpha = 0;
        canvasResult.alpha = 1;
    }
    public void ResetGame()
    {
        playerScore = 0;
        correctScore = 0;
        missScore = 0;
        currentIndex = 0;
        quizCounter = 1;

        textQuizCounter.text = quizCounter.ToString();
        textplayerScore.text = playerScore.ToString();
        resultCorrect.text = correctScore.ToString();
        resultMiss.text = missScore.ToString();

        playerAnswer.text = "";
        textQuizs.text = "";

        onFocuse();
        showQuiz();

        nextButton.interactable = true;

        canvasResult.alpha = 0;

         // Reset Prefab 
        foreach (Transform child in _itemContent)
        {
            Destroy(child.gameObject);
        }

        if (countDownCoroutine != null)
        {
            StopCoroutine(countDownCoroutine);
        }
        countDownCoroutine = StartCoroutine(StartCountDown());
    }

}
