using UnityEngine;
using UnityEngine.UI;

public class Health_bar2 : MonoBehaviour
{
    // referencing the slider component for health representation on the healt bar
    public Slider Slider;

    // setting the max health
    public void setmaxhealth(int health)
    {
        Slider.value = health;
        Slider.maxValue = health;
    }

    // setting the current health
    public void sethealth(int health)
    {
        Slider.value = health;
    }
}
