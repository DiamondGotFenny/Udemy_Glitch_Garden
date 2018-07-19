using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class fox : MonoBehaviour {


    Animator anmt;
    Attacker attacker;

    // Use this for initialization
    void Start()
    {
        anmt = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Leave the method if not colliding with defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<graveStone>())
        {
            anmt.SetTrigger("Jumping");
        }
        else
        {
            attacker.Attack(obj);
            anmt.SetBool("IsAttacking", true);         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Defender")
        {
            anmt.SetBool("IsAttacking", false);
        }
    }
}
