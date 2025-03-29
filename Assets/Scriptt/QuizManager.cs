using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public Question[] questions;
    private int currentQuestionIndex = 0;
    private int score = 0;

    [Header("UI References")]
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public Button answer1Button;
    public Button answer2Button;

    void Start()
    {
        // Initialize questions
        questions = new Question[2];
        
        // Question 1
        questions[0] = new Question();
        questions[0].questionText = "What is the capital of Thailand?";
        questions[0].answers = new string[] { "Bangkok", "Chiang Mai" };
        questions[0].correctAnswerIndex = 0;
        
        // Question 2
        questions[1] = new Question();
        questions[1].questionText = "What color is the sky on a clear day?";
        questions[1].answers = new string[] { "Blue", "Green" };
        questions[1].correctAnswerIndex = 0;

        // Set up button listeners
        answer1Button.onClick.AddListener(() => CheckAnswer(0));
        answer2Button.onClick.AddListener(() => CheckAnswer(1));

        // Show first question
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex].questionText;
            answer1Button.GetComponentInChildren<TMP_Text>().text = questions[currentQuestionIndex].answers[0];
            answer2Button.GetComponentInChildren<TMP_Text>().text = questions[currentQuestionIndex].answers[1];
        }
        else
        {
            // Quiz finished
            questionText.text = "Quiz Complete!";
            answer1Button.gameObject.SetActive(false);
            answer2Button.gameObject.SetActive(false);
        }
    }

    void CheckAnswer(int answerIndex)
    {
        if (answerIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score++;
            scoreText.text = "Score: " + score;
        }

        currentQuestionIndex++;
        ShowQuestion();
    }
}