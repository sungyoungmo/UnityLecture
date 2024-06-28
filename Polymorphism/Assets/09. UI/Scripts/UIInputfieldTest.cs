using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputfieldTest : MonoBehaviour
{
    InputField input;

    public Text messageText;
    public Text submitText;
    public Text endText;

    private void Awake()
    {
        input = GetComponent<InputField>();
    }

    public void OnEdit(string text)
    {
        messageText.text = text;
    }

    public void OnSubmit(string text)
    {
        submitText.text = text;
    }

    public void OnEndEdit(string text)
    {
        endText.text = $"<color=blue>end edit:{text}</color>";
    }
}
