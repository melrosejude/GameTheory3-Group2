using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesShop : MonoBehaviour
{
    public Transform startingPosition;
    public LaunchBall lbScript;
    public PointsManager pmScript;

    public float bounciness = 100f;

    public void Relaunch()
    {
        lbScript.forceSet = false;
        lbScript.angleSet = false;
        lbScript.launched = false;
        lbScript.myRb.isKinematic = true;
        pmScript.addedPoints = false;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = startingPosition.position;
        AudioManager.instance.playButtonClick();
    }
    
    public void Quit()
    {
        AudioManager.instance.playButtonClick();
        Application.Quit();
    }

    public void UpdateAllButtons()
    {
        UpdateButton(launchPowerButton, launchPowerCostText, launchPowerCost);
        UpdateButton(moneyMultiplierButton, moneyMultiplierCostText, moneyMultiplierCost);
        UpdateButton(cookieBouncinessButton, cookieBouncinessCostText, cookieBouncinessCost);
    }

    private void UpdateButton(Button button, TextMeshProUGUI text, int cost)
    {
        text.text = cost.ToString();
        if (cost <= pmScript.money)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    //Upgrade Launch Power
    public Button launchPowerButton;
    public TextMeshProUGUI launchPowerCostText;
    public int launchPowerCost;
    public void UpgradeLaunchPower()
    {
        AudioManager.instance.playButtonClick();
        lbScript.maxForce += 10f;
        pmScript.money -= launchPowerCost;
        launchPowerCost += launchPowerCost;
        UpdateButton(launchPowerButton, launchPowerCostText, launchPowerCost);
        pmScript.UpdateMoneyDisplay();
    }

    //Upgrade Money Multiplier
    public Button moneyMultiplierButton;
    public TextMeshProUGUI moneyMultiplierCostText;
    public int moneyMultiplierCost;
    public void UpgradeMoneyMultiplier()
    {
        AudioManager.instance.playButtonClick();
        pmScript.moneyMultiplier += 0.05f;
        pmScript.money -= moneyMultiplierCost;
        moneyMultiplierCost += moneyMultiplierCost;
        UpdateButton(moneyMultiplierButton, moneyMultiplierCostText, moneyMultiplierCost);
        pmScript.UpdateMoneyDisplay();
    }

    //Upgrade Cokkie Bounciness
    public Button cookieBouncinessButton;
    public TextMeshProUGUI cookieBouncinessCostText;
    public int cookieBouncinessCost;
    public void UpgradeCookieBounciness()
    {
        AudioManager.instance.playButtonClick();
        bounciness += 100f;
        pmScript.money -= cookieBouncinessCost;
        cookieBouncinessCost += 100;
        UpdateButton(cookieBouncinessButton, cookieBouncinessCostText, cookieBouncinessCost);
        pmScript.UpdateMoneyDisplay();
    }
}
