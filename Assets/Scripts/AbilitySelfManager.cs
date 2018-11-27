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

    AbilityUsage abilityUsage;

    #endregion

    #region AWAKE/START/UPDATE

    private void Awake()
    {
        abilityUsage = gameObject.GetComponent<AbilityUsage>();
    }

    #endregion
}
