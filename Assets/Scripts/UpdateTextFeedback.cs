using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextFeedback : MonoBehaviour
{

    public string textName;

    private void OnEnable()
    {
        if(textName == "Energy")
        {
            this.gameObject.GetComponent<Text>().text = "-" + (StaticVariables.levelFood + 2).ToString();
        }
        if (textName == "Coins")
        {
            this.gameObject.GetComponent<Text>().text = "+" + (StaticVariables.levelFood + 2).ToString();
        }
    }


}
