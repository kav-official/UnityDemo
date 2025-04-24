using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class RPSManager : MonoBehaviour
{
    public Image imagePlayerChoice, imageComputerChoice;
    public TextMeshProUGUI textPlayer;
    public GameObject _RPSobject, _WinObject, _LoseObject, _DrawObject;
    public CanvasGroup canvasGroup;
    public Sprite Rock, Paper, Scinssor, spriteQuestion;
    private string playerHand = "";
    private string computer = "";
    private string[] RandomHand = { "Rock", "Paper", "Scinssor" };

    void Awake()
    {
        string playerName = PlayerPrefs.GetString("player", "NONE");
        textPlayer.text = playerName;
    }
    public void onClickSetHand(int value)
    {
        if (value == 1)
        {
            imagePlayerChoice.sprite = Rock;
            playerHand = "Rock";
        }
        if (value == 2)
        {
            imagePlayerChoice.sprite = Paper;
            playerHand = "Paper";
        }
        if (value == 3)
        {
            imagePlayerChoice.sprite = Scinssor;
            playerHand = "Scinssor";
        }
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
            imageComputerChoice.sprite = Rock;
        }
        else if (computer == "Paper")
        {
            imageComputerChoice.sprite = Paper;
        }
        else
        {
            imageComputerChoice.sprite = Scinssor;
        }


        if (playerHand == computer)
        {
            StartCoroutine(playerDraw());
        }
        else if (
            (playerHand == "Rock" && computer == "Scinssor") ||
            (playerHand == "Paper" && computer == "Rock") ||
            (playerHand == "Scinssor" && computer == "Paper")
        )
        {
           StartCoroutine(playerWin());
        }
        else
        {
            StartCoroutine(playerLose());
        }
    }

    IEnumerator playerDraw()
    {
        _DrawObject.SetActive(true);
        _RPSobject.SetActive(false);
        yield return new WaitForSeconds(3);
        _DrawObject.SetActive(false);
    }
    IEnumerator playerWin()
    {
        _WinObject.SetActive(true);
        _RPSobject.SetActive(false);
        yield return new WaitForSeconds(3);
        _WinObject.SetActive(false);
    }
    IEnumerator playerLose()
    {
        _LoseObject.SetActive(true);
        _RPSobject.SetActive(false);
        yield return new WaitForSeconds(3);
        _LoseObject.SetActive(false);
    }
}
