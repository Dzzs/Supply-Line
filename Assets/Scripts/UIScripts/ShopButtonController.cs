using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShopButtonController : MonoBehaviour {

    [SerializeField]
    private GameObject parentObject;
    [SerializeField]
    private GameObject buyField;
    [SerializeField]
    private GameObject sellField;
    [SerializeField]
    private GameObject itemNameText;
    [SerializeField]
    private GameObject itemDescText;
    [SerializeField]
    private GameObject itemCountText;
    [SerializeField]
    private GameObject itemsToTradeText;

    public Text totalCost;
    public Text coins;

    //static Inventory playerInventory = new Inventory();
    static Trading trading = new Trading();

    //Array of text objects for to reference when updating UI !! If using playerItems.count you MUST - 1 !!
    GameObject[] itemText = new GameObject[Inventory.playerItems.Count - 1];
    //GameObject[] toTradeText = new GameObject[Inventory.playerItems.Count - 1];
    GameObject[] bField = new GameObject[Inventory.playerItems.Count - 1];
    GameObject[] sField = new GameObject[Inventory.playerItems.Count - 1];
    GameObject[] itemCount = new GameObject[Inventory.playerItems.Count - 1];
    GameObject[] itemDesc = new GameObject[Inventory.playerItems.Count - 1];

    private void Start()
    {
        for (int i = 1; i < Inventory.playerItems.Count; i++)
        {

            itemText[i - 1] = Instantiate(itemNameText) as GameObject;
            // toTradeText[i - 1] = Instantiate(itemsToTradeText) as GameObject;
            bField[i - 1] = Instantiate(buyField) as GameObject;
            sField[i - 1] = Instantiate(sellField) as GameObject;
            itemCount[i - 1] = Instantiate(itemCountText) as GameObject;
            itemDesc[i - 1] = Instantiate(itemDescText) as GameObject;
            bField[i - 1].SetActive(true);
            sField[i - 1].SetActive(true);
            itemText[i - 1].SetActive(true);
            itemCount[i - 1].SetActive(true);
            //toTradeText[i - 1].SetActive(true);
            itemDesc[i - 1].SetActive(true);

            itemText[i - 1].GetComponent<ItemNameTextScript>().SetText("" + Inventory.playerItems[i].itemName);
            itemCount[i - 1].GetComponent<ItemCountTextScript>().SetText("x" + Inventory.playerItems[i].owned);
            bField[i - 1].GetComponent<ItemBuyButton>().SetText("Buy");
            bField[i - 1].GetComponent<ItemBuyButton>().SetButtonID(i - 1);
            sField[i - 1].GetComponent<ItemSellButton>().SetText("Sell");
            sField[i - 1].GetComponent<ItemSellButton>().SetButtonID(i - 1);
            // toTradeText[i - 1].GetComponent<ItemToTradeTextScript>().SetText("x" + Inventory.playerItems[i].toTrade);
            itemDesc[i - 1].GetComponent<ItemNameTextScript>().SetText("" + Inventory.playerItems[i].itemDesc);

            bField[i - 1].transform.SetParent(buyField.transform.parent, false);
            sField[i - 1].transform.SetParent(sellField.transform.parent, false);
            itemCount[i - 1].transform.SetParent(itemCountText.transform.parent, false);
            itemText[i - 1].transform.SetParent(itemNameText.transform.parent, false);
            itemDesc[i - 1].transform.SetParent(itemNameText.transform.parent, false);

            //toTradeText[i - 1].transform.SetParent(itemsToTradeText.transform.parent, false);

        }
    }

    public void UpdateUI()
    {
        for (int i = 1; i < Inventory.playerItems.Count; i++)
        {
            itemText[i - 1].GetComponent<ItemNameTextScript>().SetText("" + Inventory.playerItems[i].itemName);
            itemCount[i - 1].GetComponent<ItemCountTextScript>().SetText("x" + Inventory.playerItems[i].owned);
            totalCost.text = "Total: " + Trading.total;
            coins.text = "Coins: " + Inventory.playerItems[0].owned;
            //toTradeText[i - 1].GetComponent<ItemToTradeTextScript>().SetText("x" + Inventory.playerItems[i].toTrade);
        }
    }

    public void AddItemClick(int id)
    {
        UpdateUI();
        Inventory.playerItems[id].toTrade++;
    }

    public void RemoveItemClick(int id)
    {
        UpdateUI();
        if (Inventory.playerItems[id].toTrade > 0)
        {
            Inventory.playerItems[id].toTrade--;
        }
    }

    private void Update()
    {
        //UpdateUI();

    }
}
