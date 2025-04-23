using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

public class Calculate : MonoBehaviour
{
    public GameObject messageObject;
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI textProcess;
    private string currentInput = "";
    private string squirRoot = "";
    private string perCent = "";
    public void onClickNumber(string value)
    {
        if (displayText.text == "0" || currentInput == "0")
        {
            currentInput = value;
        }
        else
        {
            currentInput += value;
        }
        displayText.text = currentInput;
    }

    public void onClickOperator(string value)
    {
        if (currentInput.Length < 1)
        {
            currentInput = "";
            StartCoroutine(showMessage());
        }
        else
        {
            currentInput += " " + value + " ";
        }
        displayText.text = currentInput;
    }
    public void onClear()
    {
        currentInput = "";
        displayText.text = "0";
        textProcess.text = "";
    }
    public void onClickBackSpacec()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            displayText.text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
        }
    }

    public void onClickEqual()
    {
        try
        {
            //# Persent
            if (!string.IsNullOrEmpty(perCent))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                if (float.TryParse(currentInput, out float number))
                {
                    number = number / 100f;
                    currentInput = number.ToString();
                }
                displayText.text = currentInput;
                perCent = "";
            }
            //# SquirRoot
            if (!string.IsNullOrEmpty(squirRoot))
            {
                string expression = currentInput;
                expression = expression.Replace("x", "*");

                while (expression.Contains("√"))
                {
                    int sqrIndex = expression.IndexOf("√");
                    int startIndex = sqrIndex + 1;
                    int length = 0;

                    while (startIndex + length < expression.Length &&
                        (char.IsDigit(expression[startIndex + length]) || expression[startIndex + length] == '.'))
                    {
                        length++;
                    }

                    string numberText = expression.Substring(startIndex, length);
                    if (double.TryParse(numberText, out double values))
                    {
                        double sqrResult = Math.Sqrt(values);
                        expression = expression.Replace($"√{numberText}", sqrResult.ToString());
                    }
                    else
                    {
                        displayText.text = "Invalid Number";
                        return;
                    }
                }
                //$ Use Datatable to proccess
                try
                {
                    var results = new DataTable().Compute(expression, null);
                    currentInput = results.ToString();
                    displayText.text = currentInput;
                }
                catch (System.Exception)
                {
                    displayText.text = "Error";
                }
                squirRoot = "";
            }
            //# Normal Calculate
            textProcess.text = currentInput.ToString();
            string result = Evaluate(currentInput);
            if (!string.IsNullOrEmpty(result))
            {
                displayText.text = result;
                currentInput = result;
            }
        }
        catch
        {
            displayText.text = "Some thing wrong";
        }
    }
    private string Evaluate(string expression)
    {
        string[] token = expression.Split(' ');
        if (token.Length < 3) return "";

        float result = float.Parse(token[0]);

        for (int i = 1; i < token.Length - 1; i += 2)
        {
            string op = token[i];
            float nextNumber = float.Parse(token[i + 1]);

            switch (op)
            {
                case "+": result += nextNumber; break;
                case "-": result -= nextNumber; break;
                case "x": result *= nextNumber; break;
                case "/":
                    if (nextNumber == 0) return "Invalid Number";
                    result /= nextNumber;
                    break;
            }
        }
        return result.ToString();
    }
    public void onClickPercent()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (currentInput.Length >= 1)
            {
                if (!currentInput.EndsWith("%"))
                {
                    perCent = "%";
                    currentInput += perCent;
                }
            }
            else
            {
                perCent = "";
            }
        }
        else
        {
            StartCoroutine(showMessage());
        }
        displayText.text = currentInput;
    }
    public void onClickSquirRoot()
    {
        if (!currentInput.EndsWith("√"))
        {
            squirRoot = "√";
            if (currentInput.Length <= 0)
            {
                currentInput += squirRoot;
            }
            else
            {
                currentInput += " x √";
            }
        }
        displayText.text = currentInput;
    }
    public void onCLickDot()
    {
        if (currentInput.Length < 1)
        {
            currentInput = "0.";
        }
        else
        {
            if (!currentInput.EndsWith("."))
            {
                string dots = ".";
                currentInput += dots;
            }
        }
        
        displayText.text = currentInput;
    }
    IEnumerator  showMessage()
    {
        messageObject.SetActive(true);
        yield return new WaitForSeconds(1);
        messageObject.SetActive(false);
    }
}
