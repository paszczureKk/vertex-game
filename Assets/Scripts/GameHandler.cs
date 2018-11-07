using UnityEngine;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    [Range(1.0f,10.0f)]
    [SerializeField]
    private float timeSpeed = 5.0f;

    #region PROPERTIES

    public static GameHandler Instance
    {
        get
        {
            return instance;
        }
    }

    public float TimeSpeed
    {
        get
        {
            return timeSpeed;
        }
        set
        {
            timeSpeed = value;
            if (timeSpeed < 1.0f) timeSpeed = 1.0f;
            if (timeSpeed > 10.0f) timeSpeed = 10.0f;
            
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
