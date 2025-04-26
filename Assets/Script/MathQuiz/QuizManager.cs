using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI textTimeCountDown,resultCorrect,resultMiss;
    public TMP_InputField playerAnswer;
    public Transform _itemContent;
    public GameObject _itemPrefab;
    public CanvasGroup canvasAlert,canvasResult;
    public TextMeshProUGUI textQuizs, textQuizCounter, textplayerScore, textAlert;
    public Button nextButton;
    private Coroutine countDownCoroutine;
    private float timeRemaining;
    public int currentIndex = 0;
    public int quizCounter = 0;
    public int playerAnswerInput;
    public int playerScore = 0;

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

        nextButton.onClick.AddListener(onClickNextQuiz);
        showQuiz();

        countDownCoroutine = StartCoroutine(StartCountDown());
    }
    void Update()
    {
        if (currentIndex == 10 || timeRemaining <= 0)
        {return;}
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
        canvasResult.alpha = 1;
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
        int correctCore = 0;
        int missScore = 0;

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
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("1 + 1", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("1 + 1", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 1)
            {
                if (playerAnswerInput == 5)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("2 + 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("2 + 3", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 2)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("5 - 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("5 - 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }

            else if (currentIndex == 3)
            {
                if (playerAnswerInput == 9)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("3 + 6", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("3 + 6", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 4)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("7 - 4", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("7 - 4", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 5)
            {
                if (playerAnswerInput == 9)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("10 - 1", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("10 - 1", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 6)
            {
                if (playerAnswerInput == 6)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("2 * 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("2 * 3", playerAnswerInput, currentIndex + 1, "red");
                }
            }
            else if (currentIndex == 7)
            {
                if (playerAnswerInput == 3)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("6 / 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("6 / 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 8)
            {
                if (playerAnswerInput == 10)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("8 + 2", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("8 + 2", playerAnswerInput, currentIndex + 1, "red");
                }

            }
            else if (currentIndex == 9)
            {
                if (playerAnswerInput == 7)
                {
                    playerScore = playerScore + 1;
                    correctCore = correctCore + 1;
                    createPrefabList("9 - 3", playerAnswerInput, currentIndex + 1, "green");
                }
                else
                {
                    missScore = missScore + 1;
                    createPrefabList("9 - 3", playerAnswerInput, currentIndex + 1, "red");
                }
            }

            currentIndex++;
            quizCounter++;
            showQuiz();
            textQuizCounter.text = quizCounter.ToString();
            textplayerScore.text = playerScore.ToString();
            resultCorrect.text   = correctCore.ToString();
            resultMiss.text      = missScore.ToString();
        }
        else
        {
            StartCoroutine(showAlertMessage());
            textAlert.text = "Game Over";
            textQuizs.text = "Game Over";
            playerAnswer.text = "";
            canvasResult.alpha = 1;
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
}
