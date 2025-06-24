using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    // singleton pattern to make it accesible for other scripts.
    public static Audio instance;
    // To plug in the audio source component in audio game object.
    public AudioSource audioSource;
    // This make it so i can refernce the audio clips
    public AudioClip attack, light_attack, on_hover, on_clicked, win_sound, get_hit;

    // This makes it so that it keeps running in other scenes aswell
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        
    }

    // the functions are to play audio clips when called on button or in scripts of other objects
    public void PlayAttack()
    {
        audioSource.PlayOneShot(attack);
    }
    public void PlayLightAttack()
    {
        audioSource.PlayOneShot(light_attack);
    }
    public void Playhit()
    {
        audioSource.PlayOneShot(get_hit);
    }
    public void Play_onhover()
    {
        audioSource.PlayOneShot(on_hover);
    }
    public void Play_onclicked()
    {
        audioSource.PlayOneShot(on_clicked);
    }
    public void Play_win()
    {
        audioSource.PlayOneShot(win_sound);
    }
}
