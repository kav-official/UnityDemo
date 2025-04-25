using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class RPSManager : MonoBehaviour
{
    public Image imagePlayerChoice, imageComputerChoice;
    public TextMeshProUGUI textPlayer,textScoreDraw,textScoreWin,textScoreLose;
    public GameObject _itemPrefab,_RPSobject, _WinObject, _LoseObject, _DrawObject,_buttonStartObject;
    public Transform contentParent;
    public CanvasGroup canvasGroup, messageCanvasGroup;
    public Sprite Rock, Paper, Scinssor, spriteQuestion,playerSpritePrefab,computerSpritePrefab;
    private string playerHand = "";
    private string computer = "";
    private string[] RandomHand = { "Rock", "Paper", "Scinssor" };
    int countDraw = 0,countWin=0,countLose=0;
    void Awake()
    {
        string playerName = PlayerPrefs.GetString("player", "NONE");
        textPlayer.text = playerName;
        _buttonStartObject.SetActive(false);
    }
    public void onClickSetHand(int value)
    {
        if (value == 1)
        {
            imagePlayerChoice.sprite  = Rock;
            playerSpritePrefab = Rock;
            playerHand = "Rock";
        }
        if (value == 2)
        {
            imagePlayerChoice.sprite  = Paper;
            playerSpritePrefab = Paper;
            playerHand = "Paper";
        }
        if (value == 3)
        {
            imagePlayerChoice.sprite  = Scinssor;
            playerSpritePrefab = Scinssor;
            playerHand = "Scinssor";
        }
        _buttonStartObject.SetActive(true);
    }
    public void onCLickStartGame()
    {
        StartCoroutine(RollingStart());
    }

    IEnumerator RollingStart()
    {
        computer = RandomHand[Random.Range(0, RandomHand.Length)];
        _RPSobject.SetActive(true);
        canvasGroup.alpha = 1;

        _RPSobject.transform.rotation = Quaternion.identity;

        LeanTween.rotateZ(_RPSobject, 1000f, 2f)
        .setEase(LeanTweenType.easeOutCubic);

        imageComputerChoice.sprite = spriteQuestion;

        yield return new WaitForSeconds(2);

        if (computer == "Rock")
        {
            computerSpritePrefab = Rock;
            imageComputerChoice.sprite = Rock;
        }
        else if (computer == "Paper")
        {
            computerSpritePrefab = Paper;
            imageComputerChoice.sprite = Paper;
        }
        else
        {
            computerSpritePrefab = Scinssor;
            imageComputerChoice.sprite = Scinssor;
        }


        if (playerHand == computer)
        {
            StartCoroutine(playerDraw());
            countDraw++;
        }
        else if (
            (playerHand == "Rock" && computer == "Scinssor") ||
            (playerHand == "Paper" && computer == "Rock") ||
            (playerHand == "Scinssor" && computer == "Paper")
        )
        {
            countWin++;
            StartCoroutine(playerWin());
            Debug.Log("Win " + countWin);
        }
        else
        {
            countLose++;
            StartCoroutine(playerLose());
            Debug.Log("Lose " + countLose);
        }
    }
 
    public void createPrefabList(Sprite PlayerSprite, Sprite ComputerSprite, string textResult)
    {
        GameObject newItem = Instantiate(_itemPrefab, contentParent);

        newItem.transform.SetSiblingIndex(0);

        Image _prefabImagePlayer = newItem.transform.Find("labelPlayer/playerHistorySprite").GetComponent<Image>();
        Image _prefabImageComputer = newItem.transform.Find("labelComputer/computerHistorySprite").GetComponent<Image>();
        TextMeshProUGUI _prefabtextResult = newItem.transform.Find("labelComputer/textHistoryResult").GetComponent<TextMeshProUGUI>();

        _prefabImagePlayer.sprite = PlayerSprite;
        _prefabImageComputer.sprite = ComputerSprite;
        _prefabtextResult.text = textResult;

        Debug.Log("Player Sprite: " + PlayerSprite.name);
        Debug.Log("Computer Sprite: " + ComputerSprite.name);
        Debug.Log("Text Result: " + textResult);
    }

    IEnumerator playerDraw()
    {
        _DrawObject.SetActive(true);
        _RPSobject.SetActive(false);
         _buttonStartObject.SetActive(false);
        yield return new WaitForSeconds(3);
        _DrawObject.SetActive(false);
        textScoreDraw.text = countDraw.ToString();
        createPrefabList(playerSpritePrefab, computerSpritePrefab, "Draw");
    }
    IEnumerator playerWin()
    {
        messageCanvasGroup.alpha = 1;
        messageCanvasGroup.gameObject.SetActive(true);

        _buttonStartObject.SetActive(false);
        _RPSobject.SetActive(false);

        LeanTween.value(canvasGroup.gameObject, 0f, 1f, 1f)
            .setOnUpdate((float val) =>
            {
                canvasGroup.alpha = val;
            })
            .setEase(LeanTweenType.easeInOutQuad);

        yield return new WaitForSeconds(3);
        _WinObject.SetActive(false);
        textScoreWin.text = countWin.ToString();
        createPrefabList(playerSpritePrefab, computerSpritePrefab, "Win");
    }
    IEnumerator playerLose()
    {
        _LoseObject.SetActive(true);
        _RPSobject.SetActive(false);
        _buttonStartObject.SetActive(false);

        yield return new WaitForSeconds(3);
        _LoseObject.SetActive(false);
        textScoreLose.text = countLose.ToString();
        createPrefabList(playerSpritePrefab, computerSpritePrefab, "Lose");
    }
}
