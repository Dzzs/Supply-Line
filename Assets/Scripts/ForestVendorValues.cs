using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ForestVendorValues : MonoBehaviour {

    public int minPrice;
    public int maxPrice;
    public static int[] values;
    float updatePriceTimer;
    float randomUpdateTimer;

    private void Start()
    {
        values = new int[8];
        for (int i = 0; i < 8; i++)
        {
            values[i] = 0;
        }
        updatePriceTimer = 1000000.0f;
        RandomizeUpdateTime();
    }

    private void Update()
    {
        updatePriceTimer += Time.deltaTime;
        if(updatePriceTimer > randomUpdateTimer)
        {
            UpdatePrices();
            updatePriceTimer = 0.0f;
        }
        InteractWithVendor.doUpdate = true;
    }

    public int GetValue(int arrayPos)
    {
        Debug.Log(values[arrayPos]);
        return values[arrayPos];
    }

    private void UpdatePrices()
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(minPrice, maxPrice + 1);
        }
    }

    private void RandomizeUpdateTime()
    {
        randomUpdateTimer = Random.Range(1800.0f, 6001.0f);
    }
}
