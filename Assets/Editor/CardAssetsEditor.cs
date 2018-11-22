using UnityEditor;

[CustomEditor(typeof(CardAsset))]
public class CardAssetsEditor : Editor
{
    #region CONSTS
    private const int MAX_LEVEL = 3;
    private const int MIN_PROP_VALUE = -10;
    private const int MAX_PROP_VALUE = 10;
    #endregion

    public override void OnInspectorGUI()
    {
        var objectBaseAsset = (CardAsset)target;

        
        EditorGUILayout.IntSlider(objectBaseAsset.level, 1, MAX_LEVEL);
    }
}
