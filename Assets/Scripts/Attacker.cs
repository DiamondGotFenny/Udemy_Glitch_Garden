using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySecond;

     float currentSpeed;
    GameObject currentTarget;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        //another way set attacking animation back to false
        //if (!currentTarget)
        //{
        // Set Animator condition attack to false here 
        //anmt.SetBool("IsAttacking", false);
        //}

    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health DHealth= currentTarget.GetComponent<Health>();
            if (DHealth)
            {
                DHealth.DealDamage(damage);
            }
        }

    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
