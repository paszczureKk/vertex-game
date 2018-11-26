using UnityEditor;

[CustomEditor(typeof(EventAsset), true)]
public class EventAssetsEditor : BaseAssetsEditor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EventAsset objectEventAsset = (EventAsset)target;

        SerializedObject serializedEventAsset = new SerializedObject(objectEventAsset);

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Reward", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Reward:");
        serializedEventAsset.FindProperty("reward").intValue = EditorGUILayout.IntField(objectEventAsset.reward);
        EditorGUILayout.EndHorizontal();

        serializedEventAsset.ApplyModifiedProperties();
    }
}
