using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initializmanager : MonoBehaviour {

    #region Singleton
    private static initializmanager _instance;

    public static initializmanager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<initializmanager>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void initialization()
    {
        UIPersist UIElement = GameObject.FindObjectOfType<UIPersist>();
        DefenderPersist defender = GameObject.FindObjectOfType<DefenderPersist>();
        GameTime gametime = GameObject.FindObjectOfType<GameTime>();
        //  camerapersit camera = GameObject.FindObjectOfType<camerapersit>();
        AKSpawnerControl akspawnControl = GameObject.FindObjectOfType<AKSpawnerControl>();

        Destroy(UIElement.gameObject);
        Destroy(defender.gameObject);
        if (gametime)
        {
            Destroy(gametime.gameObject);
        }
        Destroy(akspawnControl.gameObject);
       // Destroy(camera.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinshedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinshedLoading;
    }

    void OnLevelFinshedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 6 || scene.buildIndex == 7)
        {
            initialization();
        }
    }
}
