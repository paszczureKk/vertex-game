using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Assets/Card")]
public class CardAsset : ScriptableObject
{
    #region CONSTS
    private const int MAX_CARD_LEVEL = 3;
    private const int MIN_PROP_VALUE = -10;
    private const int MAX_PROP_VALUE = 10;
    #endregion

    [Header("Main")]
    [Range(1, MAX_CARD_LEVEL)]
    public int level;
    [TextArea(1, 1)]
    public string CardName;
    public Sprite image;
    [Space(8)]

    [TextArea(2,3)]
    public string brief;

    [Header("Properties")]
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int fire;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int water;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int power;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int spirit;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int air;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int earth;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int curse;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int fortune;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int life;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int death;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int war;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int peace;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int light;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int darkness;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int abundace;
    [Range(MIN_PROP_VALUE, MAX_PROP_VALUE)]
    public int disaster;

    [Header("Karma")]
    public int karma;
}
