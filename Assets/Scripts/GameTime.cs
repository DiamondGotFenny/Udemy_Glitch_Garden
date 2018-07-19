using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    private Slider timeSlider;
    private bool isLevelEnd;
    private LevelManager levelManger;
    private AudioSource music;
    private GameObject winLan;

    public float levelTime = 100;
    public string nextLevelName;

	// Use this for initialization
	void Start () {
        timeSlider = GetComponent<Slider>();
        levelManger = GameObject.FindObjectOfType<LevelManager>();
        music = GetComponent<AudioSource>();
        FindYouWin();
        winLan.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
        timeSlider.value = Time.timeSinceLevelLoad / levelTime;
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);

        if (timeIsUp&&!isLevelEnd)
        {
            MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
            //GameObject akManager = GameObject.Find("AKSpawners");
            //if (akManager)
            //{
            //    akManager.SetActive(false);
            //}
            GameObject[] attackers = GameObject.FindGameObjectsWithTag("Attacker");          
            foreach (GameObject attacker in attackers)
            {
                if (attacker)
                {
                    Destroy(attacker.gameObject);
                }
            }
            musicManager.StopMusic();
            music.Play();
            winLan.SetActive(true);
            Invoke("loadLevel", music.clip.length);
            isLevelEnd = true;
        }
	}

    void loadLevel()
    {
        levelManger.LoadLevel(nextLevelName);
    }

    void FindYouWin()
    {
        winLan = GameObject.Find("WinLan");
        if (!winLan)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }

   

}
