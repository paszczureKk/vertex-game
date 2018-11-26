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

        EditorGUILayout.LabelField("Event Clear", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Reward:");
        serializedEventAsset.FindProperty("reward").intValue = EditorGUILayout.IntField(objectEventAsset.reward);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Pentaly per point:");
        serializedEventAsset.FindProperty("pentaly").intValue = EditorGUILayout.IntField(objectEventAsset.pentaly);
        EditorGUILayout.EndHorizontal();

        serializedEventAsset.ApplyModifiedProperties();
    }
}
