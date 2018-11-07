using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Assets/Card")]
public class CardAsset : ScriptableObject
{
    [TextArea(2,3)]
    public string opis;

    [Header("Properties")]
    public int ogień;
    

}
