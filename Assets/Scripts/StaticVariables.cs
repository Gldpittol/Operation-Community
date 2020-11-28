using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [Header("variables")]
    public static int maxEnergyFruit = 10;
    public static int currentEnergyFruit = 10;
    public static int currentCoinsFruit = 0;
    public static int coinsToUpgradeFruit = 5;
    public static int levelFruit = 1;

    public static int maxEnergyFlower = 10;
    public static int currentEnergyFlower = 10;
    public static int currentCoinsFlower = 0;
    public static int coinsToUpgradeFlower = 5;
    public static int levelFlower = 1;

    public static int maxEnergyFood = 10;
    public static int currentEnergyFood = 10;
    public static int currentCoinsFood = 0;
    public static int coinsToUpgradeFood = 5;
    public static int levelFood = 1;


    public static bool isAudioOn = true;
    public static bool isMusicOn = true;

    public static int youWin;

    private void Awake()
    {
        youWin = 0;
        LoadGame();
        SaveGame();
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<TextController>().UpdateTexts();
    }

    public static void ResetVariables()
    {
             maxEnergyFruit = 10;
             currentEnergyFruit = 10;
             currentCoinsFruit = 0;
             coinsToUpgradeFruit = 5;
             levelFruit = 1;

             maxEnergyFlower = 10;
             currentEnergyFlower = 10;
             currentCoinsFlower = 0;
             coinsToUpgradeFlower = 5;
             levelFlower = 1;

              maxEnergyFood = 10;
              currentEnergyFood = 10;
              currentCoinsFood = 0;
              coinsToUpgradeFood = 5;
              levelFood = 1;

        youWin = 0;
}

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("levelFruit"))
        {
            print("Game Loaded");

            levelFruit = PlayerPrefs.GetInt("levelFruit");
            maxEnergyFruit = 10 + levelFruit - 1;
            coinsToUpgradeFruit = 5 + (5 * (levelFruit - 1));
            currentCoinsFruit = PlayerPrefs.GetInt("currentCoinsFruit");

            levelFlower = PlayerPrefs.GetInt("levelFlower");
            maxEnergyFlower = 10 + levelFlower - 1;
            coinsToUpgradeFlower = 5 + (5 * (levelFlower - 1));
            currentCoinsFlower = PlayerPrefs.GetInt("currentCoinsFlower");

            levelFood = PlayerPrefs.GetInt("levelFood");
            maxEnergyFood = 10 + levelFood - 1;
            coinsToUpgradeFood = 5 + (5 * (levelFood - 1));
            currentCoinsFood = PlayerPrefs.GetInt("currentCoinsFood");

            youWin = PlayerPrefs.GetInt("youWin");
        }      
    }

    public static void SaveGame()
    {
        print("Game Saved");
        PlayerPrefs.SetInt("levelFruit", levelFruit);
        PlayerPrefs.SetInt("levelFlower", levelFlower);
        PlayerPrefs.SetInt("levelFood", levelFood);
        PlayerPrefs.SetInt("currentCoinsFruit", currentCoinsFruit);
        PlayerPrefs.SetInt("currentCoinsFlower", currentCoinsFlower);
        PlayerPrefs.SetInt("currentCoinsFood", currentCoinsFood);
        PlayerPrefs.SetInt("youWin", youWin);
    }
}
