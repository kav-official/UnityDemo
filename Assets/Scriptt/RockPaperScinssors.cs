using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScinssors : MonoBehaviour
{
   public TextMeshProUGUI textResult;
   public TextMeshProUGUI textYou;
   public TextMeshProUGUI textAI;
   public Image yourImage;
   public Image aiImage;
   public Image resultImage;
   public Sprite winSprite,lostSprite,drawSprite,rockSprite,paperSprite,scinssorsSprite;
   public enum Choice {Rock,Paper,Scinssors};


public void onClickYouChoices(int choice)
    {
        Choice playerChoice = (Choice)choice;
        Choice aiChoice     = (Choice)Random.Range(0,3);
        string result       = DeterMineWiner(playerChoice,aiChoice);
        onUpdateImage(result);
        onUpdateYouImage(playerChoice);
        onUpdateAIImage(aiChoice);
    }

    private string DeterMineWiner(Choice player,Choice ai)
    {
        if(player == ai)
            return "Draw";
        if((player == Choice.Rock && ai == Choice.Scinssors)||(player == Choice.Paper && ai == Choice.Rock)||(player == Choice.Scinssors && ai == Choice.Paper))
            return "Win";
        return "Lose";
    }

    private void onUpdateImage(string result)
    {
        switch (result)
        {
            case "Win": resultImage.sprite = winSprite;
                break;
            case "Lose": resultImage.sprite = lostSprite;
                break;
            case "Draw": resultImage.sprite = drawSprite;
                break;
        }
    }

    private void onUpdateYouImage(Choice choice)
    {
         switch (choice)
            {
                case Choice.Rock: yourImage.sprite = rockSprite; break;
                case Choice.Paper: yourImage.sprite = paperSprite; break;
                case Choice.Scinssors: yourImage.sprite = scinssorsSprite; break;
            }
     }
     private void onUpdateAIImage(Choice choice)
     {
        switch (choice)
        {
            case Choice.Rock: aiImage.sprite = rockSprite;break;
            case Choice.Paper: aiImage.sprite = paperSprite ;break;
            case Choice.Scinssors: aiImage.sprite = scinssorsSprite;break;
          }
    }
}
