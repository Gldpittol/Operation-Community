using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitShopPuzzle : MonoBehaviour
{
    public Transform appleLimitTop;
    public Transform appleLimitLeft;
    public Transform appleLimitRight;
    public Transform appleLimitBottom;

    public Button appleButtonPrefab;
    private Button temp;
    private GameObject temp2;

    public float delayBetweenSpawns;

    public TextController tc;
    public GameControllerScript gc;

    public GameObject feedbackObject;
    public GameObject feedback;

    private void OnEnable()
    {
        StartCoroutine(SpawnApple());
    }

    

    public IEnumerator SpawnApple()
    {
       // print("oi");
        Vector3 spawnPosition = new Vector3(Random.Range(appleLimitLeft.transform.position.x, appleLimitRight.transform.position.x), Random.Range(appleLimitTop.transform.position.y, appleLimitBottom.transform.position.y), 0f);
        temp = Instantiate(appleButtonPrefab, spawnPosition, Quaternion.identity);
        temp.transform.SetParent(this.transform);
        temp.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(temp.gameObject, delayBetweenSpawns - (StaticVariables.levelFruit/10));
        yield return new WaitForSeconds(delayBetweenSpawns + 0.01f - (StaticVariables.levelFruit/10));
        StartCoroutine(SpawnApple());
    }

    public void OnAppleClick()
    {
        // print("clicked");

        if (StaticVariables.currentEnergyFruit > 0)
        {
            gc.PlayAudio("ApplePuzzle");
            StaticVariables.currentCoinsFruit++;
            StaticVariables.currentEnergyFruit--;
            tc.UpdateTexts();
            temp2 = Instantiate(gc.brokenApplePrefab, transform.position, Quaternion.identity);
            temp2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            temp2.transform.position = temp.transform.position;
            temp2.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            Destroy(temp2, 3f);


            feedback = Instantiate(feedbackObject, new Vector2(-574f, 194f), Quaternion.identity);
            feedback.transform.SetParent(this.transform);
            feedback.transform.localScale = new Vector2(1f, 1f);
            feedback.transform.localPosition = new Vector3(-574f, 194f);
            feedback.gameObject.SetActive(true);

            //print("pass");


            Destroy(temp.gameObject);
        }  
        else
        {
            gc.PlayAudio("LosePuzzle");
        }
    }

}
