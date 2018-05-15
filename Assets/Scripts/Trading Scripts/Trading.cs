using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trading : MonoBehaviour {

    //static Inventory playerInventory = new Inventory();

    public static int total;

    public void BuyItems()
    {
        for (int i = 1; i < Inventory.playerItems.Count; i++)
        {
           if (Inventory.playerItems[0].owned >= (Inventory.playerItems[i].toTrade * Inventory.playerItems[i].shopPrice))
            {
                Inventory.playerItems[i].owned += Inventory.playerItems[i].toTrade;
                Inventory.playerItems[0].owned -= (Inventory.playerItems[i].toTrade * Inventory.playerItems[i].basePrice);//Update to use shop price
                Inventory.playerItems[i].toTrade = 0;
            }
            else if (Inventory.playerItems[0].owned < (Inventory.playerItems[i].toTrade * Inventory.playerItems[i].shopPrice))
            {
                Debug.LogError("Not enough money for trade: " + Inventory.playerItems[i].itemName);
            }
        }
    }

    void FindTotal()
    {
        total = 0;
        for (int i = 1; i < Inventory.playerItems.Count; i++)
        {
            total = total + (Inventory.playerItems[i].toTrade * Inventory.playerItems[i].basePrice);
        }
    }

    private void Update()
    {
        FindTotal();
    }

}
