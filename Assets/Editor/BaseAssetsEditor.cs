using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseAsset), true)]
public class BaseAssetsEditor : Editor
{
    #region CONSTS
    private const int MAX_LEVEL = 3;
    private const int MIN_PROP_VALUE = -10;
    private const int MAX_PROP_VALUE = 10;
    #endregion

    public override void OnInspectorGUI()
    {
        var objectBaseAsset = (BaseAsset)target;

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

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Fire:");
            objectBaseAsset.fire = EditorGUILayout.IntSlider(objectBaseAsset.fire, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Water:");
            objectBaseAsset.water = EditorGUILayout.IntSlider(objectBaseAsset.water, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Air:");
            objectBaseAsset.air = EditorGUILayout.IntSlider(objectBaseAsset.air, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Earth:");
            objectBaseAsset.earth = EditorGUILayout.IntSlider(objectBaseAsset.earth, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Power:");
            objectBaseAsset.power = EditorGUILayout.IntSlider(objectBaseAsset.power, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Spirit:");
            objectBaseAsset.spirit = EditorGUILayout.IntSlider(objectBaseAsset.spirit, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Curse:");
            objectBaseAsset.curse = EditorGUILayout.IntSlider(objectBaseAsset.curse, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Fortune:");
            objectBaseAsset.fortune = EditorGUILayout.IntSlider(objectBaseAsset.fortune, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Life:");
            objectBaseAsset.life = EditorGUILayout.IntSlider(objectBaseAsset.life, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Death:");
            objectBaseAsset.death = EditorGUILayout.IntSlider(objectBaseAsset.death, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("War:");
            objectBaseAsset.war = EditorGUILayout.IntSlider(objectBaseAsset.war, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Peace:");
            objectBaseAsset.peace = EditorGUILayout.IntSlider(objectBaseAsset.peace, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Light:");
            objectBaseAsset.light = EditorGUILayout.IntSlider(objectBaseAsset.light, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Darkness:");
            objectBaseAsset.darkness = EditorGUILayout.IntSlider(objectBaseAsset.darkness, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Abundace:");
            objectBaseAsset.abundace = EditorGUILayout.IntSlider(objectBaseAsset.abundace, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Disaster:");
            objectBaseAsset.disaster = EditorGUILayout.IntSlider(objectBaseAsset.disaster, MIN_PROP_VALUE, MAX_PROP_VALUE);
        EditorGUILayout.EndHorizontal();

        #endregion
    }
}
