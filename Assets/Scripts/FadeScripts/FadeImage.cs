using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    float i;
    public float fadeDuration;
    public Image img;

    public float delay;

    public bool fadeOut;

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
    }
    private void OnEnable()
    {
        i = 0;
    }

    void Update()
    {
        if (!fadeOut)
        {
            if (i <= 1)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                i += Time.deltaTime / fadeDuration;
            }
            else
            {
                fadeOut = true;
            }
        }
        else
        {
            if (i >= 0)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                i -= Time.deltaTime / fadeDuration;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


    }
}
