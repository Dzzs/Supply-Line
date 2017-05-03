using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Text BagUpgradeText;
    public Text WagonUpgradeText;
    public Text WagonButtonText;
    public GameObject NotEnoughMoneyError;
    public GameObject UpgradeUI;
    private Collider UpgradeVendorCollider;
    static int bagUpgradeCost;
    static int currentBagTier;
    public static bool wagonUnlocked;
    static int wagonUpgradeCost;
    static int currentWagonTier;
    private bool nearUpgradeVendor;


    void Start () {
        bagUpgradeCost = 150;
        wagonUnlocked = false;
        currentBagTier = 1;
        wagonUpgradeCost = 500;
        currentWagonTier = 0;
        nearUpgradeVendor = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        UpgradeVendorCollider = other;
        nearUpgradeVendor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        nearUpgradeVendor = false;
        UpgradeVendorCollider = null;
    }

    public void UpgradeBag()
    {
        if (InventoryManager.playerMoney < bagUpgradeCost)
        {
            Debug.Log("Not enough money!");
            GameObject ErrorText = Instantiate(NotEnoughMoneyError, NotEnoughMoneyError.transform.position, NotEnoughMoneyError.transform.rotation);
            ErrorText.transform.SetParent(UpgradeUI.transform, false);
            return;
        }
        if (InventoryManager.playerMoney >= bagUpgradeCost)
        {
            currentBagTier++;
            InventoryManager.currentBagCapacity++;
            InventoryManager.playerMoney -= bagUpgradeCost;
            if (currentBagTier == 2)
            {
                bagUpgradeCost += 50;
            }
            if (currentBagTier > 2)
            {
                bagUpgradeCost += 100;
            }
        }
    }

    public void UpgradeWagon()
    {
        if (InventoryManager.playerMoney < wagonUpgradeCost)
        {
            Debug.Log("Not enough money!");
            GameObject ErrorText = Instantiate(NotEnoughMoneyError, NotEnoughMoneyError.transform.position, NotEnoughMoneyError.transform.rotation);
            ErrorText.transform.SetParent(UpgradeUI.transform, false);
            return;
        }
        if (InventoryManager.playerMoney >= wagonUpgradeCost)
        {
            if (currentWagonTier > 0 && wagonUnlocked == true)
            {
                InventoryManager.playerMoney -= wagonUpgradeCost;
                if (currentWagonTier == 2)
                {
                    wagonUpgradeCost = 1000;
                }
                currentWagonTier++;
                InventoryManager.currentWagonCapacity += 2;

            }
            if (currentWagonTier == 0 && wagonUnlocked == false)
            {
                InventoryManager.playerMoney -= wagonUpgradeCost;
                wagonUnlocked = true;
                WagonController.Wagon.SetActive(true);
                currentWagonTier = 1;
                wagonUpgradeCost = 750;
                WagonButtonText.text = "Upgrade Wagon";
            }
            if(currentWagonTier > 2)
            {
                wagonUpgradeCost += 500;
            }
        }
    }

    public void ExitUpgradeVendor()
    {
        UpgradeUI.SetActive(false);
        PlayerController.canMove = true;
        Cursor.visible = false;
    }

	void Update () {

        if (nearUpgradeVendor == true && UpgradeVendorCollider.tag == "UpgradeVendor")
        {
            if (Input.GetKey(KeyCode.F))
            {
                PlayerController.canMove = false;
                Cursor.visible = true;
                UpgradeUI.SetActive(true);
            }    
        }
        BagUpgradeText.text = "$" + bagUpgradeCost + "\n+1 Capacity";
        if(currentWagonTier == 0)
        {
            WagonUpgradeText.text = "$" + wagonUpgradeCost + "\n 12 Capacity";
        }
        if(currentWagonTier > 0)
        {
            WagonUpgradeText.text = "$" + wagonUpgradeCost + "\n +2 Capacity";
        }


	}
}
