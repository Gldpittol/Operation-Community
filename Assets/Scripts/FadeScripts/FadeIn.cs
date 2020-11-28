using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float i;
    public float fadeDuration;
    public Image sr;

    public float delay;

    public bool canFadeIn;
    public bool canFadeOut;

    public Image toDestroy;

    public Text childText;

    private void Start()
    {
        canFadeIn = false;
        canFadeOut = false;
        sr = gameObject.GetComponent<Image>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        childText.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        StartCoroutine(Delay());
    }
    private void OnEnable()
    {
        i = 0;
    }

    void Update()
    {      
        if(canFadeIn)
        {
            if (i < 1)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                childText.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                i += Time.deltaTime / fadeDuration;
                if (i >= 1) i = 1;
            }
        }
        if (canFadeOut)
        {
            if (i > 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                childText.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                i -= Time.deltaTime / fadeDuration;
                if (i <= 0) i = 0;
            }
            else
            {
                toDestroy.gameObject.GetComponent<DelayedFade>().canFade = true;
                Destroy(this.gameObject);
            }
        }



    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        canFadeIn = true;
    }

    public void OnClick()
    {
        if(i>=1 && canFadeIn)
        {
            canFadeOut = true;
            canFadeIn = false;
        }
    }

}
