using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutBackground : MonoBehaviour
{

    public float initialScaleX;
    public float initialScaleY;

    public float desiredScaleX;
    public float desireScaleY;

    public float speed;

    public float delay;

    public bool canShrink;

    private void OnEnable()
    {
        canShrink = false;
        transform.localScale = new Vector2(initialScaleX, initialScaleY);
        StartCoroutine(Delay());
    }

    private void Update()
    {
        if(canShrink)
        {
            transform.localScale = new Vector2(transform.localScale.x - speed * Time.deltaTime, transform.localScale.x - speed * Time.deltaTime);
            if (transform.localScale.x <= desiredScaleX) transform.localScale = new Vector3(desiredScaleX, desireScaleY);
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        canShrink = true;
    }

}
