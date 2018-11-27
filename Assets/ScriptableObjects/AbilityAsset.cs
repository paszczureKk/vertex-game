using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Ability", menuName = "Assets/Ability")]
public class AbilityAsset : ScriptableObject
{

    [Range(1, 5)]
    public int level;
    public string abilityName;
    public Sprite image;

    [Space(10)]

    [TextArea(3, 5)]
    public string description;

    [Space(10)]

    public bool learned;

    public bool karma;
    public int cost;
}
