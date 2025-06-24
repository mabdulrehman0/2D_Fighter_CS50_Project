using UnityEngine;
using UnityEngine.UI;

public class Health_bar2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider Slider;

    public void setmaxhealth(int health)
    {
        Slider.value = health;
        Slider.maxValue = health;
    }


    public void sethealth(int health)
    {
        Slider.value = health;
    }
}
