using UnityEngine;
using UnityEngine.EventSystems;

public class AudioUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    // Checks if mouse cursor is on the button if yes then play on hover sound (function from Audio.cs).
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Audio.instance != null)
            Audio.instance.Play_onhover();
    }
    // Check when the button is clicked and when clicked it plays on_clicked sound (function from Audio.cs).
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Audio.instance != null)
            Audio.instance.Play_onclicked();
    }
}
