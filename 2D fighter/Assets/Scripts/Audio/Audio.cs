using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public static Audio instance;

    public AudioSource audioSource;
    public AudioClip attack, light_attack, on_hover, on_clicked, win_sound, get_hit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        
    }

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
