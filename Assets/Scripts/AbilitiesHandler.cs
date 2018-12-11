using UnityEngine;

public class AbilitiesHandler : MonoBehaviour
{

    #region EDITOR_VARS

    [SerializeField]
    private GameObject window;

    #endregion

    #region PRIVATE_VARS

    bool hidden = true;

    #endregion

    #region PUBLIC_CLASSES
    
    #endregion

    #region PUBLIC_FUNCTIONS

    public void HideShow()
    {
        hidden = !hidden;
        window.SetActive(hidden);
    }

    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion
}
