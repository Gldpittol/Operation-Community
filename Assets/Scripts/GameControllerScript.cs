using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    [Header("Audios")]
    public AudioSource audSource;
    public AudioClip winPuzzle;
    public AudioClip losePuzzle;
    public AudioClip applePuzzle;
    public AudioClip openDoor;


    [Header("Canvas Prefabs")]
    public Canvas fruitShopCanvas;
    public Canvas FruitShopPuzzleCanvas;
    public Canvas flowerShopCanvas;
    public Canvas flowerShopPuzzleCanvas;
    public Canvas foodShopCanvas;
    public Canvas foodShopPuzzleCanvas;
    public Canvas mainCanvas;
    public Canvas optionsCanvas;
    public Canvas tutorialCanvas;
    public Canvas creditsCanvas;
    public Canvas mainMenuCanvas;
    public Canvas youWinCanvas;

    [Header("Transition Image")]
    public GameObject transitionImage;

    [Header("Error Messages")]
    public Text errorNoStaminaFruit;
    public Text errorNoMoneyFruit;
    public Text errorLevelTooHighFruit;
    public Text errorNoStaminaFlower;
    public Text errorNoMoneyFlower;
    public Text errorLevelTooHighFlower;
    public Text errorNoStaminaFood;
    public Text errorNoMoneyFood;
    public Text errorLevelTooHighFood;

    [Header("General Prefabs")]
    public GameObject brokenApplePrefab;


    private int transitionActive;

    public static bool onMainCanvas;

    public int energyRegenDelay;
    public int coinsIncrement;

    private TextController tc;

    public bool gameStarted;
    private void Awake()
    {
        onMainCanvas = true;

        //flowerShopCanvas.GetComponent<Canvas>().enabled = false;
        fruitShopCanvas.gameObject.SetActive(false);
        FruitShopPuzzleCanvas.gameObject.SetActive(false);
        flowerShopCanvas.gameObject.SetActive(false);
        flowerShopPuzzleCanvas.gameObject.SetActive(false);
        foodShopCanvas.gameObject.SetActive(false);
        foodShopPuzzleCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(false);
        tutorialCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
        //mainMenuCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        tc = GetComponent<TextController>();
        tc.UpdateTexts();
        StartCoroutine(EnergyRegen());
    }

    public void OpenFruitShopCanvas()
    {
        if(transitionActive == 0)
        {
            StartCoroutine(OpenCanvasRoutine(fruitShopCanvas, false));
            PlayAudio("Door");
        }
    }

    public void CloseFruitShopCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(fruitShopCanvas, true));
    }

    public void OpenFruitShopPuzzleCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(OpenCanvasRoutine(FruitShopPuzzleCanvas, false));
    }

    public void CloseFruitShopPuzzleCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(FruitShopPuzzleCanvas, true));
    }

    //outras funções para flower e food shops

    public void OpenFlowerShopCanvas()
    {
        if (transitionActive == 0)
        {
            StartCoroutine(OpenCanvasRoutine(flowerShopCanvas, false));
            PlayAudio("Door");
        }
    }

    public void CloseFlowerShopCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(flowerShopCanvas, true));
    }

    public void OpenFlowerShopPuzzleCanvas()
    {
        if (transitionActive == 0 && StaticVariables.currentEnergyFlower >= 10)
            StartCoroutine(OpenCanvasRoutine(flowerShopPuzzleCanvas, false));

        if (StaticVariables.currentEnergyFlower < 10)
        {
            errorNoStaminaFlower.gameObject.SetActive(true);
        }
    }

    public void CloseFlowerShopPuzzleCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(flowerShopPuzzleCanvas, true));
    }



    public void OpenFoodShopCanvas()
    {
        if (transitionActive == 0)
        {
            PlayAudio("Door");
            StartCoroutine(OpenCanvasRoutine(foodShopCanvas, false));
        }
    }

    public void CloseFoodShopCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(foodShopCanvas, true));
    }

    public void OpenFoodShopPuzzleCanvas()
    {
        if (transitionActive == 0 && StaticVariables.currentEnergyFood >= StaticVariables.levelFood + 2)
            StartCoroutine(OpenCanvasRoutine(foodShopPuzzleCanvas, false));

        if(StaticVariables.currentEnergyFood < StaticVariables.levelFood + 2)
        {
            errorNoStaminaFood.gameObject.SetActive(true);
        }
    }

    public void CloseFoodShopPuzzleCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(foodShopPuzzleCanvas, true));
    }


    public void OpenOptionsCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(OpenCanvasRoutine(optionsCanvas, false));
    }

    public void CloseOptionsCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(optionsCanvas, true));
    }

    public void OpenTutorialCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(OpenCanvasRoutine(tutorialCanvas, false));
    }

    public void CloseTutorialCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(tutorialCanvas, true));
    }

    public void OpenCreditsCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(OpenCanvasRoutine(creditsCanvas, false));
    }

    public void CloseCreditsCanvas()
    {
        if (transitionActive == 0)
            StartCoroutine(CloseCanvasRoutine(creditsCanvas, true));
    }

    public void OpenMainMenuCanvas()
    {
        if (transitionActive == 0)
        {
            StartCoroutine(OpenMainMenuRoutine());
        }
    }

    public IEnumerator OpenMainMenuRoutine()
    {
        StartCoroutine(OpenCanvasRoutine(mainMenuCanvas, false));
        yield return new WaitForSeconds(1f);
        optionsCanvas.gameObject.SetActive(false);
    }

    public void CloseMainMenuCanvas()
    {
        if (transitionActive == 0)
        {
            gameStarted = true;
            StartCoroutine(CloseCanvasRoutine(mainMenuCanvas, true));

        }
    }

    //continuação

    public void IncreaseLevel(string shopName)
    {
        switch(shopName)
        {
            case "Fruit":
                if(StaticVariables.currentCoinsFruit >= StaticVariables.coinsToUpgradeFruit)
                {
                    if(!CanUpgrade(StaticVariables.levelFruit))
                    {
                        print("Level Too High");
                        errorLevelTooHighFruit.gameObject.SetActive(true);
                        break;
                    }
                    StaticVariables.levelFruit++;
                    if (StaticVariables.levelFruit >= 10) StaticVariables.levelFruit = 10;
                    StaticVariables.currentCoinsFruit -= StaticVariables.coinsToUpgradeFruit;
                    StaticVariables.coinsToUpgradeFruit += coinsIncrement;
                    StaticVariables.maxEnergyFruit += 1;
                    StaticVariables.currentEnergyFruit = StaticVariables.maxEnergyFruit;
                    tc.UpdateTexts();
                    print("Game Saved");
                    StaticVariables.SaveGame();
                    PlayAudio("WinPuzzle");
                    CheckWin();
                }
                else
                {
                    errorNoMoneyFruit.gameObject.SetActive(true);
                    print("Not enough money");
                }
                break;
            case "Flower":
                if (StaticVariables.currentCoinsFlower >= StaticVariables.coinsToUpgradeFlower)
                {
                    if (!CanUpgrade(StaticVariables.levelFlower))
                    {
                        print("Level Too High");
                        errorLevelTooHighFlower.gameObject.SetActive(true);
                        break;
                    }
                    StaticVariables.levelFlower++;
                    if (StaticVariables.levelFlower >= 10) StaticVariables.levelFlower = 10;
                    StaticVariables.currentCoinsFlower -= StaticVariables.coinsToUpgradeFlower;
                    StaticVariables.coinsToUpgradeFlower += coinsIncrement;
                    StaticVariables.maxEnergyFlower += 1;
                    StaticVariables.currentEnergyFlower = StaticVariables.maxEnergyFlower;
                    tc.UpdateTexts();
                    print("Game Saved");
                    StaticVariables.SaveGame();
                    PlayAudio("WinPuzzle");
                    CheckWin();
                }
                else
                {
                    errorNoMoneyFlower.gameObject.SetActive(true);
                    print("Not enough money");
                }
                break;
            case "Food":
                if (StaticVariables.currentCoinsFood >= StaticVariables.coinsToUpgradeFood)
                {
                    if (!CanUpgrade(StaticVariables.levelFood))
                    {
                        print("Level Too High");
                        errorLevelTooHighFood.gameObject.SetActive(true);
                        break;
                    }
                    StaticVariables.levelFood++;
                    if (StaticVariables.levelFood >= 10) StaticVariables.levelFood = 10;
                    StaticVariables.currentCoinsFood -= StaticVariables.coinsToUpgradeFood;
                    StaticVariables.coinsToUpgradeFood += coinsIncrement;
                    StaticVariables.maxEnergyFood += 1;
                    StaticVariables.currentEnergyFood = StaticVariables.maxEnergyFood;
                    tc.UpdateTexts();
                    print("Game Saved");
                    StaticVariables.SaveGame();
                    PlayAudio("WinPuzzle");
                    CheckWin();
                }
                else
                {
                    errorNoMoneyFood.gameObject.SetActive(true);
                    print("Not enough money");
                }
                break;
        }
    }

    public bool CanUpgrade(int level)
    {
        return (level - StaticVariables.levelFlower < 2 && level - StaticVariables.levelFood < 2 && level - StaticVariables.levelFruit < 2) ;
    }

    public IEnumerator OpenCanvasRoutine(Canvas canv, bool onMain)
    {
        onMainCanvas = onMain;
        transitionActive = 1;
        Instantiate(transitionImage, new Vector3(0f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        canv.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transitionActive = 0;        
    }

    public IEnumerator CloseCanvasRoutine(Canvas canv, bool onMain)
    {
        transitionActive = 1;
        Instantiate(transitionImage, new Vector3(0f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        canv.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        transitionActive = 0;
        onMainCanvas = onMain;
    }

    public IEnumerator EnergyRegen()
    {
        yield return new WaitForSeconds(energyRegenDelay);
        if (StaticVariables.currentEnergyFruit < StaticVariables.maxEnergyFruit)
        {
            StaticVariables.currentEnergyFruit++;
            tc.UpdateTexts();
        }
        if (StaticVariables.currentEnergyFlower < StaticVariables.maxEnergyFlower)
        {
            StaticVariables.currentEnergyFlower++;
            tc.UpdateTexts();
        }
        if (StaticVariables.currentEnergyFood < StaticVariables.maxEnergyFood)
        {
            StaticVariables.currentEnergyFood++;
            tc.UpdateTexts();
        }
        StartCoroutine(EnergyRegen());
    }

  public void PlayAudio(string audioName)
    {
        switch(audioName)
        {
            case "Door":
                if (StaticVariables.isAudioOn)
                    audSource.PlayOneShot(openDoor);
                break;
            case "WinPuzzle":
                if (StaticVariables.isAudioOn)
                    audSource.PlayOneShot(winPuzzle);
                break;
            case "LosePuzzle":
                if (StaticVariables.isAudioOn)
                    audSource.PlayOneShot(losePuzzle);
                break;
            case "ApplePuzzle":
                if (StaticVariables.isAudioOn)
                    audSource.PlayOneShot(applePuzzle);
                break;
        }
    }

    public void DisableAudio()
    {
        if (StaticVariables.isAudioOn == true) StaticVariables.isAudioOn = false;
        else StaticVariables.isAudioOn = true;          
    }
    public void DisableMusic()
    {
        StaticVariables.isMusicOn = !StaticVariables.isMusicOn;
        Camera.main.GetComponent<AudioSource>().enabled = StaticVariables.isMusicOn;
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        StaticVariables.ResetVariables();
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void SaveAndQuit()
    {
        StaticVariables.SaveGame();
        Application.Quit();
    }

    public void CheckWin()
    {       
        if (StaticVariables.levelFlower >= 5 && StaticVariables.levelFruit >= 5 && StaticVariables.levelFood >= 5 && StaticVariables.youWin == 0)
        {
            print("YouWin");
            StartCoroutine(CheckWinRoutine());
        }
    }

    public IEnumerator CheckWinRoutine()
    {
        PlayAudio("WinPuzzle");
        Instantiate(transitionImage, new Vector3(0f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        youWinCanvas.gameObject.SetActive(true);
        tc.UpdateTexts();
    }
}
