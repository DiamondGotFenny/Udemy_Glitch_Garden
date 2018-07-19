using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graveStone : MonoBehaviour {

    Animator anmt;
    bool isAttacked=false;
    Health health;
    // Use this for initialization
    void Start () {
        anmt = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        UnderAttacked();
        if (isAttacked&&attacker&&health.health>0)
        {         
                anmt.SetTrigger("Attacked");
        }
    }

    //if you don't want to use collidertrigger, you can use the method that only triggerring the underattacked clip when attacker is attacking. 
    //call this method in attacking animation clip;
    public bool UnderAttacked()
    {
        return isAttacked = true;
    }
}
