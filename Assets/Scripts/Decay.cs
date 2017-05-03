using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour {

    public GameObject decayTarget;
    public float decayTimer;
    float currentTimer;

	void Start () {
        currentTimer = 0.0f;
	}
	
	void Update () {

        currentTimer += Time.deltaTime;
        decayTimer -= Time.deltaTime;
        if (decayTimer <= currentTimer)
        {
            Destroy(decayTarget);
        }
	}
}
