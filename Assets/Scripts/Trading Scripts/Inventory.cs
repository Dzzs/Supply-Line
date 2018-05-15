using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//coins, fish, fruit, hay, ore, lumber, spices, meat, pasta, silk, potatos, tea, wheat, wine, opium
public class Inventory : MonoBehaviour{

   public static IList<Items> playerItems = new List<Items>()
    {
        new Items(){itemID = 0, itemName = "Coins", basePrice = 1, owned = 300, toTrade = 0, shopPrice = 0, itemDesc = "Money..?"},
        new Items(){itemID = 1, itemName = "Fish", basePrice = 15, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Like birds, but in the water."},
        new Items(){itemID = 2, itemName = "Fruit", basePrice = 5, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "The non cut-your-feet-off source of sugar."},
        new Items(){itemID = 3, itemName = "Hay", basePrice = 5, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Is for horses."},
        new Items(){itemID = 4, itemName = "Ore", basePrice = 20, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Go ask cody."},
        new Items(){itemID = 5, itemName = "Lumber", basePrice = 20, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Horizontal trees without branches or leaves."},
        new Items(){itemID = 6, itemName = "Spices", basePrice = 10, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "One part of the Power Puff Girls."},
        new Items(){itemID = 7, itemName = "Meat", basePrice = 15, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Dead living things parts."},
        new Items(){itemID = 8, itemName = "Pasta", basePrice = 10, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Garbage that gay people eat."},
        new Items(){itemID = 9, itemName = "Silk", basePrice = 20, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Its basically spider cum."},
        new Items(){itemID = 10, itemName = "Potatos", basePrice = 5, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "The same as fruit, but covered in dirt."},
        new Items(){itemID = 11, itemName = "Tea", basePrice = 10, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "The only beverage you'll ever need."},
        new Items(){itemID = 12, itemName = "Wheat", basePrice = 5, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Dead sticks or something."},
        new Items(){itemID = 13, itemName = "Wine", basePrice = 20, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "Fruit after it's been run over by a couple dozen horses."},
        new Items(){itemID = 14, itemName = "Opium", basePrice = 30, owned = 0, toTrade = 0, shopPrice = 0, itemDesc = "DRUGS!"}
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.visible = true;
            PlayerController.canMove = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            for (int i = 1; i < playerItems.Count; i++)
            {
                Debug.Log("Item name = " + playerItems[i].itemName + " Owned = " + playerItems[i].owned);
            }
        }
    }
}


