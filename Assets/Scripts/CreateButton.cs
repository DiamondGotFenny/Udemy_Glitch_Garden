using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour {

    public GameObject defenderPrefeb;
    public static GameObject selectedDefender;

    private CreateButton[] buttonArray;
    private Text costText;

    private Defender defender;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<CreateButton>();
        costText = GetComponentInChildren<Text>();
        defender = defenderPrefeb.GetComponent<Defender>();
        if (costText)
        {
            costText.text = defender.defenderCost.ToString();
        }
        else
        {
            Debug.LogError(name+" has no cost text!");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //set all the defender button sprites to black in editor before start.
        foreach (CreateButton thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefeb;
        print(selectedDefender);
    }
}
