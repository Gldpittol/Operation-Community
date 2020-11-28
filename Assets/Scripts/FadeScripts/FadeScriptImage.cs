using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScriptImage : MonoBehaviour
{
    float i;
    public float fadeDuration;
    public Image sr;

    public float delay;

    public bool fadeOut;

    public bool canFade;

    private void Start()
    {
        sr = gameObject.GetComponent<Image>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        StartCoroutine(Delay());
    }
    private void OnEnable()
    {
        i = 0;
    }

    void Update()
    {

        if (canFade)
        {

        if (!fadeOut)
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

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        canFade = true;
    }
}
