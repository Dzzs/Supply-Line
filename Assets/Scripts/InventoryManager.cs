using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour {

    public Text BagHudText;
    public Text PlayerMoneyText;
    public static int currentBagCapacity;
    public static int currentWagonCapacity;
    public static int playerMoney;
    public static int[] playerItems;
    static int totalPlayerItems;

	void Start () {
        currentBagCapacity = 4;
        currentWagonCapacity = 12;
        totalPlayerItems = 0;
        playerMoney = 510;
        playerItems = new int[8];
        for (int i = 0; i < 8; i++)
        {
            playerItems[i] = 0;
        }
	}
	
	void Update () {

        totalPlayerItems = playerItems.Sum();
        BagHudText.text = "" + totalPlayerItems + "/" + currentBagCapacity;
        PlayerMoneyText.text = "$" + playerMoney;

	}
}
