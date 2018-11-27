using UnityEngine;
using System.Collections.Generic;
using System;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    #region PRIVATE_VARS

    private Dictionary<ElementsTypes.ElementType, Sprite> elementsImages;

    #endregion
    
    #region PROPERTIES

    public Dictionary<ElementsTypes.ElementType, Sprite> ElementsImages
    {
        get
        {
            return elementsImages;
        }
    }

    public static GameHandler Instance
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

        elementsImages = new Dictionary<ElementsTypes.ElementType, Sprite>();

        foreach (ElementsTypes.ElementType type in Enum.GetValues(typeof(ElementsTypes.ElementType)))
            elementsImages.Add(type, Resources.Load<Sprite>("ElementsImages/" + type.ToString()));

        LoadGame();
    }

    #endregion

    #region PUBLIC_FUNCTIONS

    public void GameOver()
    {

    }

    #endregion

    #region PRIVATE_FUNCTIONS

    private void LoadGame()
    {
        if(PlayerPrefs.HasKey("game"))
        {
            //zaladuj gre
        }
        else
        {
            //zainicjuj gre
        }
    }

    #endregion

}
