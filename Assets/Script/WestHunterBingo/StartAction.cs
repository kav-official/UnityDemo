using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StartAction : MonoBehaviour
{
    public Image _mainBall, _ballBall;
    public Sprite _spriteRed,_spriteBlue,_spriteGreen,_spritePink;
    public PathOrder _helpPathOrder;
    public RandomNumber _helprandomNumbers;
    public Button buttonStartGame,buttonDestroy;
    public TextMeshProUGUI textBallNumber;
    public GameObject _ballPrefab;
    public Transform _itemContent;
    public float moveDuration = 0.3f;
    public float spawnDelay = 0.1f;
    public Transform _startSpawnPoint;
    public List<Transform> centerPoints;
    public List<Transform> ballPoints;
    private List<int> ballNumbers;
    private List<GameObject> _spawnBalls = new List<GameObject>();
    private bool isStartGame = false;

    void Start()
    {
        ballNumbers = RandomNumber.GenerateRandomNumbers(30, 1, 99);
        PathOrder.BuildPathOrder();

        buttonDestroy.onClick.AddListener(DestroyPrefab); 
        buttonStartGame.onClick.AddListener(StartSpawn);
    }

    public void StartSpawn()
    {
        StartCoroutine(spawnBalls());
        isStartGame = !isStartGame;

        // DestroyPrefab();

        IEnumerator spawnBalls()
        {
            int centerRowIndex = 0;

            for (int j = 0; j < PathOrder.Orders.Count; j++)
            {
                int i = PathOrder.Orders[j];
                if (i >= 23) centerRowIndex = 1;
                else centerRowIndex = 0;

                GameObject newBall = Instantiate(_ballPrefab);
                newBall.transform.SetParent(ballPoints[i].parent, false);
                _spawnBalls.Add(newBall);

                RectTransform ballRT = newBall.GetComponent<RectTransform>();
                RectTransform startRT = _startSpawnPoint.GetComponent<RectTransform>();
                RectTransform centerRT = centerPoints[centerRowIndex].GetComponent<RectTransform>();
                RectTransform targetRT = ballPoints[i].GetComponent<RectTransform>();

                ballRT.anchoredPosition = startRT.anchoredPosition;

                LeanTween.move(ballRT, centerRT.anchoredPosition, moveDuration)
                    .setEase(LeanTweenType.easeOutBack)
                    .setOnComplete(() =>
                    {
                        LeanTween.move(ballRT, targetRT.anchoredPosition, moveDuration)
                            .setEase(LeanTweenType.easeOutBack);
                    });

                TextMeshProUGUI textBallNumber = newBall.GetComponentInChildren<TextMeshProUGUI>();
                if (textBallNumber != null && i < ballNumbers.Count)

                    textBallNumber.text = ballNumbers[i].ToString();
                buttonStartGame.interactable = false;
                yield return new WaitForSeconds(spawnDelay);
                buttonStartGame.interactable = false;
            }
        }
    }

    void DestroyPrefab()
    {
        foreach (GameObject ball in _spawnBalls)
        {
            Destroy(ball);
        }
        _spawnBalls.Clear();
        buttonStartGame.interactable = true;
    }
}
