using UnityEngine;
using UnityEngine.EventSystems;

public class AudioUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Audio.instance != null)
            Audio.instance.Play_onhover();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Audio.instance != null)
            Audio.instance.Play_onclicked();
    }
}
