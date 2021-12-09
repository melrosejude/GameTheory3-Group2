using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public float money;
    public float moneyEarned;
    public float moneyMultiplier = 1;

    public GameObject finishLine;
    public Transform startPosition;
    public GameObject moneyEarnedPanel;
    public TextMeshProUGUI availableMoneyText;
    public TextMeshProUGUI distanceTraveledText;
    public TextMeshProUGUI distanceTraveledMoneyEarnedText;
    public TextMeshProUGUI moneyMultiplierText;
    public TextMeshProUGUI totalMoney;
    public UpgradesShop upgradeScript;
    public LaunchBall lbScript;
    public bool addedPoints = false;

    private float _distanceTraveled;

    void Update()
    {
        if(gameObject.transform.position.x >= finishLine.transform.position.x)
        {
            SceneManager.LoadScene("Game Over");
        }

        _distanceTraveled = transform.position.x - startPosition.position.x;
        distanceTraveledText.text = "Distance: " + Mathf.RoundToInt(_distanceTraveled) + " m";

        if(gameObject.GetComponent<Rigidbody2D>().IsSleeping() && addedPoints == false && lbScript.launched == true)
        {
            DisplayMoneyEarned();
        }
    }

    public void UpdateMoneyDisplay()
    {
        availableMoneyText.text = money.ToString();
    }

    void DisplayMoneyEarned()
    {
        addedPoints = true;
        moneyEarnedPanel.SetActive(true);

        moneyEarned = Mathf.RoundToInt(_distanceTraveled / 10);
        distanceTraveledMoneyEarnedText.text = moneyEarned.ToString();
        moneyMultiplierText.text = moneyMultiplier.ToString();
        moneyEarned *= moneyMultiplier;
        Mathf.RoundToInt(moneyEarned);
        totalMoney.text = moneyEarned.ToString();
        money += moneyEarned;
        UpdateMoneyDisplay();
        upgradeScript.UpdateAllButtons();
    }
}
