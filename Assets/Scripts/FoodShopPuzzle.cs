using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodShopPuzzle : MonoBehaviour
{
    public int[] givenVector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] playerSolutionVector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;

    public Image img;

    public Image temp;

    public bool isPlayerTurn;

    public int playerI;

    public TextController tc;
    public GameControllerScript gc;

    public Text playerTurnText;
    public Text PCTurn;

    public GameObject feedbackObject;
    public GameObject feedback;

    void OnEnable()
    {
        ResetVectorGiven();
        ResetVectorPlayer();
        ResetVariables();
        StartCoroutine(GiveSequence(0));
    }

    public void ResetVariables()
    {
        isPlayerTurn = false;
        playerI = 0;
    }


    public void ResetVectorGiven()
    {
        for (int i = 0; i < givenVector.Length; i++) givenVector[i] = 0;
    }

    public void ResetVectorPlayer()
    {
        for (int i = 0; i < playerSolutionVector.Length; i++) playerSolutionVector[i] = 0;
        playerI = 0;
    }

    public void OnClick1()
    {
        if(isPlayerTurn)
        {
            playerSolutionVector[playerI] = 1;
            playerI++;
            if (playerI == StaticVariables.levelFood + 2) CheckSolution();

            temp = Instantiate(img, new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            temp.transform.position = spot1.transform.position;
        }
    }
    public void OnClick2()
    {
        if(isPlayerTurn)
        {
            playerSolutionVector[playerI] = 2;
            playerI++;
            if (playerI == StaticVariables.levelFood + 2) CheckSolution();

            temp = Instantiate(img, new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            temp.transform.position = spot2.transform.position;
        }
    }
    public void OnClick3()
    {
        if(isPlayerTurn)
        { 
            playerSolutionVector[playerI] = 3;
            playerI++;
            if (playerI == StaticVariables.levelFood + 2) CheckSolution();

            temp = Instantiate(img, new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);
            temp.transform.position = spot3.transform.position;
        }
    }

    public void CheckSolution()
    {
        int counter = 0;

        for(int j = 0; j < StaticVariables.levelFood + 2; j++)
        {
            if(playerSolutionVector[j] == givenVector[j])
            {
                counter++;
            }
        }

        if(counter == StaticVariables.levelFood + 2)
        {
            feedback = Instantiate(feedbackObject, new Vector2(-0, 0), Quaternion.identity);
            feedback.transform.SetParent(this.transform);
            feedback.transform.localScale = new Vector2(1f, 1f);
            feedback.transform.localPosition = new Vector2(0f, 0f);
            feedback.gameObject.SetActive(true);

            print("you win");
            gc.PlayAudio("WinPuzzle");
            StaticVariables.currentCoinsFood += StaticVariables.levelFood + 2;
            StaticVariables.currentEnergyFood -= StaticVariables.levelFood + 2;
            tc.UpdateTexts();
            StartCoroutine(ReloadPuzzleCoroutine());
        }

        else
        {
            print("Wrong, resetting");
            gc.PlayAudio("LosePuzzle");
            ResetVariables();
            StartCoroutine(ReplaySequence(0));
        }
    }

    public IEnumerator ReplaySequence(int k)
    {

        if (k == 0)
        {
            yield return new WaitForSeconds(1f);
            PCTurn.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }


        yield return new WaitForSeconds(0.5f);

        if (k < StaticVariables.levelFood + 2)
        {
            temp = Instantiate(img, new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);


            if (givenVector[k] == 1)
            {
                temp.transform.position = spot1.transform.position;
            }
            else if (givenVector[k] == 2)
            {
                temp.transform.position = spot2.transform.position;
            }
            else
            {
                temp.transform.position = spot3.transform.position;
            }

            k++;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ReplaySequence(k));
        }
        else
        {
            isPlayerTurn = true;
            playerTurnText.gameObject.SetActive(true);

        }
    }

    public IEnumerator GiveSequence(int i)
    {

        if (i == 0)
        {
            yield return new WaitForSeconds(1f);
            PCTurn.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f); 
        }

        yield return new WaitForSeconds(0.5f);

        if(i < StaticVariables.levelFood + 2)
        {
            temp = Instantiate(img, new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);

            float rnd = Random.value;

            if (rnd <= 0.33f)
            {
                temp.transform.position = spot1.transform.position;
                givenVector[i] = 1;
            }
            else if (rnd <= 0.66f)
            {
                temp.transform.position = spot2.transform.position;
                givenVector[i] = 2;
            }
            else
            {
                temp.transform.position = spot3.transform.position;
                givenVector[i] = 3;
            }

            i++;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(GiveSequence(i));
        }
        else
        {
            isPlayerTurn = true;
            playerTurnText.gameObject.SetActive(true);
        }
    }

    public IEnumerator ReloadPuzzleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        if(StaticVariables.currentEnergyFood >= StaticVariables.levelFood + 2)
        {
            ResetVectorGiven();
            ResetVectorPlayer();
            ResetVariables();
            StartCoroutine(GiveSequence(0));
        }

        else
        {
            gc.CloseFoodShopPuzzleCanvas();
        }

    }
}
