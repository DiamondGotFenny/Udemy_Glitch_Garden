using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerapersit : MonoBehaviour {

    #region Singleton
    private static camerapersit _instance;

    public static camerapersit Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<camerapersit>();
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
}
