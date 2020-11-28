using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AudioMusicButton : MonoBehaviour
{
    public string buttonName;

    public Sprite on;
    public Sprite off;
    public Image img;

    private void OnEnable()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if(buttonName == "Music")
        {
            if (StaticVariables.isMusicOn)
            {
                img.sprite = on;
            }
            else
                img.sprite = off;
        }

        if (buttonName == "Audio")
        {
            if (StaticVariables.isAudioOn)
            {
                img.sprite = on;
            }
            else
                img.sprite = off;
        }
    }


}
