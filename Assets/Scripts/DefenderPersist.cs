using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPersist : MonoBehaviour {

    #region Singleton
    private static DefenderPersist _instance;

    public static DefenderPersist Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DefenderPersist>();
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
