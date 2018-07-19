using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPersist : MonoBehaviour {

    #region Singleton
    private static UIPersist _instance;

    public static UIPersist Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.FindObjectOfType<UIPersist>();
            }
            return _instance;
        }
    }
    #endregion


    private void Awake()
    {
        if (_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this !=_instance)
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
