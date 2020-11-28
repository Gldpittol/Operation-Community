using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorTextFood : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        GetComponent<Text>().text = "Not Enough Energy! Need: " + (StaticVariables.levelFood + 2).ToString();
    }
}
