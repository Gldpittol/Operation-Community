using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeDialog : MonoBehaviour
{
    float i;
    public float fadeDuration;
    public Text sr;

    public float delay;

    public bool canFadeIn;

    private void OnEnable()
    {
        canFadeIn = false;
        sr = gameObject.GetComponent<Text>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        StartCoroutine(Delay());
    }
    private void OnDisable()
    {
        i = 0;
        canFadeIn = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (canFadeIn)
        {
            if (i < 1)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                i += Time.deltaTime / fadeDuration;
                if (i >= 1) i = 1;
            }
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        canFadeIn = true;
    }
}
