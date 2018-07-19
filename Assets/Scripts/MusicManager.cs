using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    static MusicManager instance=null;

    [SerializeField] AudioClip[] levelMusicChangeArray;

    AudioSource musicPlay;

    private void Awake()
    {
        #region singleton
        if (instance !=null&instance !=this)
        {
            Destroy(gameObject);
            print("duplicate musicplayer being destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            musicPlay = GetComponent<AudioSource>();
        }
        #endregion

    }
    // Use this for initialization
    void Start () {
        // StartMc.cs no needed, if this line;
                 musicPlay.volume= PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	void Update () {
		
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
        AudioClip audioclip = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing Clip: " + audioclip.name);
        musicPlay.Stop();

        if (audioclip)
        {
            musicPlay.clip = audioclip;
        }

        if (scene.buildIndex !=0)
        {
            musicPlay.loop = true;
        }
        musicPlay.Play();
    }

    public void ChangeVolume(float value)
    {
        if (value>=0&&value<=1)
        {
            musicPlay.volume = value;
        }
    }

    public void StopMusic()
    {
        musicPlay.Stop();
    }
}
