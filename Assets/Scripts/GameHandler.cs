using UnityEngine;
using System.Collections.Generic;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    #region PRIVATE_VARS

    #endregion

    #region PROPERTIES

    public static GameHandler Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
}
