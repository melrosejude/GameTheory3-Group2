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

    public Button launchPowerButton;
    public TextMeshProUGUI launchPowerCostText;
    public int launchPowerCost;

    public void Relaunch()
    {
        lbScript.forceSet = false;
        lbScript.angleSet = false;
        lbScript.launched = false;
        pmScript.addedPoints = false;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = startingPosition.position;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateAllButtons()
    {
        UpdateButton(launchPowerButton, launchPowerCostText, launchPowerCost);
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

    public void UpgradeLaunchPower()
    {
        lbScript.maxForce *= 1.1f;
        pmScript.money -= launchPowerCost;
        launchPowerCost += launchPowerCost;
        UpdateButton(launchPowerButton, launchPowerCostText, launchPowerCost);
        pmScript.UpdateMoneyDisplay();
    }
}
