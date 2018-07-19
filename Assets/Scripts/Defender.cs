using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {


    private StarDisplay starDisplay;
    public int defenderCost;

	// Use this for initialization
	void Start () {

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        starDisplay.AddStar(amount);
    }
}
