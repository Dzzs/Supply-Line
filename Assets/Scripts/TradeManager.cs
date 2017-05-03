using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class TradeManager : MonoBehaviour
{
    public Text totalAndValue;
    public GameObject VendorUI;
    public GameObject[] Errors; //Error 1 = not enough money / Error 2 = not enough space / Error 3 = not enough items to sell
    public Text[] tradeItemsCount;
    public Text[] ownedItemsCount;
    public Text[] itemPriceText;
    public int[] tradeItems;
    public static int[] itemValues;
    int totalTradeItems;
    int totalValue;

    public enum Vendors
    {
        Mountain,
        Forest
    };

    void Start()
    {
        itemValues = new int[8];
        for (int i = 0; i < 8; i++)
        {
            itemValues[i] = 0;
        }
    }

    public void ExitVendor()
    {
        InteractWithVendor.atTrader = false;
        VendorUI.SetActive(false);
        Cursor.visible = false;
        PlayerController.canMove = true;
        for (int i = 0; i < 8; i++)
        {
            tradeItems[i] = 0;
        }
    }

    public void AddItem(int item)
    {
        switch (item)
        {
            case 1:
                tradeItems[0]++;
                break;
            case 2:
                tradeItems[1]++;
                break;
            case 3:
                tradeItems[2]++;
                break;
            case 4:
                tradeItems[3]++;
                break;
            case 5:
                tradeItems[4]++;
                break;
            case 6:
                tradeItems[5]++;
                break;
            case 7:
                tradeItems[6]++;
                break;
            case 8:
                tradeItems[7]++;
                break;
            default:
                break;
        }
        FindTotalTradeItems();
        FindTotalValue();
    }

    public void RemoveItem(int item)
    {
        switch (item)
        {
            case 1:
                if (tradeItems[0] > 0)
                {
                    tradeItems[0]--;
                }
                break;
            case 2:
                if (tradeItems[1] > 0)
                {
                    tradeItems[1]--;
                }
                break;
            case 3:
                if (tradeItems[2] > 0)
                {
                    tradeItems[2]--;
                }
                break;
            case 4:
                if (tradeItems[3] > 0)
                {
                    tradeItems[3]--;
                }
                break;
            case 5:
                if (tradeItems[4] > 0)
                {
                    tradeItems[4]--;
                }
                break;
            case 6:
                if (tradeItems[5] > 0)
                {
                    tradeItems[5]--;
                }
                break;
            case 7:
                if (tradeItems[6] > 0)
                {
                    tradeItems[6]--;
                }
                break;
            case 8:
                if (tradeItems[7] > 0)
                {
                    tradeItems[7]--;
                }
                break;
            default:
                break;
        }
        FindTotalTradeItems();
        FindTotalValue();
    }

    public void Buy()
    {
            FindTotalTradeItems();
            FindTotalValue();
            if (totalValue > InventoryManager.playerMoney)
            {
                Debug.Log("Not enough money!");
                GameObject ErrorText = Instantiate(Errors[0], Errors[0].transform.position, Errors[0].transform.rotation);
                ErrorText.transform.SetParent(VendorUI.transform, false);
                return;
            }
            if (totalTradeItems + InventoryManager.playerItems.Sum() > InventoryManager.currentBagCapacity)
            {
                Debug.Log("Not enough space!");
                GameObject ErrorText = Instantiate(Errors[1], Errors[1].transform.position, Errors[1].transform.rotation);
                ErrorText.transform.SetParent(VendorUI.transform, false);
                return;
            }
            if (totalValue <= InventoryManager.playerMoney && totalTradeItems + InventoryManager.playerItems.Sum() <= InventoryManager.currentBagCapacity)
            {
                for (int i = 0; i < tradeItems.Length; i++)
                {
                    InventoryManager.playerItems[i] += tradeItems[i];
                    InventoryManager.playerMoney -= itemValues[i] * tradeItems[i];
                }
                Debug.Log("Purchase complete.");
                for (int i = 0; i < 8; i++)
                {
                    tradeItems[i] = 0;
                }
            }
        FindTotalTradeItems();
        FindTotalValue();
    }

    public void Sell()
    {
        FindTotalTradeItems();
        FindTotalValue();
        bool canSell = true;
        if(InventoryManager.playerItems.Sum() < totalTradeItems)
        {
            Debug.Log("Not enough items!");
            GameObject ErrorText = Instantiate(Errors[2], Errors[2].transform.position, Errors[2].transform.rotation);
            ErrorText.transform.SetParent(VendorUI.transform, false);
            return;
        }
        for (int i = 0; i < 8; i++)
        {
            if (InventoryManager.playerItems[i] < tradeItems[i])
            {
                canSell = false;
            }
        }
        if (canSell == true)
        {
            for (int i = 0; i < InventoryManager.playerItems.Length; i++)
            {
                if (InventoryManager.playerItems[i] >= tradeItems[i])
                {
                    InventoryManager.playerItems[i] -= tradeItems[i];
                    InventoryManager.playerMoney += itemValues[i] * tradeItems[i];
                }
            }
            Debug.Log("Sale complete.");
            for (int i = 0; i < 8; i++)
            {
                tradeItems[i] = 0;
            }
        }
        FindTotalTradeItems();
        FindTotalValue();
    }

    void FindTotalTradeItems()
    {
        totalTradeItems = 0;
        for (int i = 0; i < tradeItems.Length; i++)
        {
            totalTradeItems += tradeItems[i];
        }
    }

    void FindTotalValue()
    {
        totalValue = 0;
        for (int i = 0; i < itemValues.Length; i++)
        {
            totalValue += itemValues[i] * tradeItems[i];
        }
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        totalAndValue.text = "Total Items: " + totalTradeItems + 
                             "\nInventory: " + InventoryManager.playerItems.Sum() + "/" + InventoryManager.currentBagCapacity + 
                             "\nValue: $" + totalValue + 
                             "\nYou have: $" + InventoryManager.playerMoney;

        for (int i = 0; i < 8; i++)
        {
            tradeItemsCount[i].text = "" + tradeItems[i];
            if (InventoryManager.playerItems[i] > 0)
            {
                ownedItemsCount[i].text = "" + InventoryManager.playerItems[i];
            }
            else if (InventoryManager.playerItems[i] <= 0)
            {
                ownedItemsCount[i].text = "";
            }
            itemPriceText[i].text = "$" + itemValues[i];
        }
    }
}
