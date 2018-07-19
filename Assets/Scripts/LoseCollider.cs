using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

    private int yardHealth = 5;
    private Text yardHealthNm;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        yardHealthNm = GameObject.FindObjectOfType<tagforYH>().GetComponent<Text>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        yardHealthNm.text = yardHealth.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        yardHealth -= 1;
        yardHealthNm.text = yardHealth.ToString();
        Destroy(collision.gameObject, 1f);
        if (yardHealth<=0)
        {
            levelManager.LoadLevel("03a_Lose");
        }
    }
}
