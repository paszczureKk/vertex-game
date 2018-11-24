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

    private int[] values = new int[16];
    private int triggeredCount;

    public override void OnInspectorGUI()
    {
        var objectBaseAsset = (BaseAsset)target;

        #region VALUES_INIT

        values[0] = objectBaseAsset.fire;
        values[1] = objectBaseAsset.water;
        values[2] = objectBaseAsset.air;
        values[3] = objectBaseAsset.earth;
        values[4] = objectBaseAsset.power;
        values[5] = objectBaseAsset.spirit;
        values[6] = objectBaseAsset.curse;
        values[7] = objectBaseAsset.fortune;
        values[8] = objectBaseAsset.life;
        values[9] = objectBaseAsset.death;
        values[10] = objectBaseAsset.war;
        values[11] = objectBaseAsset.peace;
        values[12] = objectBaseAsset.light;
        values[13] = objectBaseAsset.darkness;
        values[14] = objectBaseAsset.abundace;
        values[15] = objectBaseAsset.disaster;

        #endregion

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
        foreach(int value in values)
        {
            if (value != 0)
                triggeredCount++;
        }


        EditorGUI.BeginDisabledGroup((values[0] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Fire:");
                objectBaseAsset.fire = EditorGUILayout.IntSlider(objectBaseAsset.fire, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[1] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Water:");
                objectBaseAsset.water = EditorGUILayout.IntSlider(objectBaseAsset.water, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[2] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Air:");
                objectBaseAsset.air = EditorGUILayout.IntSlider(objectBaseAsset.air, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[3] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Earth:");
                objectBaseAsset.earth = EditorGUILayout.IntSlider(objectBaseAsset.earth, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[4] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Power:");
                objectBaseAsset.power = EditorGUILayout.IntSlider(objectBaseAsset.power, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[5] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Spirit:");
                objectBaseAsset.spirit = EditorGUILayout.IntSlider(objectBaseAsset.spirit, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[6] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Curse:");
                objectBaseAsset.curse = EditorGUILayout.IntSlider(objectBaseAsset.curse, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[7] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Fortune:");
                objectBaseAsset.fortune = EditorGUILayout.IntSlider(objectBaseAsset.fortune, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[8] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Life:");
                objectBaseAsset.life = EditorGUILayout.IntSlider(objectBaseAsset.life, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[9] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Death:");
                objectBaseAsset.death = EditorGUILayout.IntSlider(objectBaseAsset.death, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[10] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("War:");
                objectBaseAsset.war = EditorGUILayout.IntSlider(objectBaseAsset.war, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[11] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Peace:");
                objectBaseAsset.peace = EditorGUILayout.IntSlider(objectBaseAsset.peace, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[12] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Light:");
                objectBaseAsset.light = EditorGUILayout.IntSlider(objectBaseAsset.light, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[13] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Darkness:");
                objectBaseAsset.darkness = EditorGUILayout.IntSlider(objectBaseAsset.darkness, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[14] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Abundace:");
                objectBaseAsset.abundace = EditorGUILayout.IntSlider(objectBaseAsset.abundace, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup((values[15] == 0) && (objectBaseAsset.level <= triggeredCount));
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Disaster:");
                objectBaseAsset.disaster = EditorGUILayout.IntSlider(objectBaseAsset.disaster, MIN_PROP_VALUE, MAX_PROP_VALUE);
            EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        #endregion

        if (triggeredCount > objectBaseAsset.level)
            EditorGUILayout.HelpBox("Number of properties can not exceed object's level!", MessageType.Warning);
    }
}
