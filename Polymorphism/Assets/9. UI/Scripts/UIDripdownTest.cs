using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDripdownTest : MonoBehaviour
{
    private Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void OnDropDownValueChange(int value)
    {
        print($"{dropdown.options[value].text} selected");

        
    }

    char charTemp = 'E';
    public void OnAddOptionButtonClick()
    {
        charTemp = (char)((int)charTemp + 1);
        string optionName = $"Option {charTemp}";

        Dropdown.OptionData optionData = new Dropdown.OptionData();
        optionData.text = optionName;

        dropdown.options.Add(optionData);
    }

    public void OndeleteOptionButtonClick()
    {
        string optionName = $"Option {charTemp}";

        Dropdown.OptionData optionData = new Dropdown.OptionData();
        Debug.Log(1);


        if (optionData != null)
        {
            Debug.Log(2);
            dropdown.options.Remove(optionData);
            

            charTemp = (char)((int)charTemp - 1);
        }


    }

}
