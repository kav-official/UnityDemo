using UnityEngine;
using UnityEngine.UI;

public class OptiontogglleNumber : MonoBehaviour
{
    public Button _buttonDecrease;
    public Button _buttonIncrease;
    public Text _textResult;
    private float number = 1;
    private void Start()
    {
        if(_buttonDecrease == null)
            _buttonDecrease  = GameObject.Find("buttonMinus").GetComponent<Button>();
            number = number-1;
        if(_buttonIncrease == null)
            _buttonIncrease = GameObject.Find("buttonAdd").GetComponent<Button>();
            number = number+1;

        _buttonIncrease.onClick.AddListener(onClickshowValue);
    }

    public void onClickshowValue()
    {
        Debug.Log(number);
    }
}
