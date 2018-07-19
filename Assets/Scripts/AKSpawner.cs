using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AKSpawner : MonoBehaviour {

    private GameObject[] myGameobjectArray;
    public GameObject[] level01_attackerArray;
    public GameObject[] level02_attackerArray;
    public GameObject[] level03_attackerArray;


    // Use this for initialization
    void Start () {
        myGameobjectArray = level01_attackerArray;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject thisAttacker in myGameobjectArray)
        {
            if (IsTimetoSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject mygameobj)
    {
        GameObject myAttacker = Instantiate(mygameobj) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool IsTimetoSpawn(GameObject thisgameobj)
    {
        Attacker attacker = thisgameobj.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySecond;
        float spawnPerSencond = 1 / meanSpawnDelay;

        if (Time.deltaTime>meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnPerSencond * Time.deltaTime / 5;

        //if (Random.value<threshold)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        //return true;    
        // code above clean up to the following line:

        return (Random.value < threshold);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoad;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoad;
    }

    void OnLevelLoad(Scene scene, LoadSceneMode mode)
    {
       
            if (scene.buildIndex == 3)
            {
                myGameobjectArray = level01_attackerArray;
            }
            if (scene.buildIndex == 4)
            {
                myGameobjectArray = level02_attackerArray;
            }
            if (scene.buildIndex == 5)
            {
            myGameobjectArray = level03_attackerArray;
        }
    }
}
