using UnityEngine;

public class TimeHandler : MonoBehaviour {
    
    private float timeSpeed;

    private void Start()
    {
        timeSpeed = GameHandler.Instance.TimeSpeed;
    }

    private void Update()
    {
        
    }
}
