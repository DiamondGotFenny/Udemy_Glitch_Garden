using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour {

    public GameObject projectile,  spawner;
    private GameObject projectileParent;
    Animator animt;
    private AKSpawner mySpawner;

    // Use this for initialization
    void Start () {
        projectileParent = GameObject.Find("ProjectileParent");
        if (!projectileParent)
        {
            projectileParent=  new GameObject("ProjectileParent");
        }

        animt = GetComponent<Animator>();
        SetMyLaneSpawner();
    }
	
	// Update is called once per frame
	void Update () {
        if (AttackerInLane())
        {
            animt.SetBool("IsAttacking", true);
        }
        else
        {
            animt.SetBool("IsAttacking", false);
        }
	}

    void FireGun()
    {
        GameObject projectileClone = Instantiate(projectile, spawner.transform.position, Quaternion.identity) as GameObject;
        projectileClone.transform.parent = projectileParent.transform;
    }

    bool AttackerInLane()
    {

        if (!mySpawner)
        {
            SetMyLaneSpawner();
        }
        else
        {
            //if there is no attacker,exit;
            if (mySpawner.transform.childCount <= 0)
            {
                return false;
            }

            //if the attacker ahead defenders? yes return true, no return false;
            foreach (Transform attacker in mySpawner.transform)
            {
                if (attacker.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
       

        //attacker in lane, but behind us.
        return false;
    }

    void SetMyLaneSpawner()
    {
        AKSpawner[] AKSpawnerArray = GameObject.FindObjectsOfType<AKSpawner>();
        
        foreach (AKSpawner spawner in AKSpawnerArray)
        {
            Debug.Log("found spawner");
            if (transform.position.y==spawner.transform.position.y)
            {
                mySpawner = spawner;
                return;
            }
        }

        Debug.LogError("No Spawner found");
    }

   
}
