using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {
    public Slider volumeSlider;
    public Slider difficultySlider;

    public LevelManager levelManager;
    MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        if (musicManager)
        {
            musicManager.ChangeVolume(volumeSlider.value);
        }
	}

    public void SaveandExite()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        print(PlayerPrefsManager.GetDifficulty());

        levelManager.LoadLevel("01a_menu");
    }

    public void SetDefault()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 1;
    }

}
