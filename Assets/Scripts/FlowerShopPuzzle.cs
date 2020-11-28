using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerShopPuzzle : MonoBehaviour
{
    public Image prefab1;
    public Image prefab2;
    public Image prefab3;

    public Image toCopy;

    public Button first;
    public Button second;
    public Button third;

    public int firstValue;
    public int secondValue;
    public int thirdValue;

    public TextController tc;
    public GameControllerScript gc;


    private int currentPuzzle;

    private Image temp;

    public bool canPlay = true;

    public GameObject feedbackObject;
    public GameObject feedback;
    private void OnEnable()
    {
        canPlay = true;
        ReloadPuzzle();
        CheckSolution();
    }

    private void OnDisable()
    {
        Destroy(temp.gameObject);
    }

    private void Update()
    {
        if (StaticVariables.currentEnergyFlower < 10)
        {
            StartCoroutine(Close());
        }
    }

    public void OnClickFirst()
    {

        if(canPlay)
        {
        if(firstValue == 1)
        {
            first.GetComponent<Image>().sprite = prefab2.sprite;
            firstValue = 2;
        }
        else if (firstValue == 2)
        {
            first.GetComponent<Image>().sprite = prefab3.sprite;
            firstValue = 3;
        }
        else if (firstValue == 3)
        {
            first.GetComponent<Image>().sprite = prefab1.sprite;
            firstValue = 1;
        }
        if (secondValue == 1)
        {
            second.GetComponent<Image>().sprite = prefab2.sprite;
            secondValue = 2;
        }
        else if (secondValue == 2)
        {
            second.GetComponent<Image>().sprite = prefab3.sprite;
            secondValue = 3;
        }
        else if (secondValue == 3)
        {
            second.GetComponent<Image>().sprite = prefab1.sprite;
            secondValue = 1;
        }
        CheckSolution();
        }
    }

    public void OnClickSecond()
    {
        if(canPlay)
        {
            if (thirdValue == 1)
            {
                third.GetComponent<Image>().sprite = prefab2.sprite;
                thirdValue = 2;
            }
            else if (thirdValue == 2)
            {
                third.GetComponent<Image>().sprite = prefab3.sprite;
                thirdValue = 3;
            }
            else if (thirdValue == 3)
            {
                third.GetComponent<Image>().sprite = prefab1.sprite;
                thirdValue = 1;
            }
            if (secondValue == 1)
            {
                second.GetComponent<Image>().sprite = prefab2.sprite;
                secondValue = 2;
            }
            else if (secondValue == 2)
            {
                second.GetComponent<Image>().sprite = prefab3.sprite;
                secondValue = 3;
            }
            else if (secondValue == 3)
            {
                second.GetComponent<Image>().sprite = prefab1.sprite;
                secondValue = 1;
            }
            CheckSolution();
        }
       
    }

    public void OnClickThird()
    {
        if(canPlay)
        {
            if (firstValue == 1)
            {
                first.GetComponent<Image>().sprite = prefab2.sprite;
                firstValue = 2;
            }
            else if (firstValue == 2)
            {
                first.GetComponent<Image>().sprite = prefab3.sprite;
                firstValue = 3;
            }
            else if (firstValue == 3)
            {
                first.GetComponent<Image>().sprite = prefab1.sprite;
                firstValue = 1;
            }
            if (thirdValue == 1)
            {
                third.GetComponent<Image>().sprite = prefab2.sprite;
                thirdValue = 2;
            }
            else if (thirdValue == 2)
            {
                third.GetComponent<Image>().sprite = prefab3.sprite;
                thirdValue = 3;
            }
            else if (thirdValue == 3)
            {
                third.GetComponent<Image>().sprite = prefab1.sprite;
                thirdValue = 1;
            }
            CheckSolution();
        }
        
    }

    public void CheckSolution()
    {
        if(gc.gameStarted)
        {
            if (currentPuzzle == 1 && firstValue == 1 && secondValue == 1 && thirdValue == 1)
            {
                feedback = Instantiate(feedbackObject, new Vector2(-0, 0), Quaternion.identity);
                feedback.transform.SetParent(this.transform);
                feedback.transform.localScale = new Vector2(1f, 1f);
                feedback.transform.localPosition = new Vector2(0f, 0f);
                feedback.gameObject.SetActive(true);

                print("win");
                StaticVariables.currentCoinsFlower += 10;
                StaticVariables.currentEnergyFlower -= 10;
                tc.UpdateTexts();
                StartCoroutine(ReloadPuzzleCoroutine());

            }
            if (currentPuzzle == 2 && firstValue == 2 && secondValue == 2 && thirdValue == 2)
            {
                feedback = Instantiate(feedbackObject, new Vector2(0, 0), Quaternion.identity);
                feedback.transform.SetParent(this.transform);
                feedback.transform.localScale = new Vector2(1f, 1f);
                feedback.transform.localPosition = new Vector2(0f, 0f);
                feedback.gameObject.SetActive(true);

                print("win");
                StaticVariables.currentCoinsFlower += 10;
                StaticVariables.currentEnergyFlower -= 10;
                tc.UpdateTexts();
                StartCoroutine(ReloadPuzzleCoroutine());
            }
            if (currentPuzzle == 3 && firstValue == 3 && secondValue == 3 && thirdValue == 3)
            {
                feedback = Instantiate(feedbackObject, new Vector2(0, 0), Quaternion.identity);
                feedback.transform.SetParent(this.transform);
                feedback.transform.localScale = new Vector2(1f, 1f);
                feedback.transform.localPosition = new Vector2(0f, 0f);
                feedback.gameObject.SetActive(true);

                print("win");
                StaticVariables.currentCoinsFlower += 10;
                StaticVariables.currentEnergyFlower -= 10;
                tc.UpdateTexts();
                StartCoroutine(ReloadPuzzleCoroutine());
            }
        } 
    }

    public void ReloadPuzzle()
    {
        float rnd = Random.value;
        if (rnd <= 0.33)
        {
            currentPuzzle = 1;
            temp = Instantiate(prefab1, new Vector3(0f, -10f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0f, -250f, 0f);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else if (rnd <= 0.66)
        {
            currentPuzzle = 2;
            temp = Instantiate(prefab2, new Vector3(0f, -10f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0f, -250f, 0f);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else
        {
            currentPuzzle = 3;
            temp = Instantiate(prefab3, new Vector3(0f, -10f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0f, -250f, 0f);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        rnd = Random.value;
        if (rnd <= 0.33) { first.GetComponent<Image>().sprite = prefab1.sprite; firstValue = 1; }
        else if (rnd <= 0.66) { first.GetComponent<Image>().sprite = prefab2.sprite; firstValue = 2; }
        else { first.GetComponent<Image>().sprite = prefab3.sprite; firstValue = 3; }

        rnd = Random.value;
        if (rnd <= 0.33) { second.GetComponent<Image>().sprite = prefab1.sprite; secondValue = 1; }
        else if (rnd <= 0.66) { second.GetComponent<Image>().sprite = prefab2.sprite; secondValue = 2; }
        else { second.GetComponent<Image>().sprite = prefab3.sprite; secondValue = 3; }

        rnd = Random.value;
        if (rnd <= 0.33) { third.GetComponent<Image>().sprite = prefab1.sprite; thirdValue = 1; }
        else if (rnd <= 0.66) { third.GetComponent<Image>().sprite = prefab2.sprite; thirdValue = 2; }
        else { third.GetComponent<Image>().sprite = prefab3.sprite; thirdValue = 3; }


        if (firstValue == 0) firstValue = 1;
        if (secondValue == 0) secondValue = 1;
        if (thirdValue == 0) thirdValue = 1;


    }
    public IEnumerator ReloadPuzzleCoroutine()
    {
        canPlay = false;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().PlayAudio("WinPuzzle");
        yield return new WaitForSeconds(1f);

        if (StaticVariables.currentEnergyFlower >= 10)
        {
            ReloadPuzzle();
            yield return new WaitForSeconds(1f);
            canPlay = true;
        }
        else
        {
            gc.CloseFlowerShopPuzzleCanvas();
        }
    }

    public IEnumerator Close()
    {
        yield return new WaitForSeconds(1f);
        gc.CloseFlowerShopPuzzleCanvas();
    }

}
