using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script com o objetivo de aplicar fade out em um texto ao longo de um segundo. 
public class DelayedFade : MonoBehaviour
{
    public Image toFade;
    public float fadeDuration;
    private float i;

    public float delayBeforeFade;
    public bool canFade;

    private void OnEnable()
    {
        canFade = false;
        i = 1;
        toFade = GetComponent<Image>();
        //StartCoroutine(DelayedFadeRoutine());
    }


    private void Update()
    {
        if(canFade)
        {
        if (i >= 0)
        {
            toFade.color = new Color(255, 255, 255, i);
            i -= Time.deltaTime / fadeDuration;
        }
        else
        {
            gameObject.SetActive(false);
        }
        }

    }

    public IEnumerator DelayedFadeRoutine()
    {
        yield return new WaitForSeconds(delayBeforeFade);
        canFade = true;
    }

}