using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour {

    private static MessageHandler instance;

    #region PRIVATE_VARS

    public delegate void V0Function();
    V0Function acceptFunction;
    V0Function rejectFunction;


    #endregion

    #region EDITOR_VARS

    [SerializeField]
    private List<GameObject> windows;
    [SerializeField]
    private List<Text> titles;
    [SerializeField]
    private List<Text> descriptions;
    [SerializeField]
    private GameObject overlay;

    #endregion

    #region PUBLIC_VARS

    public enum CustomMessageTypes
    {
        yesno
    }

    #endregion

    #region PROPERTIES

    public static MessageHandler Instance
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
    
    #endregion

    #region PUBLIC_FUNCTIONS

    public void ShowWindow(CustomMessageTypes messageType, string titleText, string descriptionText, V0Function acceptFunctionRef, V0Function rejectFunctionRef = null)
    {
        titles[(int)(messageType)].text = titleText;
        descriptions[(int)(messageType)].text = descriptionText;
        acceptFunction = acceptFunctionRef;
        rejectFunction = rejectFunctionRef;

        overlay.SetActive(true);
        windows[(int)(messageType)].SetActive(true);
    }

    public void AcceptButton()
    {
        acceptFunction();

        Close();
    }

    public void RejectButton()
    {
        if (rejectFunction != null)
            rejectFunction();

        Close();
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private void Close()
    {
        overlay.SetActive(false);

        foreach (GameObject window in windows)
            window.SetActive(false);
    }

    #endregion

}
