using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [Header("Main Menu")]
    public Text levelFruitShopText;
    public Text energyFruitShopText;
    public Text coinsFruitShopText;
    public Text levelFlowerShopText;
    public Text energyFlowerShopText;
    public Text coinsFlowerShopText;
    public Text levelFoodShopText;
    public Text energyFoodShopText;
    public Text coinsFoodShopText;

    [Header("Fruit Shop")]
    public Text levelFruitShopTextIn;
    public Text energyFruitShopTextIn;
    public Text coinsFruitShopTextIn;

    [Header("Flower Shop")]
    public Text levelFlowerShopTextIn;
    public Text energyFlowerShopTextIn;
    public Text coinsFlowerShopTextIn;

    [Header("Food Shop")]
    public Text levelFoodShopTextIn;
    public Text energyFoodShopTextIn;
    public Text coinsFoodShopTextIn;

    [Header("Fruit Shop Puzzle")]
    public Text levelFruitShopTextPuz;
    public Text energyFruitShopTextPuz;
    public Text coinsFruitShopTextPuz;

    [Header("Flower Shop Puzzle")]
    public Text levelFlowerShopTextPuz;
    public Text energyFlowerShopTextPuz;
    public Text coinsFlowerShopTextPuz;

    [Header("Food Shop Puzzle")]
    public Text levelFoodShopTextPuz;
    public Text energyFoodShopTextPuz;
    public Text coinsFoodShopTextPuz;

    public void UpdateTexts()
    {
        //fruit shop
        levelFruitShopText.text = StaticVariables.levelFruit.ToString() + "/" + (5 + StaticVariables.youWin * 5).ToString();
        energyFruitShopText.text = StaticVariables.currentEnergyFruit.ToString() + "/" + StaticVariables.maxEnergyFruit.ToString();
        coinsFruitShopText.text = StaticVariables.currentCoinsFruit.ToString() + "/" + StaticVariables.coinsToUpgradeFruit.ToString();
        levelFruitShopTextIn.text = levelFruitShopText.text;
        levelFruitShopTextPuz.text = levelFruitShopText.text;
        energyFruitShopTextIn.text = energyFruitShopText.text;
        energyFruitShopTextPuz.text = energyFruitShopText.text;
        coinsFruitShopTextIn.text = coinsFruitShopText.text;
        coinsFruitShopTextPuz.text = coinsFruitShopText.text;

        //flower shop
        levelFlowerShopText.text = StaticVariables.levelFlower.ToString() + "/" + (5 + StaticVariables.youWin * 5).ToString();
        energyFlowerShopText.text = StaticVariables.currentEnergyFlower.ToString() + "/" + StaticVariables.maxEnergyFlower.ToString();
        coinsFlowerShopText.text = StaticVariables.currentCoinsFlower.ToString() + "/" + StaticVariables.coinsToUpgradeFlower.ToString();
        levelFlowerShopTextIn.text = levelFlowerShopText.text;
        levelFlowerShopTextPuz.text = levelFlowerShopText.text;
        energyFlowerShopTextIn.text = energyFlowerShopText.text;
        energyFlowerShopTextPuz.text = energyFlowerShopText.text;
        coinsFlowerShopTextIn.text = coinsFlowerShopText.text;
        coinsFlowerShopTextPuz.text = coinsFlowerShopText.text;

        //food shop
        levelFoodShopText.text = StaticVariables.levelFood.ToString() + "/" + (5 + StaticVariables.youWin * 5).ToString();
        energyFoodShopText.text = StaticVariables.currentEnergyFood.ToString() + "/" + StaticVariables.maxEnergyFood.ToString();
        coinsFoodShopText.text = StaticVariables.currentCoinsFood.ToString() + "/" + StaticVariables.coinsToUpgradeFood.ToString();
        levelFoodShopTextIn.text = levelFoodShopText.text;
        levelFoodShopTextPuz.text = levelFoodShopText.text;
        energyFoodShopTextIn.text = energyFoodShopText.text;
        energyFoodShopTextPuz.text = energyFoodShopText.text;
        coinsFoodShopTextIn.text = coinsFoodShopText.text;
        coinsFoodShopTextPuz.text = coinsFoodShopText.text;
    }

}
