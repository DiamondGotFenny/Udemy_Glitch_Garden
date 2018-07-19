using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    GameObject pausedMenu;

   // static LevelManager instance=null;

    //private void Awake()
    //{
    //    if (instance !=null&&instance !=this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        GameObject.DontDestroyOnLoad(gameObject);
    //    }
    //}

    private void Start()
    {
        pausedMenu = GameObject.Find("PausedPanel");
        if (pausedMenu)
        {
            pausedMenu.SetActive(false);
        }

        if (autoLoadNextLevelAfter<=0)
        {
            Debug.Log("level autoload disable,use a positive number is seconds");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }       
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void pausedGame()
    {
        if (pausedMenu)
        {
            pausedMenu.SetActive(true);
            Time.timeScale = 0;
        }
       
    }

    public void contiueGame()
    {
        if (pausedMenu)
        {
            pausedMenu.SetActive(false);
            Time.timeScale = 1;
        }
       
    }
}
