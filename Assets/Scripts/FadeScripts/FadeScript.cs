using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    float i;
    public float fadeDuration;
    public SpriteRenderer sr;

    public float delay;

    public bool fadeOut;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
    }
    private void OnEnable()
    {
        i = 0;
    }

    void Update()
    {
        if(!fadeOut)
        {
            if (i <= 1)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
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
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                i -= Time.deltaTime / fadeDuration;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

       
    }
}
