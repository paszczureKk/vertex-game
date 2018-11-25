using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(BaseAsset), true)]
public class BaseAssetsEditor : Editor
{
    #region CONSTS
    private const int MAX_LEVEL = 3;
    private const int MIN_PROP_VALUE = -10;
    private const int MAX_PROP_VALUE = 10;
    #endregion

    private int triggeredCount;

    public override void OnInspectorGUI()
    {
        var objectBaseAsset = (BaseAsset)target;

        SerializedObject serializedBaseAsset = new SerializedObject(objectBaseAsset);

        EditorGUILayout.HelpBox("Don't forget to save [ctrl+s] changes!", MessageType.Info);

        #region MAIN

        EditorGUILayout.LabelField("Main", EditorStyles.boldLabel);
        
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Level:");
            objectBaseAsset.level = EditorGUILayout.IntSlider(objectBaseAsset.level, 1, MAX_LEVEL);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name:");
            objectBaseAsset.cardName = EditorGUILayout.TextField(objectBaseAsset.cardName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Image:");
            objectBaseAsset.image = (Sprite)EditorGUILayout.ObjectField(objectBaseAsset.image, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Description:");
            objectBaseAsset.description = EditorGUILayout.TextArea(objectBaseAsset.description, GUILayout.Height(100));

        #endregion
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        #region PROPERTIES

        EditorGUILayout.LabelField("Properties", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        triggeredCount = 0;
        foreach(ElementsTypes.ElementType type in Enum.GetValues(typeof(ElementsTypes.ElementType)))
        {
            if ((int)objectBaseAsset.GetType().GetField(type.ToString()).GetValue(objectBaseAsset) != 0)
                triggeredCount++;
        }

        foreach (ElementsTypes.ElementType property in Enum.GetValues(typeof(ElementsTypes.ElementType)))
        {
            EditorGUI.BeginDisabledGroup(((int)objectBaseAsset.GetType().GetField(property.ToString()).GetValue(objectBaseAsset) == 0)
                                            && (objectBaseAsset.level <= triggeredCount));
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField(property.ToString() + ":");

                    SerializedProperty serializedProperty = serializedBaseAsset.FindProperty(property.ToString());
                    serializedProperty.intValue = EditorGUILayout.IntSlider(serializedProperty.intValue, MIN_PROP_VALUE, MAX_PROP_VALUE);
                    serializedBaseAsset.ApplyModifiedProperties();

                EditorGUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
        }

        #endregion

        if (triggeredCount > objectBaseAsset.level)
            EditorGUILayout.HelpBox("Number of properties can not exceed object's level!", MessageType.Warning);

        PrefabUtility.RecordPrefabInstancePropertyModifications(objectBaseAsset);
    }
}