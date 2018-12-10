using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    private static MenuHandler instance;

    #region EDITOR_VARS

    [SerializeField]
    private Transform menuTransform;
    [SerializeField]
    private Transform hideTransform;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float speed;

    #endregion

    #region PRIVATE_VARS

    private Vector3 showPosition;
    private Vector3 hidePosition;
    private bool hidden = true;

    #endregion

    #region PUBLIC_VARS

    public static MenuHandler Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion

    #region AWAKE/START/UPDATE

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        hidePosition = hideTransform.position;
        showPosition = Vector3.zero;
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public void HideShow()
    {
        StartCoroutine(Move(!hidden));
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private IEnumerator Move(bool hide)
    {
        StopCoroutine("Move");

        int hideValue = (hide == true) ? 1 : -1;
        int startValue = (hide == true) ? -1 : 1;

        float x = hideTransform.localPosition.x;
        float y = hideTransform.localPosition.y;

        for (float time = .0f; time < 1; time += Time.deltaTime * speed)
        {
            menuTransform.localPosition = Vector3.Lerp(new Vector3(x, y * startValue, 0.0f), new Vector3(x, y * hideValue, 0.0f), time);
            yield return null;
        }

        menuTransform.localPosition = new Vector3(x, y * hideValue, 0.0f);

        hidden = !hidden;
    }

    #endregion
}
