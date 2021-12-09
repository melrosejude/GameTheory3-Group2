using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int money;

    public Transform startPosition;
    public GameObject upgradesPanel;
    public TextMeshProUGUI availableMoneyText;
    public UpgradesShop upgradeScript;
    public LaunchBall lbScript;
    public bool addedPoints = false;

    private float _distanceTraveled;

    void Update()
    {
        _distanceTraveled = transform.position.x - startPosition.position.x;
        if(gameObject.GetComponent<Rigidbody2D>().IsSleeping() && addedPoints == false && lbScript.launched == true)
        {
            addedPoints = true;
            money += Mathf.RoundToInt(_distanceTraveled/10);
            upgradesPanel.SetActive(true);
            UpdateMoneyDisplay();
            upgradeScript.UpdateAllButtons();
        }
    }

    public void UpdateMoneyDisplay()
    {
        availableMoneyText.text = money.ToString();
    }
}
