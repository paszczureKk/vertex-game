using UnityEngine;
using UnityEngine.EventSystems;

public class PrayerSelfManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        DeckHandler.Instance.Draw(1);
        FollowersHandler.Instance.Prayers.Enqueue(gameObject);
        gameObject.transform.position = FollowersHandler.Instance.OriginPosition;
        gameObject.SetActive(false);

        FollowersHandler.Instance.PrayersSpawned--;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
