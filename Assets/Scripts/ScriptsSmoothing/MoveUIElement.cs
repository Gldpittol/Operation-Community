using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUIElement : MonoBehaviour
{
    public bool canMove;

    public float posX;
    public float posY;

    public float OriginalPosX;
    public float OriginalPosY;

    public float delay;
    public float speed;

    private void OnEnable()
    {
        transform.localPosition = new Vector2(OriginalPosX, OriginalPosY);
        StartCoroutine(DelayBeforeMove());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        canMove = false;
    }
    private void Update()
    {
        if(canMove)
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(posX, posY), Time.deltaTime * speed);

       if(transform.localPosition.x == posX && transform.localPosition.y == posY)
       {
            canMove = false;
       }
    }


  

    public IEnumerator DelayBeforeMove()
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

   
}
