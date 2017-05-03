using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithVendor : MonoBehaviour {

    public GameObject VendorUI;
    private Collider vendorCollider;
    public static bool atTrader;
    bool nearTrader;
    public static bool doUpdate;

    private void Start()
    {
        atTrader = false;
        nearTrader = false;
        doUpdate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        vendorCollider = other;
        nearTrader = true;
    }

    private void OnTriggerExit(Collider other)
    {
        vendorCollider = null;
        nearTrader = false;
    }

    private void Update()
    {
        if (nearTrader == true)
        {
            if (vendorCollider.tag == "MountainVendor")
            {
                if (Input.GetKey(KeyCode.F) && atTrader == false)
                {
                    atTrader = true;
                    PlayerController.canMove = false;
                    VendorUI.SetActive(true);
                    Cursor.visible = true;
                    if (atTrader == true && doUpdate == true)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Debug.Log("Trying to set price");
                            TradeManager.itemValues[i] = MountainVendorValues.values[i];
                            Debug.Log("Set price");
                        }
                        doUpdate = false;
                    }
                }
            }

            if (vendorCollider.tag == "ForestVendor")
            {
                if (Input.GetKey(KeyCode.F) && atTrader == false)
                {
                    atTrader = true;
                    PlayerController.canMove = false;
                    VendorUI.SetActive(true);
                    Cursor.visible = true;
                    if (atTrader == true && doUpdate == true)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Debug.Log("Trying to set price");
                            TradeManager.itemValues[i] = ForestVendorValues.values[i];
                            Debug.Log("Set price");
                        }
                        doUpdate = false;
                    }
                }
            }
        }
    }
}
