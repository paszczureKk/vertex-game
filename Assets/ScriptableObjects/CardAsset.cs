using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Card", menuName = "Assets/Card")]
public class CardAsset : BaseAsset
{
    [Header("Karma")]
    public int karma;
}