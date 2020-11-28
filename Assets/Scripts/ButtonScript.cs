using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(ClickRoutine());
    }

    public IEnumerator ClickRoutine()
    {
        transform.localScale = new Vector2(1f, 1f);
        transform.localScale = new Vector2(1.04f, 1.04f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector2(1f, 1f);
    }


}
