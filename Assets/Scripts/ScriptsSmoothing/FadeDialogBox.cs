using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeDialogBox : MonoBehaviour
{
    public float i;
    public float fadeDuration;
    public Image sr;

    public float delay;

    public bool canFadeIn;

    public float maxI;

    private void OnEnable()
    {
        canFadeIn = false;
        sr = gameObject.GetComponent<Image>();
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
            if (i < maxI)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
                i += Time.deltaTime / fadeDuration;
                if (i >= maxI) i = maxI;
            }
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        canFadeIn = true;
    }
}
