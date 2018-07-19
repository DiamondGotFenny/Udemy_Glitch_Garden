using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileParentPersist : MonoBehaviour {

    #region Singleton
    private static projectileParentPersist _instance;

    public static projectileParentPersist Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<projectileParentPersist>();
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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
