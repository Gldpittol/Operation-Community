using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNotifications : MonoBehaviour
{
    public float totalTime;
    private float currentTime;

    public Image upArrow;
    public Image downArrow;
    private Image temp;

    private GameControllerScript gc;
    private TextController tc;

    public Transform aboveFlowerShop;
    public Transform aboveFruitShop;
    public Transform aboveFoodShop;

    private void Start()
    {
        gc = GetComponent<GameControllerScript>();
        tc = GetComponent<TextController>();
        currentTime = 0;
    }

    private void Update()
    {
       // if(GameControllerScript.onMainCanvas)
        //{
            currentTime += Time.deltaTime;
            if(currentTime > totalTime)
            {
                SpawnRandomNotification();
                currentTime = 0;
            }
        //}
    }


    public void SpawnRandomNotification()
    {

        float rnd = Random.value;

        if (rnd <= 0.33)
        {
            if (Random.value <= 0.5)
            {
                temp = Instantiate(downArrow, aboveFruitShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFruit -= StaticVariables.levelFruit;
                tc.UpdateTexts();
           }
            else
            {
                temp = Instantiate(upArrow, aboveFruitShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFruit += StaticVariables.levelFruit;
                tc.UpdateTexts();

            }
        }
        else if (rnd <= 0.66)
        {
            if (Random.value <= 0.5)
            {
                temp = Instantiate(downArrow, aboveFlowerShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFlower -= StaticVariables.levelFlower;
                tc.UpdateTexts();

            }
            else
            {
                temp = Instantiate(upArrow, aboveFlowerShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFlower += StaticVariables.levelFlower;
                tc.UpdateTexts();

            }
        }
        else
        {
            if (Random.value <= 0.5)
            {
                temp = Instantiate(downArrow, aboveFoodShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFood -= StaticVariables.levelFood;
                tc.UpdateTexts();

            }
            else
            {
                temp = Instantiate(upArrow, aboveFoodShop.transform.position, Quaternion.identity);
                temp.transform.SetParent(gc.mainCanvas.transform);
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                StaticVariables.currentCoinsFood += StaticVariables.levelFood;
                tc.UpdateTexts();


            }
        }
    }

}
