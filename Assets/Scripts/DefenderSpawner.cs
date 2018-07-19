using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;

    private GameObject defendersParent;

    private StarDisplay starDisplay;

    // Use this for initialization
    void Start () {
        defendersParent = GameObject.Find("Defenders");
        if (!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
        }

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        myCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 rawPosition = CalculateWorldPointofMouseClick();
        Vector2 roundPosition = SnaptoGrid(rawPosition);

        GameObject defender = CreateButton.selectedDefender;
        int defendercost = defender.GetComponent<Defender>().defenderCost;
        if (starDisplay.UseStar(defendercost)==StarDisplay.Status.SUCCESS&&Time.timeScale !=0)
        {
            GameObject defenderClone = Instantiate(defender, roundPosition, Quaternion.identity) as GameObject;
            defenderClone.transform.parent = defendersParent.transform;
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
         }
    }

    Vector2 CalculateWorldPointofMouseClick()
    {
        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;
        float DistanceFromCamera = 10f;

        Vector3 weiredTriplet = new Vector3(MouseX, MouseY, DistanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weiredTriplet);

        return worldPos;
        
    }

    Vector2 SnaptoGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 4 || scene.buildIndex == 5)
        {
            Start();
        }
    }
}
