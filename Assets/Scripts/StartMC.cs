using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMC : MonoBehaviour {
    // no longer need this script and object if you add this line:
    //"PlayerPrefsManager.GetMasterVolume();" to musicManager Start();
    MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        if (musicManager)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.ChangeVolume(volume);
        }
        else
        {
            Debug.LogError("No Music Manager Found At Start Scene, Can't Get Volume");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
