﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSellButton : MonoBehaviour {

    [SerializeField]
    private Text myText;
    [SerializeField]
    private ShopButtonController shopController;

    private int buttonID;

    Inventory playerInventory = new Inventory();

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void SetButtonID(int ID)
    {
        buttonID = ID;
    }

    public void DoOnClick()
    {
        shopController.RemoveItemClick(buttonID + 1);
    }
}
