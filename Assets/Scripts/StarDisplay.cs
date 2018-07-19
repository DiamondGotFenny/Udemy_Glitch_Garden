using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starAmount;

    public  int stars;

    public enum Status { SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
        starAmount = GetComponent<Text>();
           // stars = 100;
        starAmount.text = stars.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStar(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStar(int amount)
    {
        if (stars>=amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starAmount.text = stars.ToString();
    }

    //注意，这里不要用 starAmount.text=0.ToString() 或者starAmount.text=amount.ToString(), 一定通过一个int variable;
}
