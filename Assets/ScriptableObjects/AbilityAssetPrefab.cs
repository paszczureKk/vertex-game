using UnityEngine;
using UnityEditor;

public class AbilityAssetPrefab : EditorWindow
{
    #region CONSTS

    private static string path = "Assets/PreFabs/AbilityPrefab.prefab";

    #endregion

    [MenuItem("Assets/Create/Assets/AbilityPrefab")]
    public static void CreatePrefab()
    {
        GameObject gameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        //Set the path as within the Assets folder, and name it as the GameObject's name with the .prefab format
        string localPath = "Assets/Resources/Abilities/New" + gameObject.name + ".prefab";

        //Check if the Prefab and/or name already exists at the path
        if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
        {
            //Create dialog to ask if User is sure they want to overwrite existing prefab
            if (EditorUtility.DisplayDialog("Are you sure?",
                    "The prefab already exists. Do you want to overwrite it?",
                    "Yes",
                    "No"))
            //If the user presses the yes button, create the Prefab
            {
                Object prefab = PrefabUtility.CreatePrefab(localPath, gameObject);
                PrefabUtility.ReplacePrefab(gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
            }
        }
        //If the name doesn't exist, create the new Prefab
        else
        {
            Debug.Log(gameObject.name + " is not a prefab, will convert");
            Object prefab = PrefabUtility.CreatePrefab(localPath, gameObject);
            PrefabUtility.ReplacePrefab(gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
        }
    }
}
