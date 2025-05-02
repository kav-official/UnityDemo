using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StartAction : MonoBehaviour
{
    public Image _mainBall,_childBalls;
    public Sprite _spriteRed,_spriteBlue,_spriteGreen,_spritePink;
    public PathOrder _helpPathOrder;
    public RandomNumber _helprandomNumbers;
    public Button buttonStartGame,buttonDestroy,buttonBuy;
    public TextMeshProUGUI textMainBall,textBallNumber;
    public GameObject _ballPrefab,_starPrefab;
    public Transform _itemContent,_startStarPosition;
    public float moveDuration = 0.3f;
    public float spawnDelay = 0f; //0.1f
    public Transform _startSpawnPoint;
    public List<Transform> centerPoints;
    public List<Transform> ballPoints;
    private List<int> ballNumbers;
    public List<Transform> startTargets;
    private List<GameObject> _spawnBalls = new List<GameObject>();
    private List<GameObject> _spawnStar = new List<GameObject>();
    private int currentStarIndex = 0;
    private bool isStartGame = false;
    int starCount = 0;
    void Start()
    {
        PathOrder.BuildPathOrder();

        buttonDestroy.onClick.AddListener(DestroyPrefab); 
        buttonStartGame.onClick.AddListener(StartSpawn);
    }

    public void StartSpawn()
    {
        StartCoroutine(spawnBalls());
        isStartGame = !isStartGame;

        IEnumerator spawnBalls()
        {
            ballNumbers         = RandomNumber.GenerateRandomNumbers(30, 1, 99);
            int centerRowIndex  = 0;

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

                // yield return StartCoroutine(MoveBall(ballRT, centerRT.anchoredPosition, targetRT.anchoredPosition, moveDuration));
                // IEnumerator MoveBall(RectTransform ball, Vector2 center, Vector2 target, float duration)
                // {
                //     bool centerDone = false;
                //     LeanTween.move(ball, center, duration).setEase(LeanTweenType.easeOutBack).setOnComplete(() => centerDone = true);
                //     yield return new WaitUntil(() => centerDone);

                //     bool targetDone = false;
                //     LeanTween.move(ball, target, duration).setEase(LeanTweenType.easeOutBack).setOnComplete(() => targetDone = true);
                //     yield return new WaitUntil(() => targetDone);
                // }

                LeanTween.move(ballRT, centerRT.anchoredPosition, moveDuration)
                    .setEase(LeanTweenType.easeOutBack)
                    .setOnComplete(() =>
                    {
                        LeanTween.move(ballRT, targetRT.anchoredPosition, moveDuration)
                            .setEase(LeanTweenType.easeOutBack);
                    });

                textBallNumber = newBall.GetComponentInChildren<TextMeshProUGUI>();
                _childBalls = newBall.GetComponentInChildren<Image>();

                if (ballNumbers[i] <= 20)
                {
                    _childBalls.sprite = _spriteRed;
                }
                else if (ballNumbers[i] <= 35)
                {
                    _childBalls.sprite = _spriteBlue;
                }
                else if (ballNumbers[i] <= 59)
                {
                    _childBalls.sprite = _spriteGreen;
                }
                else
                {
                    _childBalls.sprite = _spritePink;
                }

                if (textBallNumber != null && i < ballNumbers.Count)
                {
                    textBallNumber.text = ballNumbers[i].ToString();
                    textMainBall.text = ballNumbers[i].ToString();
                    _mainBall.sprite = _childBalls.sprite;

                    if (ballNumbers[i] == 15 || ballNumbers[i] == 10 || ballNumbers[i] == 11)
                    {
                        Debug.Log("🎯 Number 20 found! Pausing for 2 seconds...");
                        yield return new WaitForSeconds(2f);
                        yield return StartCoroutine(SpawnFallingStar());
                        Debug.Log("Star::" + starCount);
                    }
                }
  
                buttonStartGame.interactable = false;
                yield return new WaitForSeconds(spawnDelay);
                buttonStartGame.interactable = false;
                buttonBuy.alpha = 1;
            }
        }
    }

    IEnumerator SpawnFallingStar()
    {
        if(currentStarIndex >= startTargets.Count) yield break;

        GameObject star = Instantiate(_starPrefab);
        _spawnStar.Add(star);
        starCount = _spawnStar.Count;

        star.transform.SetParent(_startStarPosition.parent, false);
        RectTransform  starRT = star.GetComponent<RectTransform>();

        starRT.anchoredPosition = _startStarPosition.GetComponent<RectTransform>().anchoredPosition;
        Vector2 tratgetPos      = startTargets[currentStarIndex].GetComponent<RectTransform>().anchoredPosition;

        LeanTween.move(starRT, tratgetPos, 0.7f).setEase(LeanTweenType.easeInQuad);

        currentStarIndex++;
        
        yield return new WaitForSeconds(1);
    }
    void DestroyPrefab()
    {
        foreach (GameObject ball in _spawnBalls)
        {
            Destroy(ball);
        }
       
        foreach (GameObject star in _spawnStar)
        {
            Destroy(star);
        }
        _spawnBalls.Clear();
        _spawnStar.Clear();
        currentStarIndex=0;
        buttonStartGame.interactable = true;
    }
}
