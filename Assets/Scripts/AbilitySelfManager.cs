using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelfManager : MonoBehaviour
{
    #region EDITOR_VARS

    [SerializeField]
    private AbilityAsset abilityData;

    #endregion

    #region PRIVATE_VARS

    private AbilityUsage abilityUsage;
    private Color karmaColor;

    #endregion

    #region AWAKE/START/UPDATE

    private void Awake()
    {
        abilityUsage = gameObject.GetComponent<AbilityUsage>();
    }

    #endregion
}
