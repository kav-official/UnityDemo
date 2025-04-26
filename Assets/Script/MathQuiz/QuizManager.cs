using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI textTimeCountDown;
    public TMP_InputField playerAnswer;
    public CanvasGroup canvasAlert;
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
        if (currentIndex == 9 || timeRemaining <= 0)
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

            if (currentIndex == 0 && playerAnswerInput == 2)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 1 && playerAnswerInput == 5)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 2 && playerAnswerInput == 3)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 3 && playerAnswerInput == 9)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 4 && playerAnswerInput == 3)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 5 && playerAnswerInput == 9)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 6 && playerAnswerInput == 6)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 7 && playerAnswerInput == 3)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 8 && playerAnswerInput == 10)
            {
                playerScore = playerScore + 1;
            }
            else if (currentIndex == 9 && playerAnswerInput == 7)
            {
                playerScore = playerScore + 1;
            }

            currentIndex++;
            quizCounter++;
            showQuiz();
            textQuizCounter.text = quizCounter.ToString();
            textplayerScore.text = playerScore.ToString();
        }
        else
        {
            StartCoroutine(showAlertMessage());
            textAlert.text = "Game Over";
            textQuizs.text = "Game Over";
            playerAnswer.text = "";
            nextButton.interactable = false;
        }
    }
    IEnumerator showAlertMessage()
    {
        canvasAlert.alpha = 1;
        yield return new WaitForSeconds(1);
        canvasAlert.alpha = 0;
    }
}
