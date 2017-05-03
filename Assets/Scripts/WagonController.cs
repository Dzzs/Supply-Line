using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WagonController : MonoBehaviour {

    public GameObject Player;
    public static GameObject Wagon;
    public GameObject WagonUI;
    public Text[] wagonCountTexts;
    public Text[] playerCountTexts;
    public GameObject NotEnoughSpaceError;
    public GameObject NotEnoughItemsError;
    Collider WagonCollider;
    int[] wagonItems;
    bool nearWagon;
    bool usingWagon;
    bool pullingWagon;

	void Start () {
        Wagon = GameObject.FindGameObjectWithTag("Wagon");
        Wagon.SetActive(false);
        if (Wagon == null)
        {
            Debug.Log("No wagon found");
        }
        nearWagon = false;
        usingWagon = false;
        pullingWagon = false;
        wagonItems = new int[8];
        for (int i = 0; i < 8; i++)
        {
            wagonItems[i] = 0;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wagon")
        {
            Debug.Log("Entered Wagon collider!");
            WagonCollider = other;
            nearWagon = true;
            return;
        }
        if (other.tag == "ShopBarrier")
        {
            if(pullingWagon == true)
            {
                DropWagon();
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wagon")
        {
            if (nearWagon == true)
            {
                WagonCollider = null;
                nearWagon = false;
            }
        }
    }

    public void ExitWagonUI()
    {
        WagonUI.SetActive(false);
        PlayerController.canMove = true;
        Cursor.visible = false;
        usingWagon = false;
    }

    public void SpawnWagon()
    {
        Wagon.SetActive(true);
    }

    public void AddItemToWagon(int item)
    {
        switch (item)
        {
            case 1:
                if(InventoryManager.playerItems[0] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[0] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[0]++;
                    InventoryManager.playerItems[0]--;
                }
                break;
            case 2:
                if (InventoryManager.playerItems[1] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[1] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                wagonItems[1]++;
                InventoryManager.playerItems[1]--;
                }
                break;
            case 3:
                if (InventoryManager.playerItems[2] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[2] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[2]++;
                    InventoryManager.playerItems[2]--;
                }
                break;
            case 4:
                if (InventoryManager.playerItems[3] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[3] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[3]++;
                    InventoryManager.playerItems[3]--;
                }
                break;
            case 5:
                if (InventoryManager.playerItems[4] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[4] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[4]++;
                    InventoryManager.playerItems[4]--;
                }
                break;
            case 6:
                if (InventoryManager.playerItems[5] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[5] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[5]++;
                    InventoryManager.playerItems[5]--;
                }
                break;
            case 7:
                if (InventoryManager.playerItems[6] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[6] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[6]++;
                    InventoryManager.playerItems[6]--;
                }
                break;
            case 8:
                if (InventoryManager.playerItems[6] < 1)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (wagonItems.Sum() >= InventoryManager.currentWagonCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[7] > 0 && wagonItems.Sum() < InventoryManager.currentWagonCapacity)
                {
                    wagonItems[7]++;
                    InventoryManager.playerItems[7]--;
                }
                break;
            default:
                break;
        }
    }

    public void RemoveItemFromWagon(int item)
    {
        switch (item)
        {
            case 1:
                if(wagonItems[0] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[0] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[0] > 0)
                {
                    wagonItems[0]--;
                    InventoryManager.playerItems[0]++;
                }
                break;
            case 2:
                if (wagonItems[1] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[1] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[1] > 0)
                {
                    wagonItems[1]--;
                    InventoryManager.playerItems[1]++;
                }
                break;
            case 3:
                if (wagonItems[2] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[2] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[2] > 0)
                {
                    wagonItems[2]--;
                    InventoryManager.playerItems[2]++;
                }
                break;
            case 4:
                if (wagonItems[3] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[3] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[3] > 0)
                {
                    wagonItems[3]--;
                    InventoryManager.playerItems[3]++;
                }
                break;
            case 5:
                if (wagonItems[4] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[4] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[4] > 0)
                {
                    wagonItems[4]--;
                    InventoryManager.playerItems[4]++;
                }
                break;
            case 6:
                if (wagonItems[5] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[5] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[5] > 0)
                {
                    wagonItems[5]--;
                    InventoryManager.playerItems[5]++;
                }
                break;
            case 7:
                if (wagonItems[6] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[6] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[6] > 0)
                {
                    wagonItems[6]--;
                    InventoryManager.playerItems[6]++;
                }
                break;
            case 8:
                if (wagonItems[7] <= 0)
                {
                    GameObject ErrorText = Instantiate(NotEnoughItemsError, NotEnoughItemsError.transform.position, NotEnoughItemsError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems[7] >= InventoryManager.currentBagCapacity)
                {
                    GameObject ErrorText = Instantiate(NotEnoughSpaceError, NotEnoughSpaceError.transform.position, NotEnoughSpaceError.transform.rotation);
                    ErrorText.transform.SetParent(WagonUI.transform, false);
                    return;
                }
                if (InventoryManager.playerItems.Sum() < InventoryManager.currentBagCapacity && wagonItems[7] > 0)
                {
                    wagonItems[7]--;
                    InventoryManager.playerItems[7]++;
                }
                break;
            default:
                break;
        }
    }

    void DropWagon()
    {
        if (pullingWagon == true)
        {
            Wagon.transform.SetParent(null);
            Wagon.transform.TransformDirection(Wagon.transform.localRotation.x, Wagon.transform.localRotation.y, Wagon.transform.localRotation.z);
            Wagon.transform.eulerAngles = new Vector3(-108, Wagon.transform.eulerAngles.y, Wagon.transform.eulerAngles.z);
            pullingWagon = false;
        }
        return;
    }

	void Update () {

        if (nearWagon == true && UpgradeManager.wagonUnlocked == true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                PlayerController.canMove = false;
                Cursor.visible = true;
                WagonUI.SetActive(true);
                usingWagon = true;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (pullingWagon == false)
                {
                    Debug.Log("Pulling Waogn!");
                    Vector3 wagonOffset = new Vector3(-0.34f, -0.15f, -1.9f);
                    Vector3 wagonRot = new Vector3(-105, 0, 0);
                    Wagon.transform.SetParent(Player.transform);

                    Wagon.transform.localPosition = wagonOffset;
                    Wagon.transform.localEulerAngles = wagonRot;
                    

                    pullingWagon = true;
                    return;
                }
                if(pullingWagon == true)
                {
                    DropWagon();
                    return;
                }
    
            }
        }


        for (int i = 0; i < 8; i++)
        {
            wagonCountTexts[i].text = "" + wagonItems[i];
            playerCountTexts[i].text = "" + InventoryManager.playerItems[i];
        }

	}
}
