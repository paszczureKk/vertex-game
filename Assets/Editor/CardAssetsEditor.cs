using UnityEditor;


[CustomEditor(typeof(CardAsset), true)]
public class CardAssetsEditor : BaseAssetsEditor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CardAsset objectCardAsset = (CardAsset)target;

        SerializedObject serializedCardAsset = new SerializedObject(objectCardAsset);

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        EditorGUILayout.LabelField("Karma", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Karma:");
            serializedCardAsset.FindProperty("karma").intValue = EditorGUILayout.IntField(objectCardAsset.karma);
        EditorGUILayout.EndHorizontal();

        serializedCardAsset.ApplyModifiedProperties();
    }
}
